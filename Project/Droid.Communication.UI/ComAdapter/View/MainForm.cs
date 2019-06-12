using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tools4Libraries;

namespace Droid.Communication
{
    public partial class MainForm : Form
    {
        #region Attribute
        private readonly string WORKING_DIRECTORY = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Servodroid\Droid-Communication";

        private Ribbon _ribbon;
        private RibbonTab _tab;

        private InterfaceCommunication _intCom;
        #endregion

        #region Properties
        public InterfaceCommunication InterfaceCommunication
        {
            get { return _intCom; }
            set { _intCom = value; }
        }
        #endregion

        #region Constructor
        public MainForm()
        {
            Tools4Libraries.Log.ApplicationAppData = WORKING_DIRECTORY;

            InitializeComponent();
            Init();
        }
        #endregion

        #region Methods public
        #endregion

        #region Methods private
        private void Init()
        {
            _intCom = new InterfaceCommunication(WORKING_DIRECTORY);
            
            InitRibbon();
            InitSheet();
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

            //_tab = new RibbonTab();
            //_tab.Panels.Add(_intSlack.Panel);

            _ribbon.Tabs.Add(_intCom.Tsm);

            _ribbon.OrbDropDown.Width = 700;
            this.Controls.Add(_ribbon);
        }
        private void InitSheet()
        {
            _intCom.Sheet.Dock = DockStyle.None;
            _intCom.Sheet.Top = 100;
            _intCom.Sheet.Left = 0;
            _intCom.Sheet.Width = this.Width;
            _intCom.Sheet.Height = this.Height - 100;
            _intCom.Sheet.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right) | System.Windows.Forms.AnchorStyles.Bottom)));
            this.Controls.Add(_intCom.Sheet);
        }
        #endregion

        #region Event
        #endregion
    }
}
