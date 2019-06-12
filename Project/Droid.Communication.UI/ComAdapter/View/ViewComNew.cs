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
    public partial class ViewComNew : UserControlCustom
    {
        #region Attributes
        #endregion

        #region Properties
        #endregion

        #region Constructor
        public ViewComNew()
        {
            InitializeComponent();
            Init();
        }
        #endregion

        #region Methods public
        public override void RefreshData()
        {
            base.RefreshData();
        }
        public override void ChangeLanguage()
        {
            base.ChangeLanguage();
        }
        #endregion

        #region Methods private
        private void Init()
        {
            comboBoxCom.Items.Clear();

            comboBoxCom.Items.Add("Facebook");
            comboBoxCom.Items.Add("Lync");
            comboBoxCom.Items.Add("Mail");
            comboBoxCom.Items.Add("Slack");

            comboBoxCom.SelectedIndex = 2;
        }
        #endregion

        #region Event
        private void buttonCreate_Click(object sender, EventArgs e)
        {

        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {

        }
        #endregion
    }
}
