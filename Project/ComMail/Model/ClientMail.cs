using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Droid_communication
{
    public class ClientMail
    {
        #region Attributes
        private string _name;
        private int _smtpPort;
        private MailEncryption _smtpEncryption;
        private string _smtpServer;
        private int _imapPort;
        private MailEncryption _imapEncryption;
        private string _imapServer;
        #endregion

        #region Properties
        public MailEncryption SmtpEncryption
        {
            get { return _smtpEncryption; }
            set { _smtpEncryption = value; }
        }
        public int SmtpPort
        {
            get { return _smtpPort; }
            set { _smtpPort = value; }
        }
        public string SmtpServer
        {
            get { return _smtpServer; }
            set { _smtpServer = value; }
        }
        public MailEncryption ImapEncryption
        {
            get { return _imapEncryption; }
            set { _imapEncryption = value; }
        }
        public int ImapPort
        {
            get { return _imapPort; }
            set { _imapPort = value; }
        }
        public string ImapServer
        {
            get { return _imapServer; }
            set { _imapServer = value; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        #endregion

        #region Constructor
        public ClientMail()
        {
        }
        #endregion

        #region Methods public
        public override string ToString()
        {
            return string.Format("{0}", _name);
        }
        #endregion

        #region Methods private
        #endregion
    }
}
