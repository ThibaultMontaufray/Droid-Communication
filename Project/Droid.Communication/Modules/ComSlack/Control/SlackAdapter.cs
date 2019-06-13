using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Droid.Communication
{
    public delegate void SlackAdapterEventHandler(object o);
    public class SlackAdapter : CommunicationAdapter
    {
        #region Attributes
        public const string LOGFILE = "log.txt";
        public event SlackAdapterEventHandler OnMessagesUpdated;
        
        private List<Channel> _channels;
        private List<Member> _users;
        private List<Token> _tokens;
        private Channel _currentChannel;
        private Team _team;
        //private SlackRtm _slackRtm;
        private Member _currentUser;
        #endregion

        #region Properties
        public new Token Token
        {
            get
            {
                Token current = null;
                if (_tokens != null)
                {
                    foreach (var item in _tokens)
                    {
                        if (item.IsUsed) return item;
                    }
                }
                return current;
            }
        }
        public List<Token> Tokens
        {
            get { return _tokens; }
            set { _tokens = value; }
        }
        public List<Member> Users
        {
            get { return _users; }
            set { _users = value; }
        }
        public List<Channel> Channels
        {
            get { return _channels; }
            set { _channels = value; }
        }
        public Team Team
        {
            get { return _team; }
            set { _team = value; }
        }
        public Channel CurrentChannel
        {
            get { return _currentChannel; }
            set { _currentChannel = value; }
        }
        //public SlackRtm SlackRtm
        //{
        //    get { return _slackRtm; }
        //    set { _slackRtm = value; }
        //}
        public Member CurrentUser
        {
            get { return _currentUser; }
            set { _currentUser = value; }
        }
        #endregion

        #region Constructor
        public SlackAdapter()
        {
            Init();
        }
        public SlackAdapter(InterfaceCommunication parent)
        {
            _parent = parent;
            Init();
        }
        #endregion

        #region Methods public
        public override void GoAction(string action)
        {
            switch (action)
            {
            }
        }
        public new void RefreshData()
        {
            try
            {
                _channels = ChannelsControler.List(this);
                if (_channels != null)
                {
                    _channels.AddRange(GroupControler.List(this));
                    _channels.AddRange(ImControler.List(this));
                }
                _users = UserControler.List(this);
                _team = TeamControler.Info(this);

                InitRtm();
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }
        public void SendMessage(string message)
        {
            if (_currentChannel != null)
            {
                //_slackRtm.SendMessage(_currentChannel, message, null);
            }
        }
        #endregion

        #region Methods private
        private void Init()
        {
            _tokens = new List<Token>();

            _tokens.Clear();
            _tokens.Add(new Token() { Key = "xoxp-6104768437-234597334390-290769438534-313d42ef19ed74508c8cb9c73ad51267" });
            _tokens.Add(new Token() { Key = "xoxp-29216308806-29257232582-289965290692-5e7e35d1c1a123a5f773335a14e7ecc1" });
            _tokens.Add(new Token() { Key = "xoxp-358104756453-357740078596-375203192033-51e0f5f1799baea32a8183cf0b5a4692", IsUsed = true });

            _currentUser = UserControler.GetProfile(this);
            _channels = new List<Channel>();
            _users = new List<Member>();

            //_slackRtm = new SlackRtm(this);
            //_slackRtm.OnEvent += Instance_OnEvent1;
            //_slackRtm.OnAck += Instance_OnAck;

            RefreshData();
        }
        private void InitRtm()
        {
            //if (_slackRtm != null)
            //{
            //    _slackRtm.OnEvent -= Instance_OnEvent1;
            //    _slackRtm.OnAck -= Instance_OnAck;
            //}

            //if (_token != null)
            //{
            //    _slackRtm = new SlackRtm(this);
            //    _slackRtm.OnEvent += Instance_OnEvent1;
            //    _slackRtm.OnAck += Instance_OnAck;
            //    if (!_slackRtm.Connect())
            //    {

            //    }
            //}
        }

        private void ProcessEvent(SlackEventArgs eventArg)
        {
            ProcessEventLog(eventArg);
            switch (eventArg.Data.Type)
            {
                case "message":
                    ProcessEventMessage(Accessor.Deserialize<Message>(eventArg.Data.ToJson()));
                    break;
                case "hello":
                    break;
                case "reconnect_url":
                    break;
                case "channel_marked":
                    break;
                case "error":
                    break;
                case "user_typing":
                    break;
                default:
                    break;
            }
        }
        private void ProcessEventLog(SlackEventArgs eventArg)
        {
            if (System.IO.File.Exists(LOGFILE))
            {
                System.IO.FileInfo fi = new System.IO.FileInfo(LOGFILE);
                if (fi.Length > 100000)
                {
                    if (System.IO.File.Exists(LOGFILE + ".backup"))
                    {
                        System.IO.File.Delete(LOGFILE + ".backup");
                    }
                    System.IO.File.Move(LOGFILE, LOGFILE + ".backup");
                }
            }
            using (StreamWriter sw = new StreamWriter(LOGFILE, true))
            {
                sw.WriteLine(string.Format("{0} Event : {1} [{2}]", DateTime.Now, eventArg.Data.ToJson()), eventArg.Data.ToString());
            }
        }
        private void ProcessEventMessage(Message msg)
        {
            if (_currentChannel.Id == msg.Channel)
            { 
                OnMessagesUpdated?.Invoke(msg);
            }
        }
        #endregion

        #region Event
        private void _sheet_Resize(object sender, EventArgs e)
        {
            Resize();
        }
        private void Instance_OnAck(object sender, SlackEventArgs e)
        {
            using (StreamWriter sw = new StreamWriter("log.txt", true))
            {
                sw.WriteLine(string.Format("{0} Ack : {1}", DateTime.Now, e.Data.ToJson()));
            }
        }
        private void Instance_OnEvent1(object sender, SlackEventArgs e)
        {
            ProcessEvent(e);
        }
        #endregion
    }
}
