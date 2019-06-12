namespace Droid.Communication
{
    partial class HexaFacebook
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HexaFacebook));
            this.label = new System.Windows.Forms.Label();
            this.buttonGoAction = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label
            // 
            this.label.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label.Location = new System.Drawing.Point(42, 89);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(86, 59);
            this.label.TabIndex = 1;
            this.label.Text = "...";
            this.label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonGoAction
            // 
            this.buttonGoAction.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonGoAction.BackgroundImage")));
            this.buttonGoAction.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonGoAction.FlatAppearance.BorderSize = 0;
            this.buttonGoAction.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttonGoAction.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttonGoAction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGoAction.Location = new System.Drawing.Point(55, 26);
            this.buttonGoAction.Name = "buttonGoAction";
            this.buttonGoAction.Size = new System.Drawing.Size(60, 60);
            this.buttonGoAction.TabIndex = 2;
            this.buttonGoAction.UseVisualStyleBackColor = true;
            this.buttonGoAction.Click += new System.EventHandler(this.buttonGoAction_Click);
            // 
            // HexaFacebook
            // 
            this.Controls.Add(this.buttonGoAction);
            this.Controls.Add(this.label);
            this.Name = "HexaFacebook";
            this.Size = new System.Drawing.Size(170, 170);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Button buttonGoAction;
    }
}
