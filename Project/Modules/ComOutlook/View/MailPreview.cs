using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Interop.Outlook;
using System.IO;
using System.Text.RegularExpressions;

namespace Droid.Communication.Outlook
{
    public delegate void MailPreviewEventHandler(object obj, object parent);
    public partial class MailPreview : UserControl
    {
        #region Attribute
        public event MailPreviewEventHandler SendMail;

        private MailItem _mail;
        private System.ComponentModel.IContainer _components = null;
        private System.Windows.Forms.Panel _panelInfo;
        private System.Windows.Forms.WebBrowser _webBrowserMessage;
        private System.Windows.Forms.Label _labelSubject;
        private System.Windows.Forms.Label _labelSender;
        private System.Windows.Forms.Label _labelTitle;
        private System.Windows.Forms.Label _labelCCValue;
        private System.Windows.Forms.Label _labelToValue;
        private System.Windows.Forms.Label _labelTitleValue;
        private System.Windows.Forms.Label _labelCC;
        private System.Windows.Forms.Label _labelTo;
        private System.Windows.Forms.TextBox _textBoxMessage;
        private TextBox _textBoxTitle;
        private TextBox _textBoxCC;
        private TextBox _textBoxTo;
        private Button _buttonSend;
        private bool _readOnly;
        #endregion

        #region Properties
        public MailItem Mail
        {
            get { return _mail; }
            set
            {
                _mail = value;
                LoadMail();
            }
        }
        public bool ReadOnly
        {
            get { return _readOnly; }
            set
            {
                _readOnly = value;
                _textBoxMessage.ReadOnly = _readOnly;
                _textBoxMessage.Visible = !_readOnly;
                _webBrowserMessage.Visible = _readOnly;
                if (_readOnly)
                {
                    _textBoxTitle.Visible = false;
                    _textBoxTo.Visible = false;
                    _textBoxCC.Visible = false;
                    _textBoxTitle.Left = 70;
                    _textBoxTo.Left = 70;
                    _textBoxCC.Left = 70;
                    _labelTitleValue.Visible = true;
                    _labelCCValue.Visible = true;
                    _labelToValue.Visible = true;
                    _labelTitleValue.Left = 70;
                    _labelCCValue.Left = 70;
                    _labelToValue.Left = 70;
                    _labelTitle.Left = 6;
                    _labelCC.Left = 6;
                    _labelTo.Left = 6;
                    _buttonSend.Visible = false;
                }
                else
                {
                    _textBoxTitle.Visible = true;
                    _textBoxTo.Visible = true;
                    _textBoxCC.Visible = true;
                    _textBoxTitle.Left = 130;
                    _textBoxTo.Left = 130;
                    _textBoxCC.Left = 130;
                    _labelTitleValue.Visible = false;
                    _labelCCValue.Visible = false;
                    _labelToValue.Visible = false;
                    _labelTitleValue.Left = 130;
                    _labelCCValue.Left = 130;
                    _labelToValue.Left = 130;
                    _labelTitle.Left = 69;
                    _labelCC.Left = 69;
                    _labelTo.Left = 69;
                    _buttonSend.Visible = true;
                    _labelSender.Text = OutlookInterface.ACTION_133_donner_login();
                }
            }
        }
        #endregion

        #region Constructor
        public MailPreview()
        {
            InitializeComponent();
            ReadOnly = true;
        }
        #endregion

        #region Methods public
        #endregion

        #region Methods protected
        protected override void Dispose(bool disposing)
        {
            if (disposing && (_components != null))
            {
                _components.Dispose();
            }
            base.Dispose(disposing);
        }
        #endregion

        #region Methods private
        private void LoadMail()
        {
            Color col = Color.Black;
            string body, bodyWork;
            string fileName;
            int indexAttachment = 0;
            try
            {
                if (_mail != null)
                {
                    if (DownloadAttachment(_mail))  { col = Color.Gainsboro; }
                    else { col = Color.Orange; }
                    this.BackColor = col;
                    
                    switch (_mail.BodyFormat)
                    {
                        case OlBodyFormat.olFormatRichText:
                            _webBrowserMessage.DocumentText = _mail.Body;
                            _textBoxMessage.Visible = false;
                            _webBrowserMessage.Visible = true;
                            break;
                        case OlBodyFormat.olFormatPlain:
                            _textBoxMessage.Text = _mail.Body;
                            _textBoxMessage.Visible = true;
                            _webBrowserMessage.Visible = false;
                            break;
                        case OlBodyFormat.olFormatHTML:
                        default:
                            body = _mail.HTMLBody.Replace("cid:", string.Format("{0}\\DroidCom\\{1}\\", Environment.CurrentDirectory, Mail.EntryID));
                            body = Regex.Replace(body, "@([0-9]|[A-Z]|[\\.])*\"", "\"");
                            bodyWork = body;
                            string[] attachementFiles = Directory.GetFiles(string.Format("{0}\\DroidCom\\{1}\\", Environment.CurrentDirectory, Mail.EntryID));
                            foreach (var item in Regex.Split(bodyWork, Mail.EntryID))
                            {
                                if (item != body && !body.StartsWith(item) && indexAttachment < attachementFiles.Length)
                                {
                                    try
                                    {
                                        fileName = string.Format("{0}\\DroidCom\\{1}\\", Environment.CurrentDirectory, Mail.EntryID) + item.Split('"')[0].Split('/')[item.Split('"')[0].Split('/').Length - 1];
                                        if (!File.Exists(fileName))
                                        { 
                                            File.Move(attachementFiles[indexAttachment], fileName);
                                        }
                                        body = body.Replace(item.Split('"')[0], "\\" + item.Split('"')[0].Split('/')[item.Split('"')[0].Split('/').Length - 1]);
                                    }
                                    catch (System.Exception exp)
                                    {
                                        Console.WriteLine(exp.Message);
                                    }
                                    indexAttachment++;
                                }
                            }

                            _webBrowserMessage.DocumentText = body;
                            _webBrowserMessage.Refresh();
                            _textBoxMessage.Visible = false;
                            _webBrowserMessage.Visible = true;
                            break;
                    }
                    _labelSender.Text = _mail.SenderName;
                    _labelSubject.Text = _mail.Subject;
                    _labelTitleValue.Text = _mail.ReceivedTime.ToString("ddd dd/MM/yyyy HH:mm:ss");
                    _labelToValue.Text = _mail.To;
                    _labelCCValue.Text = _mail.CC;
                }
                else
                {
                    _webBrowserMessage.DocumentText = string.Empty;
                    _textBoxMessage.Text = string.Empty;
                }
            }
            catch (System.Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }
        public static bool DownloadAttachment(MailItem mail)
        {
            string extention;
            string[] whitListExt = { "png", "jpg", "jpeg", "gif", "bin" };
            if (!Directory.Exists(Environment.CurrentDirectory + "\\DroidCom\\")) { Directory.CreateDirectory(Environment.CurrentDirectory + "\\DroidCom\\"); }
            if (!Directory.Exists(Environment.CurrentDirectory + "\\DroidCom\\" + mail.EntryID)) { Directory.CreateDirectory(Environment.CurrentDirectory + "\\DroidCom\\" + mail.EntryID); }
            foreach (var attachment in mail.Attachments)
            {
                try
                {
                    var a = attachment;
                    Attachment at = a as Attachment;
                    extention = at.FileName.Split('.')[at.FileName.Split('.').Length - 1];
                    
                    if (whitListExt.Contains(extention.ToLower()))
                    {
                        if (!File.Exists(Environment.CurrentDirectory + "\\DroidCom\\" + mail.EntryID + "\\" + at.FileName))
                        {
                            at.SaveAsFile(Environment.CurrentDirectory + "\\DroidCom\\" + mail.EntryID + "\\" + at.FileName);
                            try
                            {
                                Image img = Image.FromFile(Environment.CurrentDirectory + "\\DroidCom\\" + mail.EntryID + "\\" + at.FileName);
                            }
                            catch (System.Exception)
                            {
                                File.Delete(Environment.CurrentDirectory + "\\DroidCom\\" + mail.EntryID + "\\" + at.FileName);
                                return false;
                            }
                        }
                    }
                }
                catch (System.Exception epxAtt)
                {
                    Console.WriteLine(epxAtt.Message);
                    return false;
                }
            }
            return true;
        }
        private void InitializeComponent()
        {
            this._panelInfo = new System.Windows.Forms.Panel();
            this._buttonSend = new System.Windows.Forms.Button();
            this._textBoxCC = new System.Windows.Forms.TextBox();
            this._textBoxTo = new System.Windows.Forms.TextBox();
            this._textBoxTitle = new System.Windows.Forms.TextBox();
            this._labelCCValue = new System.Windows.Forms.Label();
            this._labelToValue = new System.Windows.Forms.Label();
            this._labelTitleValue = new System.Windows.Forms.Label();
            this._labelCC = new System.Windows.Forms.Label();
            this._labelTo = new System.Windows.Forms.Label();
            this._labelTitle = new System.Windows.Forms.Label();
            this._labelSender = new System.Windows.Forms.Label();
            this._labelSubject = new System.Windows.Forms.Label();
            this._webBrowserMessage = new System.Windows.Forms.WebBrowser();
            this._textBoxMessage = new System.Windows.Forms.TextBox();
            this._panelInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // _panelInfo
            // 
            this._panelInfo.BackColor = System.Drawing.Color.Gainsboro;
            this._panelInfo.Controls.Add(this._buttonSend);
            this._panelInfo.Controls.Add(this._textBoxCC);
            this._panelInfo.Controls.Add(this._textBoxTo);
            this._panelInfo.Controls.Add(this._textBoxTitle);
            this._panelInfo.Controls.Add(this._labelCCValue);
            this._panelInfo.Controls.Add(this._labelToValue);
            this._panelInfo.Controls.Add(this._labelTitleValue);
            this._panelInfo.Controls.Add(this._labelCC);
            this._panelInfo.Controls.Add(this._labelTo);
            this._panelInfo.Controls.Add(this._labelTitle);
            this._panelInfo.Controls.Add(this._labelSender);
            this._panelInfo.Controls.Add(this._labelSubject);
            this._panelInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this._panelInfo.Location = new System.Drawing.Point(0, 0);
            this._panelInfo.Name = "_panelInfo";
            this._panelInfo.Size = new System.Drawing.Size(475, 107);
            this._panelInfo.TabIndex = 6;
            // 
            // _buttonSend
            // 
            this._buttonSend.Location = new System.Drawing.Point(7, 46);
            this._buttonSend.Name = "_buttonSend";
            this._buttonSend.Size = new System.Drawing.Size(56, 57);
            this._buttonSend.TabIndex = 5;
            this._buttonSend.Text = "Send";
            this._buttonSend.UseVisualStyleBackColor = true;
            this._buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // _textBoxCC
            // 
            this._textBoxCC.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._textBoxCC.Font = new System.Drawing.Font("Calibri", 8.25F);
            this._textBoxCC.Location = new System.Drawing.Point(130, 82);
            this._textBoxCC.Name = "_textBoxCC";
            this._textBoxCC.Size = new System.Drawing.Size(342, 21);
            this._textBoxCC.TabIndex = 3;
            this._textBoxCC.Visible = false;
            // 
            // _textBoxTo
            // 
            this._textBoxTo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._textBoxTo.Font = new System.Drawing.Font("Calibri", 8.25F);
            this._textBoxTo.Location = new System.Drawing.Point(130, 63);
            this._textBoxTo.Name = "_textBoxTo";
            this._textBoxTo.Size = new System.Drawing.Size(342, 21);
            this._textBoxTo.TabIndex = 2;
            this._textBoxTo.Visible = false;
            // 
            // _textBoxTitle
            // 
            this._textBoxTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._textBoxTitle.Font = new System.Drawing.Font("Calibri", 8.25F);
            this._textBoxTitle.Location = new System.Drawing.Point(130, 43);
            this._textBoxTitle.Name = "_textBoxTitle";
            this._textBoxTitle.Size = new System.Drawing.Size(342, 21);
            this._textBoxTitle.TabIndex = 1;
            this._textBoxTitle.Visible = false;
            // 
            // _labelCCValue
            // 
            this._labelCCValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._labelCCValue.BackColor = System.Drawing.Color.Transparent;
            this._labelCCValue.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._labelCCValue.Location = new System.Drawing.Point(130, 81);
            this._labelCCValue.Name = "_labelCCValue";
            this._labelCCValue.Size = new System.Drawing.Size(339, 14);
            this._labelCCValue.TabIndex = 7;
            this._labelCCValue.Text = "__________";
            this._labelCCValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _labelToValue
            // 
            this._labelToValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._labelToValue.BackColor = System.Drawing.Color.Transparent;
            this._labelToValue.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._labelToValue.Location = new System.Drawing.Point(130, 62);
            this._labelToValue.Name = "_labelToValue";
            this._labelToValue.Size = new System.Drawing.Size(339, 14);
            this._labelToValue.TabIndex = 6;
            this._labelToValue.Text = "__________";
            this._labelToValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _labelTitleValue
            // 
            this._labelTitleValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._labelTitleValue.BackColor = System.Drawing.Color.Transparent;
            this._labelTitleValue.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._labelTitleValue.Location = new System.Drawing.Point(130, 43);
            this._labelTitleValue.Name = "_labelTitleValue";
            this._labelTitleValue.Size = new System.Drawing.Size(339, 14);
            this._labelTitleValue.TabIndex = 5;
            this._labelTitleValue.Text = "__________";
            this._labelTitleValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _labelCC
            // 
            this._labelCC.BackColor = System.Drawing.Color.Transparent;
            this._labelCC.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._labelCC.Location = new System.Drawing.Point(69, 84);
            this._labelCC.Name = "_labelCC";
            this._labelCC.Size = new System.Drawing.Size(55, 14);
            this._labelCC.TabIndex = 4;
            this._labelCC.Text = "CC :";
            this._labelCC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _labelTo
            // 
            this._labelTo.BackColor = System.Drawing.Color.Transparent;
            this._labelTo.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._labelTo.Location = new System.Drawing.Point(69, 65);
            this._labelTo.Name = "_labelTo";
            this._labelTo.Size = new System.Drawing.Size(55, 14);
            this._labelTo.TabIndex = 3;
            this._labelTo.Text = "To :";
            this._labelTo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _labelTitle
            // 
            this._labelTitle.BackColor = System.Drawing.Color.Transparent;
            this._labelTitle.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._labelTitle.Location = new System.Drawing.Point(69, 46);
            this._labelTitle.Name = "_labelTitle";
            this._labelTitle.Size = new System.Drawing.Size(55, 14);
            this._labelTitle.TabIndex = 2;
            this._labelTitle.Text = "Title :";
            this._labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _labelSender
            // 
            this._labelSender.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._labelSender.BackColor = System.Drawing.Color.Transparent;
            this._labelSender.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._labelSender.Location = new System.Drawing.Point(6, 23);
            this._labelSender.Name = "_labelSender";
            this._labelSender.Size = new System.Drawing.Size(463, 20);
            this._labelSender.TabIndex = 1;
            this._labelSender.Text = "Sender";
            this._labelSender.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _labelSubject
            // 
            this._labelSubject.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._labelSubject.BackColor = System.Drawing.Color.Transparent;
            this._labelSubject.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._labelSubject.Location = new System.Drawing.Point(3, 0);
            this._labelSubject.Name = "_labelSubject";
            this._labelSubject.Size = new System.Drawing.Size(466, 23);
            this._labelSubject.TabIndex = 0;
            this._labelSubject.Text = "Subject";
            this._labelSubject.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _webBrowserMessage
            // 
            this._webBrowserMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._webBrowserMessage.Location = new System.Drawing.Point(3, 109);
            this._webBrowserMessage.MinimumSize = new System.Drawing.Size(20, 20);
            this._webBrowserMessage.Name = "_webBrowserMessage";
            this._webBrowserMessage.Size = new System.Drawing.Size(469, 369);
            this._webBrowserMessage.TabIndex = 4;
            // 
            // _textBoxMessage
            // 
            this._textBoxMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._textBoxMessage.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._textBoxMessage.Location = new System.Drawing.Point(3, 109);
            this._textBoxMessage.Multiline = true;
            this._textBoxMessage.Name = "_textBoxMessage";
            this._textBoxMessage.Size = new System.Drawing.Size(469, 369);
            this._textBoxMessage.TabIndex = 4;
            this._textBoxMessage.Visible = false;
            // 
            // MailPreview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.Controls.Add(this._textBoxMessage);
            this.Controls.Add(this._webBrowserMessage);
            this.Controls.Add(this._panelInfo);
            this.Name = "MailPreview";
            this.Size = new System.Drawing.Size(475, 481);
            this._panelInfo.ResumeLayout(false);
            this._panelInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        #region Event
        private void buttonSend_Click(object sender, EventArgs e)
        {
            if (SendMail != null)
            {
                Dictionary<string, string> mailDetail = new Dictionary<string, string>();
                mailDetail["title"] = _textBoxTitle.Text;
                mailDetail["to"] = _textBoxTo.Text;
                mailDetail["cc"] = _textBoxCC.Text;
                mailDetail["message"] = _textBoxMessage.Text;
                SendMail(mailDetail, this.Parent);
            }
        }
        #endregion
    }
}
