using System.Windows.Forms;
using System.Drawing;
using Tools4Libraries;

namespace Droid_communication
{
    public partial class SlackDemo : Form
    {
        #region Attribute
        private Interface_slack _slackInt;
        private System.ComponentModel.IContainer components = null;

        private string _url = Params.CommunicationSlackUrl;
        private string _topic = Params.CommunicationSlackTopic;
        private string _account = Params.CommunicationSlackAccount;
        private string _token = Params.CommunicationSlackToken;
        
        private System.Windows.Forms.TextBox textBoxLogin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxText;
        private System.Windows.Forms.Button buttonSendMessage;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxChan;
        #endregion

        #region Constructor
        public SlackDemo()
        {
            InitializeComponent();
            _slackInt = new Interface_slack(string.Format(_url, _topic, _token));
            _slackInt.PostMessage("Hello, c'est Tobi, je m'entraine pour le moment mais je reviendrais vous aider plus tard. :D", "amostrack", "#general");
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
            this.textBoxLogin = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxText = new System.Windows.Forms.TextBox();
            this.buttonSendMessage = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxChan = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBoxLogin
            // 
            this.textBoxLogin.Location = new System.Drawing.Point(79, 6);
            this.textBoxLogin.Name = "textBoxLogin";
            this.textBoxLogin.Size = new System.Drawing.Size(193, 20);
            this.textBoxLogin.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Login :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Text :";
            // 
            // textBoxText
            // 
            this.textBoxText.Location = new System.Drawing.Point(79, 84);
            this.textBoxText.Multiline = true;
            this.textBoxText.Name = "textBoxText";
            this.textBoxText.Size = new System.Drawing.Size(193, 80);
            this.textBoxText.TabIndex = 2;
            // 
            // buttonSendMessage
            // 
            this.buttonSendMessage.Location = new System.Drawing.Point(154, 170);
            this.buttonSendMessage.Name = "buttonSendMessage";
            this.buttonSendMessage.Size = new System.Drawing.Size(118, 23);
            this.buttonSendMessage.TabIndex = 4;
            this.buttonSendMessage.Text = "Send message";
            this.buttonSendMessage.UseVisualStyleBackColor = true;
            this.buttonSendMessage.Click += new System.EventHandler(this.buttonSendMessage_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Password :";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(79, 32);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new System.Drawing.Size(193, 20);
            this.textBoxPassword.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Channel :";
            // 
            // textBoxChan
            // 
            this.textBoxChan.Location = new System.Drawing.Point(79, 58);
            this.textBoxChan.Name = "textBoxChan";
            this.textBoxChan.PasswordChar = '*';
            this.textBoxChan.Size = new System.Drawing.Size(193, 20);
            this.textBoxChan.TabIndex = 7;
            // 
            // SlackDemo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 203);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxChan);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.buttonSendMessage);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxText);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxLogin);
            this.Name = "SlackDemo";
            this.Text = "SlackDemo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        #region Event
        private void buttonSendMessage_Click(object sender, System.EventArgs e)
        {
        }
        #endregion
    }
}
