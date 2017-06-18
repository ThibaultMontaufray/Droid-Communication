using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Droid_communication
{
    public partial class MapPanel : UserControl
    {
        #region Attribute
        private LyncInterface _lynqInterface;
        private List<string> _users;
        private Timer _timer;
        private int _theme = 0;

        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.PictureBox pictureBoxHOA;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBoxCLU;
        private System.Windows.Forms.PictureBox pictureBoxVDD;
        private System.Windows.Forms.PictureBox pictureBoxJPT;
        private System.Windows.Forms.PictureBox pictureBoxCMA;
        private System.Windows.Forms.PictureBox pictureBoxJCH;
        private System.Windows.Forms.PictureBox pictureBoxWRA;
        private System.Windows.Forms.PictureBox pictureBoxEOB;
        private System.Windows.Forms.PictureBox pictureBoxNBE;
        private System.Windows.Forms.PictureBox pictureBox10;
        private System.Windows.Forms.PictureBox pictureBox12;
        private System.Windows.Forms.PictureBox pictureBoxTMO;
        private System.Windows.Forms.PictureBox pictureBoxCOL;
        private System.Windows.Forms.PictureBox pictureBox15;
        private System.Windows.Forms.PictureBox pictureBox16;
        private System.Windows.Forms.PictureBox pictureBoxCDI;
        private System.Windows.Forms.PictureBox pictureBoxGCO;
        private System.Windows.Forms.PictureBox pictureBoxPNG;
        private System.Windows.Forms.PictureBox pictureBoxSDE;
        private System.Windows.Forms.PictureBox pictureBox21;
        private System.Windows.Forms.PictureBox pictureBox22;
        private System.Windows.Forms.PictureBox pictureBoxSGH;
        private System.Windows.Forms.PictureBox pictureBoxTAK;
        private System.Windows.Forms.ImageList imageListTheme;
        private System.Windows.Forms.ImageList imageListMap;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.ProgressBar progressBar;
        #endregion

        #region Properties
        public LyncInterface LynqInterface
        {
            get { return _lynqInterface; }
            set
            {
                _lynqInterface = value;
                if (_lynqInterface != null) _lynqInterface.StatusChanged += new LyncInterfaceEventHandler(_lynqInterface_StatusChanged);
            }
        }
        public int Theme
        {
            get { return _theme; }
            set { _theme = value; }
        }
        #endregion

        #region Constructor
        public MapPanel()
        {
            _lynqInterface = new LyncInterface();
            LoadUsersList();
            InitializeComponent();
            LoadUsers();
            _timer = new Timer();
            _timer.Interval = 10;
            _timer.Tick += new EventHandler(_timer_Tick);
            this.VisibleChanged += new EventHandler(MapPanel_VisibleChanged);
        }

        private void MapPanel_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible) _timer.Start();
            else _timer.Stop();
        }
        #endregion

        #region Methods public
        public void LoadUsers()
        {
            if (_lynqInterface != null) _lynqInterface.StatusChanged -= new LyncInterfaceEventHandler(_lynqInterface_StatusChanged);
            foreach (var item in _users)
            {
                try
                {
                    if (_lynqInterface != null)
                    {
                        _lynqInterface.GetStatus(item);
                        _lynqInterface.GetUserDetails(item);
                    }
                }
                catch (Exception exp)
                {
                    Console.WriteLine(exp.Message);
                }
            }
            if (_lynqInterface != null) _lynqInterface.StatusChanged += new LyncInterfaceEventHandler(_lynqInterface_StatusChanged);
        }
        #endregion

        #region Methods protected
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        #endregion

        #region Methods private
        private void LoadUsersList()
        {
            _users = new List<string>();
            _users.Add("complete name ........");

        }
        private void _lynqInterface_StatusChanged()
        {
            try
            {
                this.BeginInvoke(new Action(() =>
                {
                    try
                    {
                        int imgIndex = 0;
                        if (_lynqInterface == null) return;
                        foreach (var item in _lynqInterface.Dico)
                        {
                            if (item.Value == 3500) imgIndex = 4;
                            else if (item.Value == 15500) imgIndex = 1;
                            else if (item.Value == 6500) imgIndex = 3;
                            else if (item.Value == 5000) imgIndex = 2;
                            else imgIndex = 0;

                            switch (item.Key)
                            {
                                case "complete name ........": UpdatePictureBox(pictureBoxHOA, imgIndex, item.Key); break; // associated people
                            }
                        }
                    }
                    catch (Exception)
                    {
                    }
                }));
                this.Invalidate();
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MapPanel));
            this.pictureBoxHOA = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBoxCLU = new System.Windows.Forms.PictureBox();
            this.pictureBoxVDD = new System.Windows.Forms.PictureBox();
            this.pictureBoxJPT = new System.Windows.Forms.PictureBox();
            this.pictureBoxCMA = new System.Windows.Forms.PictureBox();
            this.pictureBoxJCH = new System.Windows.Forms.PictureBox();
            this.pictureBoxWRA = new System.Windows.Forms.PictureBox();
            this.pictureBoxEOB = new System.Windows.Forms.PictureBox();
            this.pictureBoxNBE = new System.Windows.Forms.PictureBox();
            this.pictureBox10 = new System.Windows.Forms.PictureBox();
            this.pictureBox12 = new System.Windows.Forms.PictureBox();
            this.pictureBoxTMO = new System.Windows.Forms.PictureBox();
            this.pictureBoxCOL = new System.Windows.Forms.PictureBox();
            this.pictureBox15 = new System.Windows.Forms.PictureBox();
            this.pictureBox16 = new System.Windows.Forms.PictureBox();
            this.pictureBoxCDI = new System.Windows.Forms.PictureBox();
            this.pictureBoxGCO = new System.Windows.Forms.PictureBox();
            this.pictureBoxPNG = new System.Windows.Forms.PictureBox();
            this.pictureBoxSDE = new System.Windows.Forms.PictureBox();
            this.pictureBox21 = new System.Windows.Forms.PictureBox();
            this.pictureBox22 = new System.Windows.Forms.PictureBox();
            this.pictureBoxSGH = new System.Windows.Forms.PictureBox();
            this.pictureBoxTAK = new System.Windows.Forms.PictureBox();
            this.imageListTheme = new System.Windows.Forms.ImageList(this.components);
            this.imageListMap = new System.Windows.Forms.ImageList(this.components);
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHOA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCLU)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxVDD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxJPT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCMA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxJCH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWRA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEOB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNBE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTMO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCOL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCDI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGCO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPNG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSDE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSGH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTAK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxHOA
            // 
            this.pictureBoxHOA.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxHOA.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxHOA.Location = new System.Drawing.Point(215, 222);
            this.pictureBoxHOA.Name = "pictureBoxHOA";
            this.pictureBoxHOA.Size = new System.Drawing.Size(16, 16);
            this.pictureBoxHOA.TabIndex = 10;
            this.pictureBoxHOA.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(226, 195);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(16, 16);
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBoxCLU
            // 
            this.pictureBoxCLU.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxCLU.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxCLU.Location = new System.Drawing.Point(182, 202);
            this.pictureBoxCLU.Name = "pictureBoxCLU";
            this.pictureBoxCLU.Size = new System.Drawing.Size(16, 16);
            this.pictureBoxCLU.TabIndex = 12;
            this.pictureBoxCLU.TabStop = false;
            // 
            // pictureBoxVDD
            // 
            this.pictureBoxVDD.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxVDD.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxVDD.Location = new System.Drawing.Point(193, 176);
            this.pictureBoxVDD.Name = "pictureBoxVDD";
            this.pictureBoxVDD.Size = new System.Drawing.Size(16, 16);
            this.pictureBoxVDD.TabIndex = 13;
            this.pictureBoxVDD.TabStop = false;
            // 
            // pictureBoxJPT
            // 
            this.pictureBoxJPT.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxJPT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxJPT.Location = new System.Drawing.Point(159, 203);
            this.pictureBoxJPT.Name = "pictureBoxJPT";
            this.pictureBoxJPT.Size = new System.Drawing.Size(16, 16);
            this.pictureBoxJPT.TabIndex = 14;
            this.pictureBoxJPT.TabStop = false;
            // 
            // pictureBoxCMA
            // 
            this.pictureBoxCMA.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxCMA.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxCMA.Location = new System.Drawing.Point(170, 176);
            this.pictureBoxCMA.Name = "pictureBoxCMA";
            this.pictureBoxCMA.Size = new System.Drawing.Size(16, 16);
            this.pictureBoxCMA.TabIndex = 15;
            this.pictureBoxCMA.TabStop = false;
            // 
            // pictureBoxJCH
            // 
            this.pictureBoxJCH.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxJCH.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxJCH.Location = new System.Drawing.Point(124, 183);
            this.pictureBoxJCH.Name = "pictureBoxJCH";
            this.pictureBoxJCH.Size = new System.Drawing.Size(16, 16);
            this.pictureBoxJCH.TabIndex = 16;
            this.pictureBoxJCH.TabStop = false;
            // 
            // pictureBoxWRA
            // 
            this.pictureBoxWRA.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxWRA.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxWRA.Location = new System.Drawing.Point(136, 157);
            this.pictureBoxWRA.Name = "pictureBoxWRA";
            this.pictureBoxWRA.Size = new System.Drawing.Size(16, 16);
            this.pictureBoxWRA.TabIndex = 17;
            this.pictureBoxWRA.TabStop = false;
            // 
            // pictureBoxEOB
            // 
            this.pictureBoxEOB.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxEOB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxEOB.Location = new System.Drawing.Point(86, 141);
            this.pictureBoxEOB.Name = "pictureBoxEOB";
            this.pictureBoxEOB.Size = new System.Drawing.Size(16, 16);
            this.pictureBoxEOB.TabIndex = 18;
            this.pictureBoxEOB.TabStop = false;
            // 
            // pictureBoxNBE
            // 
            this.pictureBoxNBE.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxNBE.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxNBE.Location = new System.Drawing.Point(72, 117);
            this.pictureBoxNBE.Name = "pictureBoxNBE";
            this.pictureBoxNBE.Size = new System.Drawing.Size(16, 16);
            this.pictureBoxNBE.TabIndex = 19;
            this.pictureBoxNBE.TabStop = false;
            this.pictureBoxNBE.Tag = "";
            // 
            // pictureBox10
            // 
            this.pictureBox10.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox10.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox10.Location = new System.Drawing.Point(119, 124);
            this.pictureBox10.Name = "pictureBox10";
            this.pictureBox10.Size = new System.Drawing.Size(16, 16);
            this.pictureBox10.TabIndex = 20;
            this.pictureBox10.TabStop = false;
            // 
            // pictureBox12
            // 
            this.pictureBox12.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox12.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox12.Location = new System.Drawing.Point(106, 100);
            this.pictureBox12.Name = "pictureBox12";
            this.pictureBox12.Size = new System.Drawing.Size(16, 16);
            this.pictureBox12.TabIndex = 21;
            this.pictureBox12.TabStop = false;
            // 
            // pictureBoxTMO
            // 
            this.pictureBoxTMO.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxTMO.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxTMO.Location = new System.Drawing.Point(158, 70);
            this.pictureBoxTMO.Name = "pictureBoxTMO";
            this.pictureBoxTMO.Size = new System.Drawing.Size(16, 16);
            this.pictureBoxTMO.TabIndex = 25;
            this.pictureBoxTMO.TabStop = false;
            // 
            // pictureBoxCOL
            // 
            this.pictureBoxCOL.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxCOL.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxCOL.Location = new System.Drawing.Point(171, 94);
            this.pictureBoxCOL.Name = "pictureBoxCOL";
            this.pictureBoxCOL.Size = new System.Drawing.Size(16, 16);
            this.pictureBoxCOL.TabIndex = 24;
            this.pictureBoxCOL.TabStop = false;
            // 
            // pictureBox15
            // 
            this.pictureBox15.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox15.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox15.Location = new System.Drawing.Point(124, 88);
            this.pictureBox15.Name = "pictureBox15";
            this.pictureBox15.Size = new System.Drawing.Size(16, 16);
            this.pictureBox15.TabIndex = 23;
            this.pictureBox15.TabStop = false;
            // 
            // pictureBox16
            // 
            this.pictureBox16.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox16.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox16.Location = new System.Drawing.Point(137, 111);
            this.pictureBox16.Name = "pictureBox16";
            this.pictureBox16.Size = new System.Drawing.Size(16, 16);
            this.pictureBox16.TabIndex = 22;
            this.pictureBox16.TabStop = false;
            // 
            // pictureBoxCDI
            // 
            this.pictureBoxCDI.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxCDI.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxCDI.Location = new System.Drawing.Point(222, 32);
            this.pictureBoxCDI.Name = "pictureBoxCDI";
            this.pictureBoxCDI.Size = new System.Drawing.Size(16, 16);
            this.pictureBoxCDI.TabIndex = 29;
            this.pictureBoxCDI.TabStop = false;
            // 
            // pictureBoxGCO
            // 
            this.pictureBoxGCO.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxGCO.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxGCO.Location = new System.Drawing.Point(234, 57);
            this.pictureBoxGCO.Name = "pictureBoxGCO";
            this.pictureBoxGCO.Size = new System.Drawing.Size(16, 16);
            this.pictureBoxGCO.TabIndex = 28;
            this.pictureBoxGCO.TabStop = false;
            // 
            // pictureBoxPNG
            // 
            this.pictureBoxPNG.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxPNG.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxPNG.Location = new System.Drawing.Point(189, 53);
            this.pictureBoxPNG.Name = "pictureBoxPNG";
            this.pictureBoxPNG.Size = new System.Drawing.Size(16, 16);
            this.pictureBoxPNG.TabIndex = 27;
            this.pictureBoxPNG.TabStop = false;
            // 
            // pictureBoxSDE
            // 
            this.pictureBoxSDE.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxSDE.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxSDE.Location = new System.Drawing.Point(202, 78);
            this.pictureBoxSDE.Name = "pictureBoxSDE";
            this.pictureBoxSDE.Size = new System.Drawing.Size(16, 16);
            this.pictureBoxSDE.TabIndex = 26;
            this.pictureBoxSDE.TabStop = false;
            // 
            // pictureBox21
            // 
            this.pictureBox21.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox21.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox21.Location = new System.Drawing.Point(277, 6);
            this.pictureBox21.Name = "pictureBox21";
            this.pictureBox21.Size = new System.Drawing.Size(16, 16);
            this.pictureBox21.TabIndex = 33;
            this.pictureBox21.TabStop = false;
            // 
            // pictureBox22
            // 
            this.pictureBox22.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox22.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox22.Location = new System.Drawing.Point(288, 29);
            this.pictureBox22.Name = "pictureBox22";
            this.pictureBox22.Size = new System.Drawing.Size(16, 16);
            this.pictureBox22.TabIndex = 32;
            this.pictureBox22.TabStop = false;
            // 
            // pictureBoxSGH
            // 
            this.pictureBoxSGH.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxSGH.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxSGH.Location = new System.Drawing.Point(242, 24);
            this.pictureBoxSGH.Name = "pictureBoxSGH";
            this.pictureBoxSGH.Size = new System.Drawing.Size(16, 16);
            this.pictureBoxSGH.TabIndex = 31;
            this.pictureBoxSGH.TabStop = false;
            // 
            // pictureBoxTAK
            // 
            this.pictureBoxTAK.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxTAK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxTAK.Location = new System.Drawing.Point(253, 44);
            this.pictureBoxTAK.Name = "pictureBoxTAK";
            this.pictureBoxTAK.Size = new System.Drawing.Size(16, 16);
            this.pictureBoxTAK.TabIndex = 30;
            this.pictureBoxTAK.TabStop = false;
            // 
            // imageListTheme
            // 
            this.imageListTheme.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListTheme.Images.Add("white", Tools4Libraries.Resources.ResourceIconSet16Default.bullet_yellow);
            this.imageListTheme.Images.Add("yellow", Tools4Libraries.Resources.ResourceIconSet16Default.bullet_yellow);
            this.imageListTheme.Images.Add("orange", Tools4Libraries.Resources.ResourceIconSet16Default.bullet_purple);
            this.imageListTheme.Images.Add("red", Tools4Libraries.Resources.ResourceIconSet16Default.bullet_red);
            this.imageListTheme.Images.Add("green", Tools4Libraries.Resources.ResourceIconSet16Default.bullet_green);
            this.imageListTheme.Images.Add("blue", Tools4Libraries.Resources.ResourceIconSet16Default.bullet_blue);
            this.imageListTheme.Images.Add("status_offline", Tools4Libraries.Resources.ResourceIconSet16Default.status_offline);
            this.imageListTheme.Images.Add("status_online", Tools4Libraries.Resources.ResourceIconSet16Default.status_online);
            this.imageListTheme.Images.Add("status_away", Tools4Libraries.Resources.ResourceIconSet16Default.status_away);
            this.imageListTheme.Images.Add("status_busy", Tools4Libraries.Resources.ResourceIconSet16Default.status_busy);
            // 
            // imageListMap
            // 
            this.imageListMap.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListMap.Images.Add("black", Tools4Libraries.Resources.ResourceIconSet16Default.bullet_purple);
            this.imageListMap.Images.Add("white", Tools4Libraries.Resources.ResourceIconSet16Default.bullet_yellow);
            this.imageListMap.Images.Add("black2", Tools4Libraries.Resources.ResourceIconSet16Default.bullet_red);
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox4.Location = new System.Drawing.Point(288, 233);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(16, 16);
            this.pictureBox4.TabIndex = 35;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox3.Location = new System.Drawing.Point(243, 241);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(16, 16);
            this.pictureBox3.TabIndex = 36;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(253, 215);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(16, 16);
            this.pictureBox2.TabIndex = 37;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox7
            // 
            this.pictureBox7.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox7.Location = new System.Drawing.Point(307, 240);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(16, 16);
            this.pictureBox7.TabIndex = 40;
            this.pictureBox7.TabStop = false;
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(0, -1);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(346, 4);
            this.progressBar.TabIndex = 41;
            // 
            // MapPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.pictureBox7);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox21);
            this.Controls.Add(this.pictureBox22);
            this.Controls.Add(this.pictureBoxSGH);
            this.Controls.Add(this.pictureBoxTAK);
            this.Controls.Add(this.pictureBoxCDI);
            this.Controls.Add(this.pictureBoxGCO);
            this.Controls.Add(this.pictureBoxPNG);
            this.Controls.Add(this.pictureBoxSDE);
            this.Controls.Add(this.pictureBoxTMO);
            this.Controls.Add(this.pictureBoxCOL);
            this.Controls.Add(this.pictureBox15);
            this.Controls.Add(this.pictureBox16);
            this.Controls.Add(this.pictureBox12);
            this.Controls.Add(this.pictureBox10);
            this.Controls.Add(this.pictureBoxNBE);
            this.Controls.Add(this.pictureBoxEOB);
            this.Controls.Add(this.pictureBoxWRA);
            this.Controls.Add(this.pictureBoxJCH);
            this.Controls.Add(this.pictureBoxCMA);
            this.Controls.Add(this.pictureBoxJPT);
            this.Controls.Add(this.pictureBoxVDD);
            this.Controls.Add(this.pictureBoxCLU);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBoxHOA);
            this.DoubleBuffered = true;
            this.Name = "MapPanel";
            this.Size = new System.Drawing.Size(346, 268);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHOA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCLU)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxVDD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxJPT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCMA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxJCH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWRA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEOB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNBE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTMO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCOL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCDI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGCO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPNG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSDE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSGH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTAK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        #region Event
        private void UpdatePictureBox(PictureBox pb, int imgIndex, string val)
        {
            if (pb != null)
            {
                if (_theme == 1)
                {
                    switch (imgIndex)
                    {
                        case 0: pb.BackColor = Color.FromArgb(195, 195, 195); break; // white
                        case 1: pb.BackColor = Color.FromArgb(255, 201, 14); break; // yellow
                        case 2: pb.BackColor = Color.FromArgb(255, 201, 14); break; // orange
                        case 3: pb.BackColor = Color.FromArgb(240, 60, 69); break; // red
                        case 4: pb.BackColor = Color.FromArgb(60, 217, 106); break; // green
                    }
                }
                else
                {
                    switch (imgIndex)
                    {
                        //case 0: pb.BackColor = Color.FromArgb(63, 85, 103); break; // white
                        //case 1: pb.BackColor = Color.FromArgb(182, 159, 1); break; // yellow
                        //case 2: pb.BackColor = Color.FromArgb(65, 99, 135); break; // orange
                        //case 3: pb.BackColor = Color.FromArgb(143, 17, 58); break; // red
                        //case 4: pb.BackColor = Color.FromArgb(27, 163, 152); break; // green

                        case 0: pb.BackgroundImage = null; break; // white
                        case 1: pb.BackgroundImage = imageListTheme.Images[imageListTheme.Images.IndexOfKey("status_offline")]; break; // yellow
                        case 2: pb.BackgroundImage = imageListTheme.Images[imageListTheme.Images.IndexOfKey("status_away")]; break; // orange
                        case 3: pb.BackgroundImage = imageListTheme.Images[imageListTheme.Images.IndexOfKey("status_away")]; break; // red
                        case 4: pb.BackgroundImage = imageListTheme.Images[imageListTheme.Images.IndexOfKey("status_online")]; break; // green

                            //case 0: pb.BackColor = Color.FromArgb(82, 98, 95); break; // white
                            //case 1: pb.BackColor = Color.FromArgb(182, 159, 1); break; // yellow
                            //case 2: pb.BackColor = Color.FromArgb(65, 99, 135); break; // orange
                            //case 3: pb.BackColor = Color.FromArgb(143, 17, 58); break; // red
                            //case 4: pb.BackColor = Color.FromArgb(27, 163, 152); break; // green
                    }
                }

                ToolTip tt;
                tt = new ToolTip(); tt.SetToolTip(pb, val);
            }
        }
        private void _timer_Tick(object sender, EventArgs e)
        {
            _timer.Stop();
            if (progressBar.Value < progressBar.Maximum) progressBar.Value++;
            else
            {
                progressBar.Value = progressBar.Maximum;
                progressBar.Refresh();
                LoadUsers();
                progressBar.Value = 0;
            }
            _timer.Start();
        }
        private void buttonChangeTheme_Click(object sender, EventArgs e)
        {
            //_lynqInterface.SendMessage("Go", "cmathieu021615@im.socgen.com");
            //ChangeColor();
        }
        #endregion
    }
}
