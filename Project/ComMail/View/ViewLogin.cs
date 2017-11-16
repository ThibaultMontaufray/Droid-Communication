using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using Tools4Libraries;

namespace Droid_communication
{
    public delegate void OnLoginWindowEventHandler();
    public partial class ViewLogin : UserControl
    {
        #region Attributes
        public event OnLoginWindowEventHandler LoginCompleted;

        private CancellationTokenSource _cancel = new CancellationTokenSource();
        private InterfaceEmail _intEmail;
        #endregion

        #region Properties
        public InterfaceEmail InterfaceEmail
        {
            get { return _intEmail; }
            set
            {
                _intEmail = value;
                LoadClientMail();
            }
        }
        #endregion

        #region Constructor
        public ViewLogin()
        {
            InitializeComponent();
            Init();
        }
        public ViewLogin(InterfaceEmail intEmail)
        {
            InitializeComponent();
            _intEmail = intEmail;

            Init();
        }
        #endregion

        #region Methods public
        public void RefreshData()
        {

        }
        public void ChangeLanguage()
        {

        }
        #endregion

        #region Methods private
        private void Init()
        {
            if (_intEmail != null)
            {
                LoadClientMail();
            }

            sslCheckbox.Checked = "true".Equals(_intEmail.CurrentInbox.ClientMail.ImapEncryption);
            passwordTextBox.Text = _intEmail.CurrentInbox.Password;
            loginTextBox.Text = _intEmail.CurrentInbox.Login;
            if (!string.IsNullOrEmpty(_intEmail.CurrentInbox.ClientMail.ImapServer))
            {
                var client = _intEmail.ClientMail.Where(c => c.ImapServer.Equals(_intEmail.CurrentInbox.ClientMail.ImapServer)).ToList()[0];
                serverCombo.SelectedItem = client as ClientMail;
                if (client != null)
                { 
                    sslCheckbox.Checked = _intEmail.CurrentInbox.ClientMail.ImapEncryption == MailEncryption.SSL;
                    serverCombo.Text = _intEmail.CurrentInbox.ClientMail.ImapServer;
                    portCombo.Text = _intEmail.CurrentInbox.ClientMail.ImapPort.ToString();
                }
            }

            CheckCanLogin();

            sslCheckbox.CheckedChanged += EnableSSLChanged;
            passwordTextBox.TextChanged += LoginChanged;
            loginTextBox.TextChanged += LoginChanged;
            serverCombo.TextChanged += ServerChanged;
            portCombo.TextChanged += PortChanged;
            signInButton.Click += SignInClicked;
        }
        private void LoadClientMail()
        {
            serverCombo.Items.Clear();
            foreach (var item in _intEmail.ClientMail)
            {
                serverCombo.Items.Add(item);
            }
        }
        private void CheckCanLogin()
        {
            signInButton.Enabled = !string.IsNullOrEmpty(serverCombo.Text) &&
                !string.IsNullOrEmpty(loginTextBox.Text) &&
                !string.IsNullOrEmpty(passwordTextBox.Text);
        }
        #endregion

        #region Event
        private void PortChanged(object sender, EventArgs e)
        {
            var port = portCombo.Text.Trim();

            switch (port)
            {
                case "143":
                    sslCheckbox.Checked = false;
                    break;
                case "993":
                    sslCheckbox.Checked = true;
                    break;
            }
        }
        private void ServerChanged(object sender, EventArgs e)
        {
            ClientMail cm = serverCombo.SelectedItem as ClientMail;
            sslCheckbox.Checked = cm.ImapEncryption == MailEncryption.SSL;
            portCombo.Text = cm.ImapPort.ToString();
            if (portCombo.Text == "-1") { portCombo.Text = string.Empty; }

            CheckCanLogin();
        }
        private void EnableSSLChanged(object sender, EventArgs e)
        {
            var checkbox = (CheckBox)sender;
            var port = portCombo.Text;

            if (string.IsNullOrEmpty(port))
                portCombo.Text = checkbox.Checked ? "993" : "143";
        }
        private void LoginChanged(object sender, EventArgs e)
        {
            CheckCanLogin();
        }
        private void SignInClicked(object sender, EventArgs e)
        {
            signInButton.Enabled = false;
            Inbox inbox = new Inbox();
            inbox.Login = loginTextBox.Text;
            inbox.Password = passwordTextBox.Text;
            inbox.ClientMail = serverCombo.SelectedItem as ClientMail;

            _intEmail.Inbox.Add(inbox);
            _intEmail.CurrentInbox = inbox;
            
            signInButton.Enabled = !_intEmail.Reconnect();

            if (LoginCompleted != null) { LoginCompleted(); }
            //_intEmail.MainWindow.LoadContent();

            //Visible = false;

            //_intEmail.MainWindow.Visible = true;
        }
        #endregion
    }
}
