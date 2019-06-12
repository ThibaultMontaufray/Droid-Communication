namespace Droid.Communication
{
    partial class SlackMenu
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SlackMenu));
            this.panelHeader = new System.Windows.Forms.Panel();
            this.pictureBoxStatus = new System.Windows.Forms.PictureBox();
            this.labelCurrentUser = new System.Windows.Forms.Label();
            this.buttonSettings = new System.Windows.Forms.Button();
            this.pictureBoxIcon = new System.Windows.Forms.PictureBox();
            this.labelTitle = new System.Windows.Forms.Label();
            this._treeViewChannels = new System.Windows.Forms.TreeView();
            this._treeViewUsers = new System.Windows.Forms.TreeView();
            this.imageListStatus = new System.Windows.Forms.ImageList(this.components);
            this.panelChannels = new System.Windows.Forms.Panel();
            this.panelUsers = new System.Windows.Forms.Panel();
            this.imageListChannel = new System.Windows.Forms.ImageList(this.components);
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).BeginInit();
            this.panelChannels.SuspendLayout();
            this.panelUsers.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(82)))), ((int)(((byte)(80)))));
            this.panelHeader.Controls.Add(this.pictureBoxStatus);
            this.panelHeader.Controls.Add(this.labelCurrentUser);
            this.panelHeader.Controls.Add(this.buttonSettings);
            this.panelHeader.Controls.Add(this.pictureBoxIcon);
            this.panelHeader.Controls.Add(this.labelTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelHeader.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Margin = new System.Windows.Forms.Padding(7);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(350, 50);
            this.panelHeader.TabIndex = 1;
            // 
            // pictureBoxStatus
            // 
            this.pictureBoxStatus.Location = new System.Drawing.Point(48, 32);
            this.pictureBoxStatus.Margin = new System.Windows.Forms.Padding(7);
            this.pictureBoxStatus.Name = "pictureBoxStatus";
            this.pictureBoxStatus.Size = new System.Drawing.Size(16, 16);
            this.pictureBoxStatus.TabIndex = 4;
            this.pictureBoxStatus.TabStop = false;
            // 
            // labelCurrentUser
            // 
            this.labelCurrentUser.AutoSize = true;
            this.labelCurrentUser.Font = new System.Drawing.Font("Calibri", 9F);
            this.labelCurrentUser.Location = new System.Drawing.Point(62, 28);
            this.labelCurrentUser.Name = "labelCurrentUser";
            this.labelCurrentUser.Size = new System.Drawing.Size(52, 14);
            this.labelCurrentUser.TabIndex = 3;
            this.labelCurrentUser.Text = "Member";
            // 
            // buttonSettings
            // 
            this.buttonSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSettings.BackColor = System.Drawing.Color.Transparent;
            this.buttonSettings.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonSettings.BackgroundImage")));
            this.buttonSettings.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.buttonSettings.FlatAppearance.BorderSize = 0;
            this.buttonSettings.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttonSettings.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttonSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSettings.Location = new System.Drawing.Point(310, 8);
            this.buttonSettings.Name = "buttonSettings";
            this.buttonSettings.Size = new System.Drawing.Size(32, 32);
            this.buttonSettings.TabIndex = 2;
            this.buttonSettings.UseVisualStyleBackColor = false;
            this.buttonSettings.Click += new System.EventHandler(this.buttonSettings_Click);
            // 
            // pictureBoxIcon
            // 
            this.pictureBoxIcon.Location = new System.Drawing.Point(7, 7);
            this.pictureBoxIcon.Margin = new System.Windows.Forms.Padding(7);
            this.pictureBoxIcon.Name = "pictureBoxIcon";
            this.pictureBoxIcon.Size = new System.Drawing.Size(34, 34);
            this.pictureBoxIcon.TabIndex = 1;
            this.pictureBoxIcon.TabStop = false;
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Calibri", 14F);
            this.labelTitle.Location = new System.Drawing.Point(48, 5);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(58, 23);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "SLACK";
            // 
            // _treeViewChannels
            // 
            this._treeViewChannels.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(82)))), ((int)(((byte)(80)))));
            this._treeViewChannels.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._treeViewChannels.Dock = System.Windows.Forms.DockStyle.Fill;
            this._treeViewChannels.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._treeViewChannels.ForeColor = System.Drawing.Color.WhiteSmoke;
            this._treeViewChannels.ImageIndex = 0;
            this._treeViewChannels.ImageList = this.imageListChannel;
            this._treeViewChannels.Location = new System.Drawing.Point(0, 0);
            this._treeViewChannels.Name = "_treeViewChannels";
            this._treeViewChannels.SelectedImageIndex = 0;
            this._treeViewChannels.ShowLines = false;
            this._treeViewChannels.ShowPlusMinus = false;
            this._treeViewChannels.ShowRootLines = false;
            this._treeViewChannels.Size = new System.Drawing.Size(350, 50);
            this._treeViewChannels.TabIndex = 2;
            this._treeViewChannels.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this._treeViewChannels_NodeMouseClick);
            // 
            // _treeViewUsers
            // 
            this._treeViewUsers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(82)))), ((int)(((byte)(80)))));
            this._treeViewUsers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._treeViewUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this._treeViewUsers.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._treeViewUsers.ForeColor = System.Drawing.Color.WhiteSmoke;
            this._treeViewUsers.ImageIndex = 0;
            this._treeViewUsers.ImageList = this.imageListStatus;
            this._treeViewUsers.Location = new System.Drawing.Point(0, 0);
            this._treeViewUsers.Name = "_treeViewUsers";
            this._treeViewUsers.SelectedImageIndex = 0;
            this._treeViewUsers.ShowLines = false;
            this._treeViewUsers.ShowPlusMinus = false;
            this._treeViewUsers.ShowRootLines = false;
            this._treeViewUsers.Size = new System.Drawing.Size(350, 393);
            this._treeViewUsers.TabIndex = 3;
            this._treeViewUsers.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this._treeViewUsers_NodeMouseClick);
            // 
            // imageListStatus
            // 
            this.imageListStatus.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListStatus.ImageStream")));
            this.imageListStatus.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListStatus.Images.SetKeyName(0, "unknow");
            this.imageListStatus.Images.SetKeyName(1, "unactive");
            this.imageListStatus.Images.SetKeyName(2, "connected");
            this.imageListStatus.Images.SetKeyName(3, "disconnected");
            // 
            // panelChannels
            // 
            this.panelChannels.Controls.Add(this._treeViewChannels);
            this.panelChannels.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelChannels.Location = new System.Drawing.Point(0, 50);
            this.panelChannels.Name = "panelChannels";
            this.panelChannels.Size = new System.Drawing.Size(350, 50);
            this.panelChannels.TabIndex = 4;
            // 
            // panelUsers
            // 
            this.panelUsers.Controls.Add(this._treeViewUsers);
            this.panelUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelUsers.Location = new System.Drawing.Point(0, 100);
            this.panelUsers.Name = "panelUsers";
            this.panelUsers.Size = new System.Drawing.Size(350, 393);
            this.panelUsers.TabIndex = 5;
            // 
            // imageListChannel
            // 
            this.imageListChannel.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListChannel.ImageStream")));
            this.imageListChannel.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListChannel.Images.SetKeyName(0, "hash");
            this.imageListChannel.Images.SetKeyName(1, "lock");
            // 
            // SlackMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.Controls.Add(this.panelUsers);
            this.Controls.Add(this.panelChannels);
            this.Controls.Add(this.panelHeader);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Name = "SlackMenu";
            this.Size = new System.Drawing.Size(350, 493);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).EndInit();
            this.panelChannels.ResumeLayout(false);
            this.panelUsers.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.TreeView _treeViewChannels;
        private System.Windows.Forms.TreeView _treeViewUsers;
        private System.Windows.Forms.Panel panelChannels;
        private System.Windows.Forms.Panel panelUsers;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.PictureBox pictureBoxIcon;
        private System.Windows.Forms.Button buttonSettings;
        private System.Windows.Forms.ImageList imageListStatus;
        private System.Windows.Forms.Label labelCurrentUser;
        private System.Windows.Forms.PictureBox pictureBoxStatus;
        private System.Windows.Forms.ImageList imageListChannel;
    }
}
