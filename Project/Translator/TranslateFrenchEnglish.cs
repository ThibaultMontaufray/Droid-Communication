namespace Droid_Translate
{
    using System.Text.RegularExpressions;
    using System.Windows.Forms;

    public partial class TranslateFrenchEnglish : Form
    {
        #region Attribute
        private string _login = string.Empty;
        private string _password = string.Empty;
        private string _url = "https://api.datamarket.azure.com/Bing/MicrosoftTranslator/v1/Translate?Text=%27{0}%27&To=%27{1}%27";

        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox textBoxIn;
        private System.Windows.Forms.ComboBox comboBoxLang;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBoxOut;
        #endregion

        #region Constructor
        public TranslateFrenchEnglish()
        {
            InitializeComponent();
            comboBoxLang.Text = "en";
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
            this.textBoxIn = new System.Windows.Forms.TextBox();
            this.comboBoxLang = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBoxOut = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBoxIn
            // 
            this.textBoxIn.Location = new System.Drawing.Point(12, 12);
            this.textBoxIn.Multiline = true;
            this.textBoxIn.Name = "textBoxIn";
            this.textBoxIn.Size = new System.Drawing.Size(322, 50);
            this.textBoxIn.TabIndex = 0;
            // 
            // comboBoxLang
            // 
            this.comboBoxLang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLang.FormattingEnabled = true;
            this.comboBoxLang.Items.AddRange(new object[] {
            "en",
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
            // textBoxOut
            // 
            this.textBoxOut.Location = new System.Drawing.Point(12, 68);
            this.textBoxOut.Multiline = true;
            this.textBoxOut.Name = "textBoxOut";
            this.textBoxOut.Size = new System.Drawing.Size(388, 50);
            this.textBoxOut.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(418, 130);
            this.Controls.Add(this.textBoxOut);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBoxLang);
            this.Controls.Add(this.textBoxIn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.Text = "Translate";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        #region Event
        private void button1_Click(object sender, System.EventArgs e)
        {
            string retVal = Droid_web.Web.GetJson(_login, _password, string.Format(_url, textBoxIn.Text, comboBoxLang.Text));
            textBoxOut.Text = Regex.Split(retVal, "<d:Text m:type=\"Edm.String\">")[1].Split('<')[0];
        }
        #endregion
    }
}
