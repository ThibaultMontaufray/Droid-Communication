using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Serialization;
using Tools4Libraries;

namespace Droid.Communication
{
    public delegate void InterfaceEventHandler(object o);

    [XmlInclude(typeof(SlackAdapter))]
    [Serializable]
    public class CommunicationAdapter : GPInterface
    {
        #region Attributes
        public event InterfaceEventHandler SheetDisplayRequested;

        protected string _url;
        protected string _name;
        protected bool _online;
        protected int _id;
        protected string _domain;
        protected string _ip;
        protected string _port;
        protected string _login;
        protected string _password;
        protected Token _token;
        protected InterfaceCommunication _parent;
        #endregion

        #region Properties
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public Token Token
        {
            get { return _token; }
            set { _token = value; }
        }
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
        public string Login
        {
            get { return _login; }
            set { _login = value; }
        }
        public string Port
        {
            get { return _port; }
            set { _port = value; }
        }
        public string Ip
        {
            get { return _ip; }
            set { _ip = value; }
        }
        public string Domain
        {
            get { return _domain; }
            set { _domain = value; }
        }
        public string Url
        {
            get { return _url; }
            set { _url = value; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        [XmlIgnore]
        public virtual bool Online
        {
            get
            {
                return _online;
            }
        }
        #endregion

        #region Constructor
        public CommunicationAdapter()
        {
            _id = (new Random((int)DateTime.Now.Ticks)).Next();
            RefreshConnection();
        }
        public CommunicationAdapter(InterfaceCommunication intCom)
        {
            _parent = intCom;
            _id = (new Random((int)DateTime.Now.Ticks)).Next();
            RefreshConnection();
        }
        #endregion

        #region Methods public
        public void RefreshStatus()
        {
            RefreshConnection();
        }
        public override void GoAction(string action)
        {
        }
        #endregion

        #region Methods protected
        protected void RefreshConnection()
        {
            if (string.IsNullOrEmpty(_url))
            {
                _online = false;
            }
            else
            {
                try
                {
                    Ping ping = new Ping();
                    string url = Droid.Web.Web.GetPingDomain(_url);
                    PingReply pr = ping.Send(url);

                    _online = pr.Status == IPStatus.Success;
                }
                catch
                {
                    _online = false;
                }
            }
        }
        #endregion
    }
}
