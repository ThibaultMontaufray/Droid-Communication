namespace Droid.Communication.ComAdapter.View
{
    partial class ViewComWelcome
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
            this.hexaLync1 = new Droid.Communication.HexaLync();
            this.hexaFacebook1 = new Droid.Communication.HexaFacebook();
            this.hexaMail1 = new Droid.Communication.HexaMail();
            this.hexaNewCom1 = new Droid.Communication.ComAdapter.View.HexaNewCom();
            this.SuspendLayout();
            // 
            // hexaLync1
            // 
            this.hexaLync1.BackColor = System.Drawing.Color.Transparent;
            this.hexaLync1.BackgroundImage = global::Droid.Communication.Properties.Resources.background;
            this.hexaLync1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.hexaLync1.CurrentColor = Tools4Libraries.Hexagon.Color.DARKORANGE;
            this.hexaLync1.Location = new System.Drawing.Point(142, 179);
            this.hexaLync1.Name = "hexaLync1";
            this.hexaLync1.Size = new System.Drawing.Size(170, 170);
            this.hexaLync1.TabIndex = 1;
            // 
            // hexaFacebook1
            // 
            this.hexaFacebook1.BackColor = System.Drawing.Color.Transparent;
            this.hexaFacebook1.BackgroundImage = global::Droid.Communication.Properties.Resources.background;
            this.hexaFacebook1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.hexaFacebook1.CurrentColor = Tools4Libraries.Hexagon.Color.DARKORANGE;
            this.hexaFacebook1.Location = new System.Drawing.Point(494, 179);
            this.hexaFacebook1.Name = "hexaFacebook1";
            this.hexaFacebook1.Size = new System.Drawing.Size(170, 170);
            this.hexaFacebook1.TabIndex = 4;
            // 
            // hexaMail1
            // 
            this.hexaMail1.BackColor = System.Drawing.Color.Transparent;
            this.hexaMail1.BackgroundImage = global::Droid.Communication.Properties.Resources.background;
            this.hexaMail1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.hexaMail1.CurrentColor = Tools4Libraries.Hexagon.Color.DARKORANGE;
            this.hexaMail1.Location = new System.Drawing.Point(318, 179);
            this.hexaMail1.Name = "hexaMail1";
            this.hexaMail1.Size = new System.Drawing.Size(170, 170);
            this.hexaMail1.TabIndex = 6;
            // 
            // hexaNewCom1
            // 
            this.hexaNewCom1.BackColor = System.Drawing.Color.Transparent;
            this.hexaNewCom1.BackgroundImage = global::Droid.Communication.Properties.Resources.background;
            this.hexaNewCom1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.hexaNewCom1.IsActive = false;
            this.hexaNewCom1.Location = new System.Drawing.Point(318, 3);
            this.hexaNewCom1.Name = "hexaNewCom1";
            this.hexaNewCom1.Size = new System.Drawing.Size(170, 170);
            this.hexaNewCom1.TabIndex = 7;
            // 
            // ViewComWelcome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.hexaNewCom1);
            this.Controls.Add(this.hexaMail1);
            this.Controls.Add(this.hexaFacebook1);
            this.Controls.Add(this.hexaLync1);
            this.Name = "ViewComWelcome";
            this.Size = new System.Drawing.Size(800, 600);
            this.Load += new System.EventHandler(this.ViewWelcomeCom_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private HexaLync hexaLync1;
        private HexaFacebook hexaFacebook1;
        private HexaMail hexaMail1;
        private HexaNewCom hexaNewCom1;
    }
}
