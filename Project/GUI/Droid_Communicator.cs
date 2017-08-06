using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Droid_communication
{
    public partial class Droid_Communicator : Form
    {
        #region Attribute
        private Ribbon _ribbon;
        private Interface_slack _intSlack;
        private RibbonTab _tab;

        private string _clientId = "29216308806.33597466784";
        private string _clientSecret = "bc4a3e7d1df9ac28f4dbfc9ee2e0c909";
        private string _hookUrl = "https://hooks.slack.com/services/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";
        #endregion

        #region Properties
        public Interface_slack InterfaceSlack
        {
            get { return _intSlack; }
            set { _intSlack = value; }
        }
        #endregion

        #region Constructor
        public Droid_Communicator()
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


            //RunTestHook();
            InitRibbon();
        }
        private void InitRibbon()
        {
            _ribbon = new Ribbon();
            _ribbon.Height = 150;
            _ribbon.ThemeColor = RibbonTheme.Black;
            _ribbon.OrbDropDown.Width = 150;
            _ribbon.OrbStyle = RibbonOrbStyle.Office_2013;
            _ribbon.OrbText = GetText.Text("File");
            _ribbon.QuickAccessToolbar.MenuButtonVisible = false;
            _ribbon.QuickAccessToolbar.Visible = false;
            _ribbon.QuickAccessToolbar.MinSizeMode = RibbonElementSizeMode.Compact;
            _ribbon.Dock = DockStyle.None;
            _ribbon.Top = -25;
            _ribbon.Left = 0;
            _ribbon.Width = this.Width;
            _ribbon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));

            _tab = new RibbonTab();
            _tab.Panels.Add(_intSlack.Panel);

            _ribbon.Tabs.Add(_tab);

            _ribbon.OrbDropDown.Width = 700;
            this.Controls.Add(_ribbon);
        }

        private void RunTestHook()
        {
            _intSlack = new Interface_slack(_hookUrl);
            _intSlack.ClientId = _clientId;
            _intSlack.ClientSecret = _clientSecret;
            _intSlack.PostMessage("Hello world specific channel");
        }
        #endregion

        #region Event
        #endregion
    }
}
