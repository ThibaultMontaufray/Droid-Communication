using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tools4Libraries;

namespace Droid.Communication
{
    public partial class SlackManage : UserControlCustom
    {
        #region Attributes
        private SlackAdapter _adapter;
        #endregion

        #region Properties
        public SlackAdapter SlackAdapter
        {
            get { return _adapter; }
            set { _adapter = value; }
        }
        #endregion

        #region Constructor
        public SlackManage()
        {
            InitializeComponent();
            Init();
        }
        public SlackManage(SlackAdapter sa)
        {
            _adapter = sa;
            InitializeComponent();
            Init();
        }
        #endregion

        #region Methods public
        public override void RefreshData()
        {
            _slackMenu.RefreshData();
            _slackHeader.RefreshData();
            _slackConversation.RefreshData();
        }
        #endregion

        #region Methods private
        private void Init()
        {
            if (_adapter == null) { _adapter = new SlackAdapter(); }
            _slackMenu.Adapter = _adapter;
            _slackConversation.Adapter = _adapter;
            _slackInput.Adapter = _adapter;
            _slackHeader.Adapter = _adapter;

            _slackMenu.RefreshData();
            _slackMenu.OnChannelChanged += _slackMenu_OnChannelChanged;
            _slackMenu.OnUserChanged += _slackMenu_OnUserChanged;
            _slackInput.OnMessageSendingRequest += _slackInput_OnMessageSendingRequest;
            
            if (_adapter.Channels != null && _adapter.Channels.Count > 0)
            {
                Channel defaultChannel = _adapter.Channels.Where(c => c.Name.ToLower().Equals("general")).Count() > 0 ? _adapter.Channels.Where(c => c.Name.ToLower().Equals("general")).FirstOrDefault() : _adapter.Channels.FirstOrDefault();
                RefreshConversation(defaultChannel);
            }
        }
        private void RefreshConversation(Channel channel)
        {
            if (channel != null)
            { 
                _slackConversation.LoadConversation(channel.Id);
                _adapter.CurrentChannel = channel;
                _slackHeader.RefreshData();
            }
        }
        #endregion

        #region Event
        private void _slackMenu_OnUserChanged(object o)
        {
            //_slackConversation.LoadConversation(_slackAdapter, "");
        }
        private void _slackMenu_OnChannelChanged(object o)
        {
            Channel channel = (Channel)o;
            RefreshConversation(channel);
        }
        private void _slackInput_OnMessageSendingRequest(object o)
        {
            _adapter.SendMessage((string)o);
        }
        #endregion
    }
}
