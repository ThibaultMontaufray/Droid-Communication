using MailKit;
using MailKit.Net.Imap;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using Tools4Libraries;

namespace Droid_communication
{
    public delegate void InterfaceEventHandler(object o);
    public class InterfaceEmail : GPInterface
    {
        #region Attributes
        public event InterfaceEventHandler SheetDisplayRequested;
        public event InterfaceEventHandler AuthenticationChanged;

        private readonly int TOP_OFFSET = 175;
        private readonly ImapClient _client = new ImapClient(new ProtocolLogger("imap.txt"));
        private new ToolStripMenuEmail _tsm;
        private List<ClientMail> _clientMail;
        private Inbox _currentInbox;
        private List<Inbox> _inbox;

        private ViewMailBox _viewMailBox;
        private ViewLogin _viewLogin;
        #endregion

        #region Properties
        public Inbox CurrentInbox
        {
            get { return _currentInbox; }
            set { _currentInbox = value; }
        }
        public List<Inbox> Inbox
        {
            get { return _inbox; }
            set { _inbox = value; }
        }
        public ImapClient Client
        {
            get { return _client; }
        }
        public ToolStripMenuEmail Tsm
        {
            get { return _tsm; }
            set { _tsm = value; }
        }
        public List<ClientMail> ClientMail
        {
            get { return _clientMail; }
            set { _clientMail = value; }
        }
        #endregion

        #region Constructor
        public InterfaceEmail()
        {
            Init();
        }
        #endregion

        #region Methods public
        public RibbonTab BuildToolBar()
        {
            _tsm = new ToolStripMenuEmail(this);
            _tsm.ActionAppened += GlobalAction;
            return _tsm;
        }

        //#region ACTIONS
        //public static void ACTION_lancer_docker_130()
        //{
        //    ViewDocker ddp = new ViewDocker();
        //    //ddp.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        //    //ddp.ShowDialog();
        //}
        //#endregion

        public override void GoAction(string action)
        {
            switch (action)
            {
                case "AnswerAll":
                    LaunchAnswerAll();
                    break;
                case "Connection":
                    LaunchConnection();
                    break;
                case "Inbox":
                    LaunchInbox();
                    break;
                case "Delete":
                    LaunchDelete();
                    break;
                case "DelMail":
                    LaunchDelMail();
                    break;
                case "DirectMessage":
                    LaunchDirectMessage();
                    break;
                case "NewElement":
                    LaunchNewElement();
                    break;
                case "NewMail":
                    LaunchNewMail();
                    break;
                case "NoConnection":
                    LaunchNoConnection();
                    break;
                case "SendReceive":
                    LaunchSendReceive();
                    break;
                case "Transfert":
                    LaunchTransfert();
                    break;
            }
        }
        public bool Reconnect()
        {
            try
            {
                if (_client.IsConnected) { _client.Disconnect(true); }
                _client.Connect(_currentInbox.Uri);

                _client.AuthenticationMechanisms.Remove("XOAUTH2");

                try
                {
                    _client.Authenticate(_currentInbox.Credentials);
                    Params.CommunicationMailLogin = _currentInbox.Login;
                    Params.CommunicationMailPassword = _currentInbox.Password;
                    Params.CommunicationMailImapEncryption = _currentInbox.ClientMail.ImapEncryption.ToString();
                    Params.CommunicationMailSmtpEncryption = _currentInbox.ClientMail.SmtpEncryption.ToString();
                    Params.CommunicationMailImapHost = _currentInbox.ClientMail.ImapServer;
                    Params.CommunicationMailSmtpHost = _currentInbox.ClientMail.SmtpServer;
                    Params.CommunicationMailImapPort = _currentInbox.ClientMail.ImapPort.ToString();
                    Params.CommunicationMailSmtpPort = _currentInbox.ClientMail.SmtpPort.ToString();
                    if (AuthenticationChanged != null ) { AuthenticationChanged(null); }
                    LaunchInbox();
                    return true;
                }
                catch (Exception ex)
                {
                    if (AuthenticationChanged != null) { AuthenticationChanged(ex.Message); }
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
            return false;
        }
        #endregion

        #region Methods private
        private void Init()
        {
            _sheet = new Panel();
            _sheet.Name = "SheetEmail";
            _sheet.BackColor = System.Drawing.Color.DimGray;
            _sheet.Dock = DockStyle.Fill;
            _sheet.Resize += _sheet_Resize;
            
            _client.Disconnected += OnClientDisconnected;
            BuildToolBar();

            LoadClientMail();
            LoadInbox();
            LaunchInbox();
        }
        private void LoadClientMail()
        {
            int port;
            ClientMail currentClient = null;
            _clientMail = new List<ClientMail>();

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(Properties.Resources.EmailClient);
            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                if (node.Name.Equals("client"))
                {
                    currentClient = new ClientMail();
                    currentClient.Name = node.Attributes.GetNamedItem("name").Value;
                    foreach (XmlNode subNode in node.ChildNodes)
                    {
                        port = -1;
                        switch (subNode.Name)
                        {
                            case "imap":
                                int.TryParse(subNode.Attributes.GetNamedItem("port").Value, out port);
                                currentClient.ImapPort = port;
                                currentClient.ImapServer = subNode.Attributes.GetNamedItem("server").Value;
                                currentClient.ImapEncryption = !string.IsNullOrEmpty(subNode.Attributes.GetNamedItem("encryption").Value.ToString()) ? (MailEncryption)Enum.Parse(typeof(MailEncryption), subNode.Attributes.GetNamedItem("encryption").Value) : MailEncryption.NONE;
                                break;
                            case "smtp":
                                int.TryParse(subNode.Attributes.GetNamedItem("port").Value, out port);
                                currentClient.SmtpPort = port;
                                currentClient.SmtpServer = subNode.Attributes.GetNamedItem("server").Value;
                                currentClient.SmtpEncryption = !string.IsNullOrEmpty(subNode.Attributes.GetNamedItem("encryption").Value.ToString()) ? (MailEncryption)Enum.Parse(typeof(MailEncryption), subNode.Attributes.GetNamedItem("encryption").Value) : MailEncryption.NONE;
                                break;
                        }
                    }
                    _clientMail.Add(currentClient);
                }
            }
        }
        private void LoadInbox()
        {
            _inbox = new List<Inbox>();
            _currentInbox = new Droid_communication.Inbox();
            _currentInbox.Login = Params.CommunicationMailLogin;
            _currentInbox.Password = Params.CommunicationMailPassword;

            if (!string.IsNullOrEmpty(Params.CommunicationMailImapPort)) _currentInbox.ClientMail.ImapPort = int.Parse(Params.CommunicationMailImapPort);
            if (!string.IsNullOrEmpty(Params.CommunicationMailImapEncryption)) _currentInbox.ClientMail.ImapEncryption = (MailEncryption)Enum.Parse(typeof(MailEncryption), Params.CommunicationMailImapEncryption);
            _currentInbox.ClientMail.ImapServer = Params.CommunicationMailImapHost;

            if (!string.IsNullOrEmpty(Params.CommunicationMailSmtpPort)) _currentInbox.ClientMail.SmtpPort = int.Parse(Params.CommunicationMailSmtpPort);
            if (!string.IsNullOrEmpty(Params.CommunicationMailSmtpEncryption)) _currentInbox.ClientMail.SmtpEncryption = (MailEncryption)Enum.Parse(typeof(MailEncryption), Params.CommunicationMailSmtpEncryption);
            _currentInbox.ClientMail.SmtpServer = Params.CommunicationMailSmtpHost;

            if (_currentInbox.Login != null) LaunchInbox();
        }
        private void OnClientDisconnected(object sender, EventArgs e)
        {
            Reconnect();
        }
        
        #region Launch
        private void LaunchAnswerAll() { }
        private void LaunchConnection()
        {
            _sheet.Controls.Clear();

            if (_viewLogin == null) { _viewLogin = new ViewLogin(this); }

            LoadInbox();
            _viewLogin.Top = TOP_OFFSET;
            _viewLogin.RefreshData();
            _viewLogin.Left = (_sheet.Width / 2) - (_viewLogin.Width / 2);
            _viewLogin.ChangeLanguage();
            _viewLogin.Name = "CurrentView";
            _sheet.Controls.Add(_viewLogin);
            if (SheetDisplayRequested != null) SheetDisplayRequested(null);
            this.Refresh();

        }
        private void LaunchInbox()
        {
            _sheet.Controls.Clear();

            if (_viewMailBox == null) { _viewMailBox = new ViewMailBox(this); }

            _viewMailBox.Top = TOP_OFFSET - 40;
            _viewMailBox.RefreshData();
            _viewMailBox.ChangeLanguage();
            _viewMailBox.Width = _sheet.Width - 20;
            _viewMailBox.Left = (_sheet.Width / 2) - (_viewMailBox.Width / 2);
            _viewMailBox.Height = _sheet.Height - TOP_OFFSET + 10;
            _viewMailBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            _viewMailBox.Name = "CurrentView";
            _sheet.Controls.Add(_viewMailBox);
            if (SheetDisplayRequested != null) SheetDisplayRequested(null);
            this.Refresh();
        }
        private void LaunchDelete() { }
        private void LaunchDelMail() { }
        private void LaunchDirectMessage() { }
        private void LaunchNewElement() { }
        private void LaunchNewMail() { }
        private void LaunchNoConnection() { }
        private void LaunchSendReceive() { }
        private void LaunchTransfert() { }
        #endregion
        #endregion

        #region Event
        private void _sheet_Resize(object sender, EventArgs e)
        {
            Resize();
        }
        #endregion
    }
}
