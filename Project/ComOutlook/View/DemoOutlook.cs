using Assistant.ComOutlook;
using Droid_communication.Outlook;
using Microsoft.Office.Interop.Outlook;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Droid_communication
{
    public partial class DemoOutlook : Form
    {
        #region Attribute
        private OutlookInterface _outlookInterface;
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox _textBox;
        private Outlook.MailListPreview _mailListPreview;
        private SplitContainer splitContainer2;
        private Assistant.ComOutlook.MailFolders _mailFolders;
        private Assistant.ComOutlook.Actions _actions;
        private System.Windows.Forms.SplitContainer splitContainer1;

        private string _currentFolder;
        private Timer _timer;
        #endregion

        #region Properties
        #endregion

        #region Constructor
        public DemoOutlook()
        {
            InitializeComponent();
            Init();
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
        private void Init()
        {
            _currentFolder = "inbox";
            _outlookInterface = new OutlookInterface();

            _mailListPreview.OutLook = _outlookInterface;
            _mailListPreview.LoadMails(OutlookInterface.ACTION_131_lister_mail(_currentFolder));
            _mailListPreview.MailSelected += _mailPreview_MailSelected;
            _mailListPreview.GotFocus += _mailListPreview_GotFocus;
            _mailListPreview.LostFocus += _mailListPreview_LostFocus;

            _mailFolders.OutLook = _outlookInterface;
            _mailFolders.LoadMails();
            _mailFolders.FolderSelectionChanged += _mailFolders_FolderSelectionChanged;

            _actions.Request += _actions_Requested;

            _timer = new Timer();
            _timer.Interval = 1000;
            _timer.Tick += _timer_Tick;
            _timer.Start();
        }
        private void LoadMail(MailItem mail)
        {
            try
            {
                _mailListPreview.MailSelected -= _mailPreview_MailSelected;
                splitContainer1.Panel2.Controls.Clear();
                MailPreview mp = new MailPreview();
                mp.Mail = mail;
                mp.Dock = DockStyle.Fill;
                splitContainer1.Panel2.Controls.Add(mp);
                _mailListPreview.MailSelected += _mailPreview_MailSelected;
            }
            catch (System.Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }
        private void InitializeComponent()
        {
            this._textBox = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this._mailListPreview = new Droid_communication.Outlook.MailListPreview();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this._mailFolders = new Assistant.ComOutlook.MailFolders();
            this._actions = new Assistant.ComOutlook.Actions();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // _textBox
            // 
            this._textBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this._textBox.Location = new System.Drawing.Point(0, 0);
            this._textBox.Multiline = true;
            this._textBox.Name = "_textBox";
            this._textBox.Size = new System.Drawing.Size(1008, 712);
            this._textBox.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this._mailListPreview);
            this.splitContainer1.Size = new System.Drawing.Size(864, 712);
            this.splitContainer1.SplitterDistance = 288;
            this.splitContainer1.TabIndex = 2;
            // 
            // _mailListPreview
            // 
            this._mailListPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this._mailListPreview.Location = new System.Drawing.Point(0, 0);
            this._mailListPreview.MinimumSize = new System.Drawing.Size(300, 0);
            this._mailListPreview.Name = "_mailListPreview";
            this._mailListPreview.OutLook = null;
            this._mailListPreview.Size = new System.Drawing.Size(300, 712);
            this._mailListPreview.TabIndex = 1;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this._mailFolders);
            this.splitContainer2.Panel1.Controls.Add(this._actions);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer1);
            this.splitContainer2.Size = new System.Drawing.Size(1008, 712);
            this.splitContainer2.SplitterDistance = 140;
            this.splitContainer2.TabIndex = 3;
            // 
            // _mailFolders
            // 
            this._mailFolders.Dock = System.Windows.Forms.DockStyle.Fill;
            this._mailFolders.Location = new System.Drawing.Point(0, 18);
            this._mailFolders.Name = "_mailFolders";
            this._mailFolders.OutLook = null;
            this._mailFolders.Size = new System.Drawing.Size(140, 694);
            this._mailFolders.TabIndex = 3;
            // 
            // _actions
            // 
            this._actions.BackColor = System.Drawing.Color.Silver;
            this._actions.Dock = System.Windows.Forms.DockStyle.Top;
            this._actions.Location = new System.Drawing.Point(0, 0);
            this._actions.Name = "_actions";
            this._actions.Size = new System.Drawing.Size(140, 18);
            this._actions.TabIndex = 0;
            // 
            // DemoOutlook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 712);
            this.Controls.Add(this.splitContainer2);
            this.Controls.Add(this._textBox);
            this.Name = "DemoOutlook";
            this.Text = "DemoOutlook";
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        #region Event
        private void _mailListPreview_LostFocus(object sender, EventArgs e)
        {
            _timer.Stop();
        }
        private void _mailListPreview_GotFocus(object sender, EventArgs e)
        {
            _timer.Start();
        }
        private void _mailPreview_MailSelected(object obj)
        {
            LoadMail((MailItem)obj);
        }
        private void _actions_Requested(string name, object obj)
        {
            try
            {
                switch (name.ToString())
                {
                    case "newmail":
                        MailPreview mp = new MailPreview();
                        mp.ReadOnly = false;
                        mp.Dock = DockStyle.Fill;
                        mp.SendMail += Mp_SendMail;
                        Form f = new Form();
                        f.Size = new Size(800, 600);
                        f.Controls.Add(mp);
                        f.Show();
                        break;
                    case "delete":
                        string id = _mailListPreview.SelectedMailId();
                        var list = _outlookInterface.MailsInbox.Where(m => m.EntryID!= null && m.EntryID.Equals(id)).ToList();
                        if (list.Count ==1)
                        {
                            OutlookInterface.ACTION_132_supprimer_mail(list[0].Subject, list[0].SenderEmailAddress, list[0].ReceivedTime, "inbox");
                        }
                        OutlookInterface.ACTION_131_lister_mail(_currentFolder);
                        break;
                    case "search":
                        MailUserSearch mus = new MailUserSearch();
                        mus.Dock = DockStyle.Fill;
                        Form f2 = new Form();
                        f2.Size = new Size(500, 300);
                        f2.FormBorderStyle = FormBorderStyle.FixedToolWindow;
                        f2.Controls.Add(mus);
                        f2.ShowDialog();
                        _timer.Start();
                        //OutlookInterface.ACTION_134_chercher_mail(_currentFolder);
                        break;
                }
            }
            catch (System.Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }
        private void Mp_SendMail(object obj, object parent)
        {
            try
            {
                Dictionary<string, string> mailDetails = obj as Dictionary<string, string>;
                OutlookInterface.ACTION_130_envoyer_mail(mailDetails["title"], mailDetails["to"].Split(';').ToList(), mailDetails["message"]);
                if (parent is Form) (parent as Form).Close();
            }
            catch (System.Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }
        private void _mailFolders_FolderSelectionChanged(object obj)
        {
            _currentFolder = obj.ToString();
            _mailListPreview.LoadMails(OutlookInterface.ACTION_131_lister_mail(_currentFolder));
        }
        private void _timer_Tick(object sender, EventArgs e)
        {
            _timer.Stop();
            _mailListPreview.LoadMails(OutlookInterface.ACTION_131_lister_mail(_currentFolder));
            _timer.Start();
        }
        #endregion
    }
}
