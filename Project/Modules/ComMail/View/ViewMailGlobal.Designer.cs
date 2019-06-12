namespace Droid.Communication.Modules.ComMail.View
{
    partial class ViewMailGlobal
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
            this.viewMailBox1 = new Droid.Communication.ViewMailBox();
            this.SuspendLayout();
            // 
            // viewMailBox1
            // 
            this.viewMailBox1.BackColor = System.Drawing.Color.Black;
            this.viewMailBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewMailBox1.InterfaceEmail = null;
            this.viewMailBox1.Location = new System.Drawing.Point(0, 0);
            this.viewMailBox1.Name = "viewMailBox1";
            this.viewMailBox1.Size = new System.Drawing.Size(1090, 549);
            this.viewMailBox1.TabIndex = 0;
            // 
            // ViewMailGlobal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.viewMailBox1);
            this.Name = "ViewMailGlobal";
            this.Size = new System.Drawing.Size(1090, 549);
            this.ResumeLayout(false);

        }

        #endregion

        private ViewMailBox viewMailBox1;
    }
}
