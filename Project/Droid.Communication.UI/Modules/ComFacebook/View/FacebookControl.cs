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
    public partial class FacebookControl : UserControl
    {
        #region Attributes
        private FacebookAdapter _facebookInterface;
        #endregion

        #region Properties
        public FacebookAdapter FacebookInterface
        {
            get { return _facebookInterface; }
            set { _facebookInterface = value; }
        }
        #endregion

        #region Constructor
        public FacebookControl()
        {
            InitializeComponent();
            Init();
        }
        #endregion

        #region Methods public
        #endregion

        #region Methods private
        private void Init()
        {
            _facebookInterface = new FacebookAdapter();
        }
        #endregion

        #region Event
        #endregion
    }
}
