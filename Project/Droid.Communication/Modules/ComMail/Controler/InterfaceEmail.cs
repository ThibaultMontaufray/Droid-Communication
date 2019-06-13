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

namespace Droid.Communication
{
    public class EmailAdapter : CommunicationAdapter
    {
        #region Attributes
        public event InterfaceEventHandler AuthenticationChanged;

        private readonly int TOP_OFFSET = 175;
        private readonly ImapClient _client = new ImapClient(new ProtocolLogger("imap.txt"));
        private static List<ClientMail> _clientMail;
        private Inbox _currentInbox;
        private List<Inbox> _inbox;
        
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
        public static List<ClientMail> ClientMail
        {
            get { return _clientMail; }
            set { _clientMail = value; }
        }
        #endregion

        #region Constructor
        public EmailAdapter()
        {
            Init();
        }
        public EmailAdapter(InterfaceCommunication parent)
        {
            _parent = parent;
            Init();
        }
        static EmailAdapter()
        {
            // TODO : change the empty by the real mail
            LoadClientMailLibrary(string.Empty);
        }
        #endregion

        #region Methods public
        //public RibbonTab BuildToolBar()
        //{
        //    _tsm = new ToolStripMenuCom(this);
        //    _tsm.ActionAppened += GlobalAction;
        //    return _tsm;
        //}

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
                case "answerall":
                    LaunchAnswerAll();
                    break;
                case "connection":
                    LaunchConnection();
                    break;
                case "inbox":
                    LaunchInbox();
                    break;
                case "delete":
                    LaunchDelete();
                    break;
                case "delmail":
                    LaunchDelMail();
                    break;
                case "directmessage":
                    LaunchDirectMessage();
                    break;
                case "newelement":
                    LaunchNewElement();
                    break;
                case "newmail":
                    LaunchNewMail();
                    break;
                case "noconnection":
                    LaunchNoConnection();
                    break;
                case "sendreceive":
                    LaunchSendReceive();
                    break;
                case "transfert":
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
                    //Params.CommunicationMailLogin = _currentInbox.Login;
                    //Params.CommunicationMailPassword = _currentInbox.Password;
                    //Params.CommunicationMailImapEncryption = _currentInbox.ClientMail.ImapEncryption.ToString();
                    //Params.CommunicationMailSmtpEncryption = _currentInbox.ClientMail.SmtpEncryption.ToString();
                    //Params.CommunicationMailImapHost = _currentInbox.ClientMail.ImapServer;
                    //Params.CommunicationMailSmtpHost = _currentInbox.ClientMail.SmtpServer;
                    //Params.CommunicationMailImapPort = _currentInbox.ClientMail.ImapPort.ToString();
                    //Params.CommunicationMailSmtpPort = _currentInbox.ClientMail.SmtpPortSSL.ToString();
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
        public void Authentication(string login, string password)
        {
            Inbox inbox = new Inbox();
            inbox.Login = login;
            inbox.Password = password;
            inbox.ClientMail = new Droid.Communication.ClientMail() {  };
            this.Inbox.Add(inbox);
            _currentInbox = inbox;
            
            Reconnect();
        }
        #endregion

        #region Methods private
        private void Init()
        {
            _client.Disconnected += OnClientDisconnected;
            //BuildToolBar();

            LoadInbox();
        }
        private static void LoadClientMailLibrary(string emailClient)
        {
            int port;
            ClientMail currentClient = null;
            _clientMail = new List<ClientMail>();

            XmlDocument doc = new XmlDocument();
            //doc.LoadXml(Properties.Resources.EmailClient);
            doc.LoadXml(emailClient);
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
                                currentClient.SmtpPortSSL = port;
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
            _currentInbox = new Droid.Communication.Inbox();
            _currentInbox.Login = Params.CommunicationMailLogin;
            _currentInbox.Password = Params.CommunicationMailPassword;

            if (!string.IsNullOrEmpty(Params.CommunicationMailImapPort)) _currentInbox.ClientMail.ImapPort = int.Parse(Params.CommunicationMailImapPort);
            if (!string.IsNullOrEmpty(Params.CommunicationMailImapEncryption)) _currentInbox.ClientMail.ImapEncryption = (MailEncryption)Enum.Parse(typeof(MailEncryption), Params.CommunicationMailImapEncryption);
            _currentInbox.ClientMail.ImapServer = Params.CommunicationMailImapHost;

            if (!string.IsNullOrEmpty(Params.CommunicationMailSmtpPort)) _currentInbox.ClientMail.SmtpPortSSL = int.Parse(Params.CommunicationMailSmtpPort);
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
        }
        private void LaunchInbox()
        {
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
