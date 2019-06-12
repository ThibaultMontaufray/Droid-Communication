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

namespace Droid.Communication.Modules.ComSlack.View
{
    public partial class SlackContact : UserControlCustom
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
        public SlackContact()
        {
            InitializeComponent();
        }
        public SlackContact(SlackAdapter adapter)
        {
            _adapter = adapter;
            InitializeComponent();
        }
        #endregion

        #region Methods public
        #endregion

        #region Methods private
        #endregion

        #region Event
        #endregion
    }
}
