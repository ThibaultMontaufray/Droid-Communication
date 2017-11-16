namespace Droid_communication
{
    using System.Windows.Forms;
    using System;
    using System.Collections.Generic;
    using System.IO;

    public partial class DemoLync : Form
    {
        #region Attribute
        private bool _movable = false;
        private int _offsetX = 0;
        private int _offsetY = 0;
        private LyncInterface _lynqInterface;
        private System.Windows.Forms.Timer _timer;
        //private bool _timerLaunched = false;

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonMap;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonMaximize;
        private System.Windows.Forms.Button buttonMinimize;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox textBoxOutput;
        private System.Windows.Forms.TextBox textBoxInput;
        private System.Windows.Forms.Panel panelWatcher;
        private System.Windows.Forms.Button buttonMore;
        private MapPanel mapPanel1;
        private System.ComponentModel.IContainer components = null;
        #endregion

        #region Constructor
        public DemoLync()
        {
            _lynqInterface = new LyncInterface();
            _lynqInterface.MessageReceived += new LyncInterfaceEventHandlerConversation(_lynqInterface_MessageReceived);

            //Droid_TOBI.TobiInterface.MessageUpdated += new Droid_TOBI.TobiInterfaceEventHandler(TobiInterface_MessageUpdated);

            _timer = new System.Windows.Forms.Timer();
            _timer.Interval = 10000;
            _timer.Tick += new EventHandler(_timer_Tick);

            InitializeComponent();
            Init();
            textBoxInput.Focus();
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
        private void Init()
        {
            labelTitle.Text = "Lync";
            labelTitle.MouseDown += new MouseEventHandler(Lync_MouseDown);
            labelTitle.MouseUp += new MouseEventHandler(Lync_MouseUp);
            labelTitle.MouseMove += new MouseEventHandler(Lync_MouseMove);

            LoadLyncData();
        }
        private void LoadLyncData()
        {
            labelStatus.Text = _lynqInterface.Client.State.ToString();
            labelName.Text = _lynqInterface.Client.Uri;
        }
        private void addTextUser(string text)
        {
            Log("YOU  : " + text);
            textBoxOutput.Text += "YOU  : " + text;
            DoAction(text);

            textBoxOutput.SelectionStart = textBoxOutput.Text.Length;
            textBoxOutput.ScrollToCaret();
        }
        private void DoAction(string text)
        {
            //Droid_TOBI.TobiInterface.Ask(text);
        }
        private void _timer_Tick(object sender, EventArgs e)
        {
            _timer.Stop();
            _lynqInterface.SendMessage("[TOBI] PAUSE !", "usermail@mail.mail");
            _timer.Start();
        }
        private void TobiInterface_MessageUpdated(string message)
        {
            string answer = string.Empty;
            if (!string.IsNullOrEmpty(message)) answer = "TOBI : " + message + "\r\n";
            else answer = "TOBI : Mes réponses sont limités, vous devez me poser la bonne question.\r\n";

            textBoxOutput.Text += answer;
            Log(answer);

            this.Refresh();
        }
        private void Log(string text)
        {
            string file = "transcript.log";
            using (StreamWriter sw = new StreamWriter(file, true))
            {
                sw.Write(DateTime.Now.ToString("yyyyMMdd-hhmmss") + " : " + text);
            }
        }
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DemoLync));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.textBoxOutput = new System.Windows.Forms.TextBox();
            this.textBoxInput = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.labelStatus = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonMap = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonMaximize = new System.Windows.Forms.Button();
            this.buttonMinimize = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panelWatcher = new System.Windows.Forms.Panel();
            this.mapPanel1 = new Droid_communication.MapPanel();
            this.buttonMore = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelWatcher.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Location = new System.Drawing.Point(12, 87);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Panel1.Controls.Add(this.textBoxOutput);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Panel2.Controls.Add(this.textBoxInput);
            this.splitContainer1.Size = new System.Drawing.Size(354, 271);
            this.splitContainer1.SplitterDistance = 221;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 0;
            // 
            // textBoxOutput
            // 
            this.textBoxOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxOutput.Location = new System.Drawing.Point(0, 0);
            this.textBoxOutput.Multiline = true;
            this.textBoxOutput.Name = "textBoxOutput";
            this.textBoxOutput.ReadOnly = true;
            this.textBoxOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxOutput.Size = new System.Drawing.Size(352, 219);
            this.textBoxOutput.TabIndex = 0;
            // 
            // textBoxInput
            // 
            this.textBoxInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxInput.Location = new System.Drawing.Point(0, 0);
            this.textBoxInput.Multiline = true;
            this.textBoxInput.Name = "textBoxInput";
            this.textBoxInput.Size = new System.Drawing.Size(352, 47);
            this.textBoxInput.TabIndex = 1;
            this.textBoxInput.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxInput_KeyUp);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(Tools4Libraries.Resources.ResourceIconSet32Default.user_silhouette));
            this.pictureBox1.Location = new System.Drawing.Point(12, 29);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(58, 52);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.BackColor = System.Drawing.Color.Transparent;
            this.labelTitle.ForeColor = System.Drawing.Color.Gray;
            this.labelTitle.Location = new System.Drawing.Point(12, 9);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(25, 13);
            this.labelTitle.TabIndex = 2;
            this.labelTitle.Text = "___";
            // 
            // labelName
            // 
            this.labelName.BackColor = System.Drawing.Color.Transparent;
            this.labelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelName.Location = new System.Drawing.Point(76, 40);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(311, 23);
            this.labelName.TabIndex = 3;
            this.labelName.Text = "________________";
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.BackColor = System.Drawing.Color.Transparent;
            this.labelStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelStatus.Location = new System.Drawing.Point(76, 63);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(50, 13);
            this.labelStatus.TabIndex = 4;
            this.labelStatus.Text = "Available";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImage = ((System.Drawing.Image)(Tools4Libraries.Resources.ResourceIconSet32Default.email));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(12, 364);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(45, 39);
            this.button1.TabIndex = 5;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // buttonMap
            // 
            this.buttonMap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonMap.BackColor = System.Drawing.Color.Transparent;
            this.buttonMap.BackgroundImage = ((System.Drawing.Image)(Tools4Libraries.Resources.ResourceIconSet32Default.map));
            this.buttonMap.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonMap.FlatAppearance.BorderSize = 0;
            this.buttonMap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMap.Location = new System.Drawing.Point(63, 364);
            this.buttonMap.Name = "buttonMap";
            this.buttonMap.Size = new System.Drawing.Size(45, 39);
            this.buttonMap.TabIndex = 6;
            this.buttonMap.UseVisualStyleBackColor = false;
            this.buttonMap.Click += new System.EventHandler(this.buttonMap_Click);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button3.BackColor = System.Drawing.Color.Transparent;
            this.button3.BackgroundImage = ((System.Drawing.Image)(Tools4Libraries.Resources.ResourceIconSet16Default.Plant));
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(114, 364);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(45, 39);
            this.button3.TabIndex = 7;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Visible = false;
            // 
            // buttonClose
            // 
            this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClose.BackgroundImage = ((System.Drawing.Image)(Tools4Libraries.Resources.ResourceIconSet16Default.cross));
            this.buttonClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonClose.FlatAppearance.BorderSize = 0;
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClose.Location = new System.Drawing.Point(350, 12);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(16, 16);
            this.buttonClose.TabIndex = 9;
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonMaximize
            // 
            this.buttonMaximize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonMaximize.BackgroundImage = ((System.Drawing.Image)(Tools4Libraries.Resources.ResourceIconSet16Default.monitor));
            this.buttonMaximize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonMaximize.FlatAppearance.BorderSize = 0;
            this.buttonMaximize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMaximize.Location = new System.Drawing.Point(328, 12);
            this.buttonMaximize.Name = "buttonMaximize";
            this.buttonMaximize.Size = new System.Drawing.Size(16, 16);
            this.buttonMaximize.TabIndex = 10;
            this.buttonMaximize.UseVisualStyleBackColor = true;
            // 
            // buttonMinimize
            // 
            this.buttonMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonMinimize.BackgroundImage = ((System.Drawing.Image)(Tools4Libraries.Resources.ResourceIconSet16Default.hrule));
            this.buttonMinimize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonMinimize.FlatAppearance.BorderSize = 0;
            this.buttonMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMinimize.Location = new System.Drawing.Point(306, 12);
            this.buttonMinimize.Name = "buttonMinimize";
            this.buttonMinimize.Size = new System.Drawing.Size(16, 16);
            this.buttonMinimize.TabIndex = 11;
            this.buttonMinimize.UseVisualStyleBackColor = true;
            this.buttonMinimize.Click += new System.EventHandler(this.buttonMinimize_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(198)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1, 416);
            this.panel1.TabIndex = 12;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(198)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(377, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1, 416);
            this.panel2.TabIndex = 13;
            // 
            // panelWatcher
            // 
            this.panelWatcher.BackColor = System.Drawing.Color.White;
            this.panelWatcher.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelWatcher.Controls.Add(this.mapPanel1);
            this.panelWatcher.Location = new System.Drawing.Point(12, 87);
            this.panelWatcher.Name = "panelWatcher";
            this.panelWatcher.Size = new System.Drawing.Size(354, 271);
            this.panelWatcher.TabIndex = 14;
            this.panelWatcher.Visible = false;
            // 
            // mapPanel1
            // 
            this.mapPanel1.BackColor = System.Drawing.Color.Silver;
            //this.mapPanel1.BackgroundImage = ((System.Drawing.Image)(Tools4Libraries.Resources.ResourceIconSet16Default.map_go));
            // here you can put the view of your desk to see person that are present
            this.mapPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.mapPanel1.Location = new System.Drawing.Point(0, -1);
            this.mapPanel1.LynqInterface = null;
            this.mapPanel1.Name = "mapPanel1";
            this.mapPanel1.Size = new System.Drawing.Size(346, 268);
            this.mapPanel1.TabIndex = 0;
            this.mapPanel1.Theme = 0;
            // 
            // buttonMore
            // 
            this.buttonMore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonMore.BackColor = System.Drawing.Color.Transparent;
            this.buttonMore.BackgroundImage = ((System.Drawing.Image)(Tools4Libraries.Resources.ResourceIconSet32Default.magnifier));
            this.buttonMore.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonMore.FlatAppearance.BorderSize = 0;
            this.buttonMore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMore.Location = new System.Drawing.Point(337, 369);
            this.buttonMore.Name = "buttonMore";
            this.buttonMore.Size = new System.Drawing.Size(28, 28);
            this.buttonMore.TabIndex = 15;
            this.buttonMore.UseVisualStyleBackColor = false;
            // 
            // LyncForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(378, 416);
            this.Controls.Add(this.buttonMore);
            this.Controls.Add(this.panelWatcher);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buttonMinimize);
            this.Controls.Add(this.buttonMaximize);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.buttonMap);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LyncForm";
            this.Text = "Lync";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Lync_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Lync_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Lync_MouseUp);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelWatcher.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        #region Event
        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void buttonMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void Lync_MouseDown(object sender, MouseEventArgs e)
        {
            _movable = true;
            _offsetX = e.X;
            _offsetY = e.Y;
        }
        private void Lync_MouseUp(object sender, MouseEventArgs e)
        {
            _movable = false;
        }
        private void Lync_MouseMove(object sender, MouseEventArgs e)
        {
            if (_movable)
            {
                this.Left -= _offsetX - e.X;
                this.Top -= _offsetY - e.Y;
            }
        }
        private void textBoxInput_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(Keys.Enter))
            {
                addTextUser(this.textBoxInput.Text);
                this.textBoxInput.Text = string.Empty;
            }
        }
        private Dictionary<string, int> GetUserStatus()
        {
            Dictionary<string, int> dico = new Dictionary<string, int>();

            //_lynqInterface.GetStatus("prenom nom");

            dico = _lynqInterface.Dico;

            return dico;
        }
        private void buttonMap_Click(object sender, EventArgs e)
        {
            if (splitContainer1.Visible)
            {
                mapPanel1.LynqInterface = _lynqInterface;
                mapPanel1.LoadUsers();
                mapPanel1.Visible = true;
                splitContainer1.Visible = false;
                panelWatcher.Visible = true;
            }
            else
            {
                mapPanel1.Visible = false;
                splitContainer1.Visible = true;
                panelWatcher.Visible = false;
            }
        }
        private void _lynqInterface_MessageReceived(string message)
        {
            textBoxOutput.BeginInvoke(new Action(() =>
            {
                try
                {
                    textBoxOutput.Text += message + "\r\n";
                }
                catch (Exception exp)
                {
                    Console.WriteLine("=> error : " + exp.Message);
                }
            }));
        }
        #endregion
    }
}
