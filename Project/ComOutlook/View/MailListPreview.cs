using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Interop.Outlook;
using System.Drawing.Imaging;
using System.IO;
using Tools4Libraries.Resources;
using System.Threading.Tasks;

namespace Droid_communication.Outlook
{
    public delegate void MailListPreviewEventHandler(object o);
    public partial class MailListPreview : UserControl
    {
        #region Attribute
        public event MailListPreviewEventHandler MailSelected;

        private OutlookInterface _outlookInterface;
        private DataGridViewCellStyle _dataGridViewCellStyleUnread;
        private DataGridViewCellStyle _dataGridViewCellStyle;
        private DataGridView _dataGridViewMails;
        private DataGridViewImageColumn ColumnIcon;
        private DataGridViewImageColumn ColumnImportance;
        private DataGridViewImageColumn ColumnReminder;
        private DataGridViewImageColumn ColumnAttachment;
        private DataGridViewTextBoxColumn ColumnFrom;
        private DataGridViewTextBoxColumn ColumnSubject;
        private DataGridViewTextBoxColumn ColumnReceived;
        private DataGridViewTextBoxColumn ColumnSize;
        private DataGridViewTextBoxColumn ColumnPrivacyLevel;
        private DataGridViewImageColumn ColumnFlag;
        private IContainer components = null;

        private Color _colorMain;
        private Color _colorMainBis;
        private Color _colorDecoration;
        private Color _colorDecorationSelect;
        #endregion

        #region Properties
        public OutlookInterface OutLook
        {
            get { return _outlookInterface; }
            set { _outlookInterface = value; }
        }
        #endregion

        #region Constructor
        public MailListPreview()
        {
            _colorMain = Color.White;
            _colorMainBis = Color.WhiteSmoke;
            _colorDecoration = Color.Orange;
            _colorDecorationSelect = Color.OrangeRed;

            InitializeComponent();
            Init();
        }
        #endregion

        #region Methods public
        public void LoadMails(List<MailItem> mails)
        {
            LoadMailsDetailled(mails);
        }
        public void CleanMails()
        {
            _dataGridViewMails.Rows.Clear();
        }
        public string SelectedMailId()
        {
            return _dataGridViewMails.SelectedRows[0].Tag.ToString();
        }
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
        protected void OnMailSelected(object o)
        {
            if (MailSelected != null)
                MailSelected(o);
        }
        #endregion

        #region Methods private
        private void LoadMailsDetailled(List<MailItem> mails)
        {
            DataGridViewRow row;
            List<DataGridViewRow> datasource = new List<DataGridViewRow>();
            if (_outlookInterface != null)
            { 
                foreach (MailItem mail in mails)
                {
                    row = AddMail(mail);
                    if (row != null)
                    {
                        datasource.Add(row);
                    }
                }
            }
            datasource.Reverse(0, datasource.Count);

            if (datasource.Count == _dataGridViewMails.Rows.Count &&
                datasource.Count > 0 && _dataGridViewMails.Rows.Count > 0 &&
                datasource[0].Tag.Equals(_dataGridViewMails.Rows[0].Tag) &&
                datasource[datasource.Count-1].Tag.Equals(_dataGridViewMails.Rows[_dataGridViewMails.Rows.Count-1].Tag))
                return;

            _dataGridViewMails.Rows.Clear();
            foreach (DataGridViewRow item in datasource)
            {
                _dataGridViewMails.Rows.Insert(_dataGridViewMails.Rows.Count, item);
            }
            if (_dataGridViewMails.Rows.Count > 0) { _dataGridViewMails.Rows[0].Selected = true; }
            _dataGridViewMails_SelectionChanged(null, null);
        }
        private void Init()
        {
            _dataGridViewCellStyle = new DataGridViewCellStyle();
            _dataGridViewCellStyle.BackColor = _colorMain;

            _dataGridViewMails.Columns[ColumnIcon.Index].DefaultCellStyle.NullValue = null;
            _dataGridViewMails.Columns[ColumnIcon.Index].HeaderText = string.Empty;
            _dataGridViewMails.Columns[ColumnImportance.Index].DefaultCellStyle.NullValue = null;
            _dataGridViewMails.Columns[ColumnImportance.Index].HeaderText = string.Empty;
            _dataGridViewMails.Columns[ColumnReminder.Index].DefaultCellStyle.NullValue = null;
            _dataGridViewMails.Columns[ColumnReminder.Index].HeaderText = string.Empty;
            _dataGridViewMails.Columns[ColumnAttachment.Index].DefaultCellStyle.NullValue = null;
            _dataGridViewMails.Columns[ColumnAttachment.Index].HeaderText = string.Empty;

            _dataGridViewMails.CellBorderStyle = DataGridViewCellBorderStyle.RaisedHorizontal;
            _dataGridViewMails.SelectionChanged += _dataGridViewMails_SelectionChanged;
            _dataGridViewMails.Resize += _dataGridViewMails_Resize;

            _dataGridViewCellStyleUnread = new System.Windows.Forms.DataGridViewCellStyle();
            _dataGridViewCellStyleUnread.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            _dataGridViewCellStyleUnread.BackColor = _colorMainBis;
            _dataGridViewCellStyleUnread.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            _dataGridViewCellStyleUnread.ForeColor = System.Drawing.SystemColors.ControlText;
            _dataGridViewCellStyleUnread.SelectionBackColor = _colorDecoration;
            _dataGridViewCellStyleUnread.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            _dataGridViewCellStyleUnread.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
        }
        private DataGridViewRow AddMail(MailItem mail)
        {
            int size;
            string sizeStr = string.Empty;

            try
            {
                DataGridViewRow row = new DataGridViewRow();
                row.ReadOnly = true;
                row.CreateCells(_dataGridViewMails);
                row.Cells[ColumnReminder.Index].Value = mail.ReminderSet ? ResourceIconSet16Default.clock : null;
                row.Cells[ColumnAttachment.Index].Value = mail.Attachments.Count > 0 ? ResourceIconSet16Default.folder_page : null;
                if (mail.Importance == OlImportance.olImportanceHigh) row.Cells[ColumnImportance.Index].Value = ResourceIconSet16Default.medal_gold_1;
                else if (mail.Importance == OlImportance.olImportanceLow) row.Cells[ColumnImportance.Index].Value = ResourceIconSet16Default.medal_gold_3;
                row.Cells[ColumnFrom.Index].Value = mail.SenderName;
                row.Cells[ColumnSubject.Index].Value = mail.Subject;
                if (mail.ReceivedTime.Day == DateTime.Now.Day && mail.ReceivedTime.Month == DateTime.Now.Month && mail.ReceivedTime.Year == DateTime.Now.Year)
                {
                    row.Cells[ColumnReceived.Index].Value = mail.ReceivedTime.ToString("HH:mm");
                }
                else if (mail.ReceivedTime.Day >= DateTime.Now.AddDays(-7).Day && mail.ReceivedTime.Month >= DateTime.Now.AddDays(-7).Month && mail.ReceivedTime.Year >= DateTime.Now.AddDays(-7).Year)
                {
                    row.Cells[ColumnReceived.Index].Value = mail.ReceivedTime.ToString("ddd HH:mm");
                }
                else
                {
                    row.Cells[ColumnReceived.Index].Value = mail.ReceivedTime.ToString("ddd MM/dd");
                }
                row.Tag = mail.EntryID;// ReceivedTime.ToString("ddd dd/MM/yyyy HH:mm:ss");
                size = mail.Size;
                if (size < 1000) sizeStr = size + " OC";
                else if (size < 1000000) sizeStr = size / 1000 + " KB";
                else if (size < 1000000000) sizeStr = size / 1000000 + " MB";
                else sizeStr = size / 1000000000 + " GB";
                row.Cells[ColumnSize.Index].Value = sizeStr;
                row.Cells[ColumnPrivacyLevel.Index].Value = mail.Mileage;

                if (mail.UnRead || mail.Subject.StartsWith("Missed conversation")) row.Cells[ColumnIcon.Index].Value = ResourceIconSet16Default.email;
                else if (OutLook.IsMailReplied(mail)) row.Cells[ColumnIcon.Index].Value = ResourceIconSet16Default.email_edit;
                else if (OutLook.IsMailForwarded(mail)) row.Cells[ColumnIcon.Index].Value = ResourceIconSet16Default.email_go;
                else if (mail.Subject.StartsWith("Automatic reply:")) row.Cells[ColumnIcon.Index].Value = ResourceIconSet16Default.page_gear;
                else row.Cells[ColumnIcon.Index].Value = ResourceIconSet16Default.email_open;

                if (mail.FlagStatus == OlFlagStatus.olFlagComplete) row.Cells[ColumnFlag.Index].Value = ResourceIconSet16Default.tag_green;
                else if (mail.FlagStatus == OlFlagStatus.olFlagMarked) row.Cells[ColumnFlag.Index].Value = ResourceIconSet16Default.tag_red;
                else row.Cells[ColumnFlag.Index].Value = ResourceIconSet16Default.tag_blue;
                
                if (mail.UnRead)
                {
                    row.DefaultCellStyle = _dataGridViewCellStyleUnread;
                }
                else
                {
                    row.DefaultCellStyle = _dataGridViewCellStyle;
                }
                return row;
            }
            catch (System.Exception exp)
            {
                Console.WriteLine(" => ERR : " + exp.Message);
                return null;
            }
        }
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MailListPreview));
            this._dataGridViewMails = new System.Windows.Forms.DataGridView();
            this.ColumnIcon = new System.Windows.Forms.DataGridViewImageColumn();
            this.ColumnImportance = new System.Windows.Forms.DataGridViewImageColumn();
            this.ColumnReminder = new System.Windows.Forms.DataGridViewImageColumn();
            this.ColumnAttachment = new System.Windows.Forms.DataGridViewImageColumn();
            this.ColumnFrom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSubject = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnReceived = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPrivacyLevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFlag = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this._dataGridViewMails)).BeginInit();
            this.SuspendLayout();
            // 
            // _dataGridViewMails
            // 
            this._dataGridViewMails.AllowUserToAddRows = false;
            this._dataGridViewMails.AllowUserToResizeRows = false;
            this._dataGridViewMails.BackgroundColor = _colorMain;
            this._dataGridViewMails.MultiSelect = false;
            this._dataGridViewMails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dataGridViewMails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnIcon,
            this.ColumnImportance,
            this.ColumnReminder,
            this.ColumnAttachment,
            this.ColumnFrom,
            this.ColumnSubject,
            this.ColumnReceived,
            this.ColumnSize,
            this.ColumnPrivacyLevel,
            this.ColumnFlag});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = _colorMain;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = _colorDecoration;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this._dataGridViewMails.DefaultCellStyle = dataGridViewCellStyle1;
            this._dataGridViewMails.Dock = System.Windows.Forms.DockStyle.Fill;
            this._dataGridViewMails.Location = new System.Drawing.Point(0, 0);
            this._dataGridViewMails.Name = "_dataGridViewMails";
            this._dataGridViewMails.RowHeadersVisible = false;
            this._dataGridViewMails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._dataGridViewMails.Size = new System.Drawing.Size(710, 484);
            this._dataGridViewMails.TabIndex = 0;
            // 
            // ColumnIcon
            // 
            this.ColumnIcon.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.ColumnIcon.HeaderText = "Icon";
            this.ColumnIcon.Name = "ColumnIcon";
            this.ColumnIcon.Width = 5;
            // 
            // ColumnImportance
            // 
            this.ColumnImportance.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.ColumnImportance.HeaderText = "Importance";
            this.ColumnImportance.Name = "ColumnImportance";
            this.ColumnImportance.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnImportance.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnImportance.Width = 5;
            // 
            // ColumnReminder
            // 
            this.ColumnReminder.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.ColumnReminder.HeaderText = "Reminder";
            this.ColumnReminder.Name = "ColumnReminder";
            this.ColumnReminder.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnReminder.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnReminder.Width = 5;
            // 
            // ColumnAttachment
            // 
            this.ColumnAttachment.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.ColumnAttachment.HeaderText = "Attachment";
            this.ColumnAttachment.Name = "ColumnAttachment";
            this.ColumnAttachment.Width = 5;
            // 
            // ColumnFrom
            // 
            this.ColumnFrom.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnFrom.HeaderText = "From";
            this.ColumnFrom.Name = "ColumnFrom";
            this.ColumnFrom.Width = 5;
            // 
            // ColumnSubject
            // 
            this.ColumnSubject.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnSubject.HeaderText = "Subject";
            this.ColumnSubject.MinimumWidth = 150;
            this.ColumnSubject.Name = "ColumnSubject";
            // 
            // ColumnReceived
            // 
            this.ColumnReceived.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.ColumnReceived.HeaderText = "Received";
            this.ColumnReceived.Name = "ColumnReceived";
            this.ColumnReceived.Width = 5;
            // 
            // ColumnSize
            // 
            this.ColumnSize.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.ColumnSize.HeaderText = "Size";
            this.ColumnSize.Name = "ColumnSize";
            this.ColumnSize.Width = 5;
            // 
            // ColumnPrivacyLevel
            // 
            this.ColumnPrivacyLevel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.ColumnPrivacyLevel.HeaderText = string.Empty;
            this.ColumnPrivacyLevel.Name = "ColumnPrivacyLevel";
            this.ColumnPrivacyLevel.Width = 92;
            // 
            // ColumnFlag
            // 
            this.ColumnFlag.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.ColumnFlag.HeaderText = string.Empty;
            //this.ColumnFlag.Image = ((System.Drawing.Image)(resources.GetObject("ColumnFlag.Image")));
            this.ColumnFlag.Name = "ColumnFlag";
            this.ColumnFlag.Width = 5;
            // 
            // MailListPreview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._dataGridViewMails);
            this.Name = "MailListPreview";
            this.Size = new System.Drawing.Size(710, 484);
            ((System.ComponentModel.ISupportInitialize)(this._dataGridViewMails)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        #region Event
        private void _dataGridViewMails_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                List<MailItem> mails = OutlookInterface.ACTION_131_lister_mail("inbox");
                if (mails.Count > 0 && _dataGridViewMails.SelectedRows.Count > 0)
                { 
                    var mailselection = mails.Where(m => m.EntryID.Equals(_dataGridViewMails.Rows[_dataGridViewMails.SelectedRows[0].Index].Tag)).ToList();
                    if (mailselection != null && mailselection.Count == 1)
                    {
                        OnMailSelected(mailselection[0]);
                    }
                }
                else
                {
                    OnMailSelected(null);
                }
            }
            catch (System.Exception exp)
            {
                Console.WriteLine("Error while selecting a mail : " + exp.Message);
            }
        }
        private void _dataGridViewMails_Resize(object sender, EventArgs e)
        {
            if (_dataGridViewMails.Width > 500)
            {
                this.ColumnImportance.Visible = true;
                this.ColumnReminder.Visible = true;
                this.ColumnAttachment.Visible = true;
                this.ColumnSize.Visible = true;
                this.ColumnPrivacyLevel.Visible = true;
                this.ColumnFlag.Visible = true;
            }
            else
            {
                this.ColumnImportance.Visible = false;
                this.ColumnReminder.Visible = false;
                this.ColumnAttachment.Visible = false;
                this.ColumnSize.Visible = false;
                this.ColumnPrivacyLevel.Visible = false;
                this.ColumnFlag.Visible = false;
            }
        }
        #endregion
    }
}
