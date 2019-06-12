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
    public partial class SlackHeader : UserControlCustom
    {
        #region Attributes
        private SlackAdapter _adapter;
        #endregion

        #region Properties
        public SlackAdapter Adapter
        {
            get { return _adapter; }
            set { _adapter = value; }
        }
        #endregion

        #region Constructor
        public SlackHeader()
        {
            InitializeComponent();
        }
        public SlackHeader(SlackAdapter adapter)
        {
            _adapter = adapter;
            InitializeComponent();
        }
        #endregion

        #region Methods public
        public override void RefreshData()
        {
            if (_adapter?.CurrentChannel != null)
            { 
                labelChannel.Text = "#" + _adapter.CurrentChannel.Name;
                labelMembers.Left = labelChannel.Left + labelChannel.Width + 5;
                labelMembers.Text = _adapter.CurrentChannel.Members.Count() + " Members";
            }
            else
            {
                labelChannel.Text = string.Empty;
                labelMembers.Left = labelChannel.Left + labelChannel.Width + 5;
                labelMembers.Text = string.Empty;
            }
        }
        #endregion

        #region Methods private
        #endregion

        #region Event
        #endregion
    }
}
