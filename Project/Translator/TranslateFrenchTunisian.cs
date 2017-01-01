namespace Droid_Translate
{
    using System.Text.RegularExpressions;
    using System.Windows.Forms;

    public partial class TranslateFrenchTunisian : Form
    {
        #region Attribute
        private string _url = "http://www.arabetunisien.com/traduction/{0}/{1}";
        
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox textBoxIn;
        private System.Windows.Forms.ComboBox comboBoxLang;
        private WebBrowser webBrowser1;
        private System.Windows.Forms.Button button1;
        #endregion

        #region Constructor
        public TranslateFrenchTunisian()
        {
            InitializeComponent();
            comboBoxLang.Text = "fr";
            CheckDll();
        }
        #endregion

        #region Methods public
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
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TranslateFrenchTunisian));
            this.textBoxIn = new System.Windows.Forms.TextBox();
            this.comboBoxLang = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // textBoxIn
            // 
            this.textBoxIn.Location = new System.Drawing.Point(12, 12);
            this.textBoxIn.Multiline = true;
            this.textBoxIn.Name = "textBoxIn";
            this.textBoxIn.Size = new System.Drawing.Size(322, 50);
            this.textBoxIn.TabIndex = 0;
            this.textBoxIn.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxIn_KeyPress);
            // 
            // comboBoxLang
            // 
            this.comboBoxLang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLang.FormattingEnabled = true;
            this.comboBoxLang.Items.AddRange(new object[] {
            "tn",
            "fr"});
            this.comboBoxLang.Location = new System.Drawing.Point(340, 12);
            this.comboBoxLang.Name = "comboBoxLang";
            this.comboBoxLang.Size = new System.Drawing.Size(60, 21);
            this.comboBoxLang.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(340, 39);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(60, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Translate";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(12, 68);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(388, 142);
            this.webBrowser1.TabIndex = 4;
            // 
            // FormWebTraduction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 222);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBoxLang);
            this.Controls.Add(this.textBoxIn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormWebTraduction";
            this.Text = "Translate";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private void Translate()
        {
            button1.Enabled = false;
            Cursor = Cursors.WaitCursor;
            string ret = Droid_web.Web.TrimPage(string.Format(_url, comboBoxLang.Text.ToUpper(), textBoxIn.Text), "<table class=\"traductions\">", "</table>");
            webBrowser1.DocumentText = ret;
            button1.Enabled = true;
            Cursor = Cursors.Arrow;
            
            textBoxIn.Clear();
        }
        private void CheckDll()
        {
            Droid_litterature.Sentense s = new Droid_litterature.Sentense("bonjour je m'appelle Andrew", "0");
        }
        #endregion

        #region Event
        private void button1_Click(object sender, System.EventArgs e)
        {
            Translate();
        }
        private void textBoxIn_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                Translate();
            }
        }
        #endregion

    }
}
