namespace Droid.Communication
{
    partial class SlackHeader
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
            this.labelChannel = new System.Windows.Forms.Label();
            this.labelMembers = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelChannel
            // 
            this.labelChannel.AutoSize = true;
            this.labelChannel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.labelChannel.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Bold);
            this.labelChannel.Location = new System.Drawing.Point(10, 9);
            this.labelChannel.Name = "labelChannel";
            this.labelChannel.Size = new System.Drawing.Size(74, 23);
            this.labelChannel.TabIndex = 7;
            this.labelChannel.Text = "Channel";
            // 
            // labelMembers
            // 
            this.labelMembers.AutoSize = true;
            this.labelMembers.BackColor = System.Drawing.Color.WhiteSmoke;
            this.labelMembers.Font = new System.Drawing.Font("Calibri", 12F);
            this.labelMembers.Location = new System.Drawing.Point(90, 12);
            this.labelMembers.Name = "labelMembers";
            this.labelMembers.Size = new System.Drawing.Size(82, 19);
            this.labelMembers.TabIndex = 8;
            this.labelMembers.Text = "0 Members";
            // 
            // SlackHeader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Controls.Add(this.labelMembers);
            this.Controls.Add(this.labelChannel);
            this.Name = "SlackHeader";
            this.Size = new System.Drawing.Size(910, 40);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelChannel;
        private System.Windows.Forms.Label labelMembers;
    }
}
