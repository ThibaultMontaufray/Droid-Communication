namespace Droid.Communication
{
    using Assistant;
    using ComAdapter.View;
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Mail;
    using System.Windows.Forms;
    using System.Xml.Serialization;
    using Tools4Libraries;

    /// <summary>
    /// Interface for Tobi Assistant application : take care, some french word here to allow Tobi to speak with natural language.
    /// </summary>     
    [Serializable]
    [XmlRoot("communication")]
    public class InterfaceCommunication : GPInterface
    {
        #region Attribute
        public event InterfaceEventHandler SheetDisplayRequested;

        public readonly int TOP_OFFSET = 150;
        public const string CONFIGFILE = "communication.config";

        private new ToolStripMenuCom _tsm;
        private string _workingDirectory;

        private EmailAdapter _adapterMail;
        private FacebookAdapter _adapterFacebook;
        private SlackAdapter _adapterSlack;

        private ViewComWelcome _viewWelcomeCom;
        #endregion

        #region Properties
        public ToolStripMenuCom Tsm
        {
            get { return _tsm; }
            set { _tsm = value as ToolStripMenuCom; }
        }
        public string WorkingDirectory
        {
            get { return _workingDirectory; }
            set { _workingDirectory = value; }
        }
        #endregion

        #region Constructor
        public InterfaceCommunication()
        {
            _workingDirectory = Tools4Libraries.Params.ConfigFile = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Servodroid\";
            Init();
        }
        public InterfaceCommunication(string workingDirectory)
        {
            _workingDirectory = string.IsNullOrEmpty(workingDirectory) ? Tools4Libraries.Params.ConfigFile = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Servodroid\" : workingDirectory;
            Init();
        }
        #endregion

        #region Actions
        public static void ACTION_130_envoyer_mail(string titre, List<MailAddress> mail_destinataire, string message, List<SlackAttachment> piece_jointe = null, string mail_destinataire_copie = "", string mail_destinataire_copie_cache = "")
        {
            //Mail.SendMail(titre, mail_destinataire, piece_jointe, message, mail_destinataire_copie, mail_destinataire_copie_cache);
        }
        public static bool ACTION_131_envoyer_message(string canal, string message, string destinataire)
        {
            try
            {
                switch(canal.ToLower())
                {
                    case "lync":
                    case "lynk":
                    case "linc":
                    case "link":
                        break;
                    case "mail":
                    case "outlook":
                    case "gmail":
                        break;
                    case "slack":
                    case "slac":
                    case "slak":
                        break;
                }

                using (var client = new WebClient())
                {
                    using (var stream = client.OpenRead("http://www.google.com"))
                    {
                        return true;
                    }
                }
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region Methods public
        public System.Windows.Forms.RibbonTab BuildToolBar()
        {
            _tsm = new ToolStripMenuCom(this);
            _tsm.ActionAppened += GlobalAction;
            return _tsm;
        }
        public override void GoAction(string action)
        {
            action = action.Replace(" ", "_");
            if (!string.IsNullOrEmpty(action))
            {
                if (action.ToLower().StartsWith("slack"))
                {
                    if (_adapterSlack == null) { InitSlack(); }
                    _adapterSlack.GoAction(action.ToLower().Replace("slack_", string.Empty));
                }
                if (action.ToLower().StartsWith("mail"))
                {
                    if (_adapterMail == null) { InitMail(); }
                    _adapterMail.GoAction(action.ToLower().Replace("mail_", string.Empty));
                }
                if (action.ToLower().StartsWith("facebook"))
                {
                    if (_adapterFacebook == null) { InitFacebook(); }
                    _adapterFacebook.GoAction(action.ToLower().Replace("facebook_", string.Empty));
                }
            }
        }
        #endregion

        #region Methods private
        private void Init()
        {
            _sheet = new PanelScrollableCustom();
            _sheet.Name = "SheetCom";
            _sheet.BackgroundImage = Properties.Resources.ShieldTileBg;
            _sheet.BackgroundImageLayout = ImageLayout.Tile;
            _sheet.Dock = DockStyle.Fill;
            _sheet.Resize += _sheet_Resize;
            
            BuildToolBar();          
            LaunchWelcomeView();
        }
        private void InitMail()
        {
            _adapterMail = new EmailAdapter(this);
            _adapterMail.SheetDisplayRequested += _intMail_SheetDisplayRequested;
        }
        private void InitSlack()
        {
            _adapterSlack = new SlackAdapter(this);
            _adapterSlack.SheetDisplayRequested += _intSlack_SheetDisplayRequested;
        }
        private void InitFacebook()
        {
            _adapterFacebook = new FacebookAdapter(this);
            _adapterFacebook.SheetDisplayRequested += _intFacebook_SheetDisplayRequested;
        }

        private void LaunchWelcomeView()
        {
            if (_viewWelcomeCom == null)
            {
                _viewWelcomeCom = new ViewComWelcome(this);
                _viewWelcomeCom.Name = "CurrentView";
            }
            _viewWelcomeCom.Top = TOP_OFFSET;
            _viewWelcomeCom.RefreshData();
            _viewWelcomeCom.Left = (_sheet.Width / 2) - (_viewWelcomeCom.Width / 2);
            _viewWelcomeCom.ChangeLanguage();
            _sheet.Controls.Add(_viewWelcomeCom);

            if (SheetDisplayRequested != null) SheetDisplayRequested(null);
        }
        private void DisplaySheet()
        {
            this.Refresh();
        }
        #endregion

        #region Event
        private void _sheet_Resize(object sender, EventArgs e)
        {
            Resize();
        }
        private void _intMail_SheetDisplayRequested(object o)
        {
            if (SheetDisplayRequested != null) SheetDisplayRequested(null);
        }
        private void _intSlack_SheetDisplayRequested(object o)
        {
            if (SheetDisplayRequested != null) SheetDisplayRequested(null);
        }
        private void _intFacebook_SheetDisplayRequested(object o)
        {
            if (SheetDisplayRequested != null) SheetDisplayRequested(null);
        }
        #endregion
    }
}
