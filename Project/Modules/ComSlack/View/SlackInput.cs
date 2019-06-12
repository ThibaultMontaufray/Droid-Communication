using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Droid.Communication
{
    public delegate void SlackInputEventHandler(object o);
    public partial class SlackInput : UserControl
    {
        #region Attributes
        public event SlackInputEventHandler OnMessageSendingRequest;
        private SlackAdapter _slackAdapter;
        #endregion

        #region Properties
        public SlackAdapter Adapter
        {
            get { return _slackAdapter; }
            set { _slackAdapter = value; }
        }
        #endregion

        #region Constructor
        public SlackInput()
        {
            InitializeComponent();
        }
        #endregion

        #region Methods public
        #endregion

        #region Methods private
        private void SendMessage()
        {
            if (_slackAdapter == null) { return; }
            string finalText = _textBoxInput.Text;
            foreach (Member user in _slackAdapter.Users)
            {
                if (finalText.Contains("@" + user.Name))
                {
                    finalText = finalText.Replace("@" + user.Name, string.Format("<@{0}>", user.Id));
                }
            }
            if (finalText.Contains("@chaîne")) { finalText = finalText.Replace("@chaîne", "<@chaîne>"); }

            OnMessageSendingRequest?.Invoke(finalText);
            _textBoxInput.Clear();
        }
        #endregion

        #region Event
        private void buttonSend_Click(object sender, EventArgs e)
        {
            SendMessage();
        }
        private void _textBoxInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r' || e.KeyChar == '\n')
            {
                SendMessage();
            }
        }
        #endregion
    }
}
