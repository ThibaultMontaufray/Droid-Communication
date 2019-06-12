namespace Droid.Communication
{
    partial class SlackManage
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this._slackConversation = new Droid.Communication.SlackConversationView();
            this._slackHeader = new Droid.Communication.SlackHeader();
            this._slackInput = new Droid.Communication.SlackInput();
            this._slackMenu = new Droid.Communication.SlackMenu();
            this.SuspendLayout();
            // 
            // _slackConversation
            // 
            this._slackConversation.AutoScroll = true;
            this._slackConversation.AutoScrollHorizontalMaximum = 100;
            this._slackConversation.AutoScrollHorizontalMinimum = 0;
            this._slackConversation.AutoScrollHPos = 0;
            this._slackConversation.AutoScrollVerticalMaximum = 100;
            this._slackConversation.AutoScrollVerticalMinimum = 0;
            this._slackConversation.AutoScrollVPos = 0;
            this._slackConversation.CurrentConversation = null;
            this._slackConversation.Dock = System.Windows.Forms.DockStyle.Fill;
            this._slackConversation.EnableAutoScrollHorizontal = true;
            this._slackConversation.EnableAutoScrollVertical = true;
            this._slackConversation.Location = new System.Drawing.Point(300, 40);
            this._slackConversation.Name = "_slackConversation";
            this._slackConversation.Size = new System.Drawing.Size(685, 478);
            this._slackConversation.Adapter = null;
            this._slackConversation.TabIndex = 5;
            this._slackConversation.VisibleAutoScrollHorizontal = true;
            this._slackConversation.VisibleAutoScrollVertical = true;
            // 
            // _slackHeader
            // 
            this._slackHeader.BackColor = System.Drawing.Color.WhiteSmoke;
            this._slackHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this._slackHeader.ForeColor = System.Drawing.Color.Black;
            this._slackHeader.Location = new System.Drawing.Point(300, 0);
            this._slackHeader.Name = "_slackHeader";
            this._slackHeader.Size = new System.Drawing.Size(685, 40);
            this._slackHeader.TabIndex = 4;
            // 
            // _slackInput
            // 
            this._slackInput.BackColor = System.Drawing.Color.WhiteSmoke;
            this._slackInput.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._slackInput.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._slackInput.Location = new System.Drawing.Point(300, 518);
            this._slackInput.Name = "_slackInput";
            this._slackInput.Size = new System.Drawing.Size(685, 42);
            this._slackInput.Adapter = null;
            this._slackInput.TabIndex = 2;
            // 
            // _slackMenu
            // 
            this._slackMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this._slackMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this._slackMenu.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._slackMenu.ForeColor = System.Drawing.Color.WhiteSmoke;
            this._slackMenu.Location = new System.Drawing.Point(0, 0);
            this._slackMenu.Name = "_slackMenu";
            this._slackMenu.Size = new System.Drawing.Size(300, 560);
            this._slackMenu.Adapter = null;
            this._slackMenu.TabIndex = 0;
            // 
            // SlackControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.Controls.Add(this._slackConversation);
            this.Controls.Add(this._slackHeader);
            this.Controls.Add(this._slackInput);
            this.Controls.Add(this._slackMenu);
            this.Name = "SlackControl";
            this.Size = new System.Drawing.Size(985, 560);
            this.ResumeLayout(false);

        }

        #endregion

        private SlackMenu _slackMenu;
        private SlackInput _slackInput;
        private SlackHeader _slackHeader;
        private SlackConversationView _slackConversation;
    }
}
