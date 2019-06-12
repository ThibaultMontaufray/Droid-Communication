namespace Droid.Communication
{
    partial class ViewMailBox
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.folderPanel = new System.Windows.Forms.Panel();
            this.folderTreeView = new Droid.Communication.FolderTreeView();
            this.messageListPanel = new System.Windows.Forms.Panel();
            this.messageList = new Droid.Communication.MessageList();
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.folderPanel.SuspendLayout();
            this.messageListPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // folderPanel
            // 
            this.folderPanel.Controls.Add(this.folderTreeView);
            this.folderPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.folderPanel.Location = new System.Drawing.Point(0, 0);
            this.folderPanel.Name = "folderPanel";
            this.folderPanel.Size = new System.Drawing.Size(200, 487);
            this.folderPanel.TabIndex = 0;
            // 
            // folderTreeView
            // 
            this.folderTreeView.Dock = System.Windows.Forms.DockStyle.Left;
            this.folderTreeView.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.folderTreeView.InterfaceEmail = null;
            this.folderTreeView.Location = new System.Drawing.Point(0, 0);
            this.folderTreeView.Name = "folderTreeView";
            this.folderTreeView.PathSeparator = "/";
            this.folderTreeView.Size = new System.Drawing.Size(200, 487);
            this.folderTreeView.TabIndex = 0;
            // 
            // messageListPanel
            // 
            this.messageListPanel.Controls.Add(this.messageList);
            this.messageListPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.messageListPanel.Location = new System.Drawing.Point(200, 0);
            this.messageListPanel.Name = "messageListPanel";
            this.messageListPanel.Size = new System.Drawing.Size(328, 487);
            this.messageListPanel.TabIndex = 1;
            // 
            // messageList
            // 
            this.messageList.Dock = System.Windows.Forms.DockStyle.Left;
            this.messageList.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.messageList.Location = new System.Drawing.Point(0, 0);
            this.messageList.Name = "messageList";
            this.messageList.Size = new System.Drawing.Size(328, 487);
            this.messageList.TabIndex = 0;
            // 
            // webBrowser
            // 
            this.webBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser.Location = new System.Drawing.Point(528, 0);
            this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.Size = new System.Drawing.Size(405, 487);
            this.webBrowser.TabIndex = 2;
            // 
            // ViewMailBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.webBrowser);
            this.Controls.Add(this.messageListPanel);
            this.Controls.Add(this.folderPanel);
            this.Name = "ViewMailBox";
            this.Size = new System.Drawing.Size(933, 487);
            this.folderPanel.ResumeLayout(false);
            this.messageListPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel folderPanel;
        private FolderTreeView folderTreeView;
        private System.Windows.Forms.Panel messageListPanel;
        private MessageList messageList;
        private System.Windows.Forms.WebBrowser webBrowser;
    }
}
