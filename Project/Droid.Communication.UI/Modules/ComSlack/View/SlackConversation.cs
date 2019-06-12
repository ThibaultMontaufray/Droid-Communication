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
    public partial class SlackConversationView : PanelScrollableCustom
    {
        #region Attributes
        private SlackConversation _currentConversation;
        private SlackAdapter _adapter;
        #endregion

        #region Properties
        public SlackAdapter Adapter
        {
            get { return _adapter; }
            set { _adapter = value; }
        }
        public SlackConversation CurrentConversation
        {
            get { return _currentConversation; }
            set { _currentConversation = value; }
        }
        #endregion

        #region Constructor
        public SlackConversationView()
        {
            InitializeComponent();
            this.BackColor = Color.WhiteSmoke;
        }
        public SlackConversationView(SlackAdapter adapter)
        {
            _adapter = adapter;
            InitializeComponent();
            this.BackColor = Color.WhiteSmoke;
        }
        #endregion

        #region Methods public
        public void LoadConversation(string conversation)
        {
            _adapter.OnMessagesUpdated += _slackAdapter_OnMessagesUpdated;
            _currentConversation = ConversationControler.History(_adapter, conversation);
            this.Controls.Clear();
            this.BackColor = Color.WhiteSmoke;

            RefreshData();
            BuildMessagesInterface();
        }
        public void RefreshData()
        {
            this.Width = 10;
            this.Height = 10;
            _adapter.CurrentMessages.Clear();
            SlackMessage slackMessage;
            if (_currentConversation != null)
            {
                foreach (var item in _currentConversation.Messages.OrderByDescending(m => m.Ts).Take(25))
                {
                    slackMessage = new SlackMessage();
                    slackMessage.LoadMessage(_adapter, item);
                    slackMessage.Dock = DockStyle.Top;
                    //this.Controls.Add(slackMessage);
                    _adapter.CurrentMessages.Add(slackMessage);
                }
            }
        }
        #endregion

        #region Methods private
        private void BuildMessagesInterface()
        {
            foreach (SlackMessage control in _adapter.CurrentMessages)
            {
                this.Controls.Add(control);
            }
            if (_adapter.CurrentMessages.Count > 0)
            {
                _adapter.CurrentMessages[0].Select();
                this.ScrollToControl(_adapter.CurrentMessages[0]);
            }
        }
        private void ParseMessage(Message msg)
        {
            if (msg.Channel == _currentConversation.Messages.FirstOrDefault().Channel)
            {
                _currentConversation.Messages.Add(msg);

                SlackMessage slackMessage = new SlackMessage();
                slackMessage.LoadMessage(_adapter, msg);
                slackMessage.Dock = DockStyle.Top;
                this.Controls.Add(slackMessage);
                _adapter.CurrentMessages.Add(slackMessage);
            }
        }
        #endregion

        #region Event
        private void _slackAdapter_OnMessagesUpdated(object o)
        {
            ParseMessage((Message)o);
        }
        #endregion
    }
}
