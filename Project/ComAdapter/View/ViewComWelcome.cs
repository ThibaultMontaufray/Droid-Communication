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

namespace Droid.Communication.ComAdapter.View
{
    public partial class ViewComWelcome : UserControlCustom
    {
        #region Attributes
        #endregion

        #region Properties
        #endregion

        #region Constructor
        public ViewComWelcome()
        {
            InitializeComponent();
            this.Refresh();
        }
        public ViewComWelcome(InterfaceCommunication intCom)
        {
            InitializeComponent();
            this.Refresh();

        }
        #endregion

        #region Methods public
        public override void RefreshData()
        {

        }
        public override void ChangeLanguage()
        {
            base.ChangeLanguage();
        }
        #endregion

        #region Methods private
        #endregion

        #region Event
        #endregion

        private void ViewWelcomeCom_Load(object sender, EventArgs e)
        {

            SuspendLayout();
            //hexaFacebook1.BringToFront();
            //hexaLync1.BringToFront();
            //hexaMail1.BringToFront();
            //hexaNewCom1.BringToFront();

            hexaLync1.Parent = hexaNewCom1;
            hexaFacebook1.Parent = hexaNewCom1;
            hexaMail1.Parent = hexaFacebook1;

            ResumeLayout();
        }
    }
}
