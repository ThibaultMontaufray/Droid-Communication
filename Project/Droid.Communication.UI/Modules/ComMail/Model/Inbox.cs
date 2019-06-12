using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Droid.Communication
{
    [Serializable]
    public class Inbox
    {
        #region Attributes
        private ClientMail _clientMail;
        private string _login;
        private string _password;
        private ICredentials _credentials;
        private Uri _uri;
        #endregion

        #region Properties
        public string Protocol
        {
            get
            {
                if (_clientMail.ImapEncryption == MailEncryption.SSL)
                    return "imaps";
                else
                    return "imap";
            }
        }
        public Uri Uri
        {
            get
            {
                if (_clientMail == null || string.IsNullOrEmpty(_clientMail.ImapServer)) return new Uri(string.Empty);
                if (_clientMail.ImapPort != -1)
                    return new Uri(string.Format("{0}://{1}:{2}", Protocol, _clientMail.ImapServer, _clientMail.ImapPort));
                else
                    return new Uri(string.Format("{0}://{1}", Protocol, _clientMail.ImapServer));

            }
            set { _uri = value; }
        }
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                _credentials = new NetworkCredential(_login, _password);
            }
        }
        public string Login
        {
            get { return _login; }
            set { _login = value; }
        }
        public ClientMail ClientMail
        {
            get { return _clientMail; }
            set { _clientMail = value; }
        }
        public ICredentials Credentials
        {
            get { return _credentials; }
            set { _credentials = value; }
        }
        #endregion

        #region Constructor
        public Inbox()
        {
            _clientMail = new ClientMail();
        }
        #endregion

        #region Methods public
        #endregion

        #region Methods private
        #endregion
    }
}
