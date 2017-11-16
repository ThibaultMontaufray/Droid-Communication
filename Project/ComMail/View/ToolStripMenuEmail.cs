using System;
using System.Windows.Forms;
using Tools4Libraries;

namespace Droid_communication
{
    public class ToolStripMenuEmail : TSM
    {
        #region Attributes
        public event EventHandlerAction ActionAppened;

        private RibbonPanel _panelNew;
        private RibbonButton _newMail;
        private RibbonButton _newElement;

        private RibbonPanel _panelDelete;
        private RibbonButton _delSpam;
        private RibbonButton _del;

        private RibbonPanel _panelAnswer;
        private RibbonButton _answer;
        private RibbonButton _answerAll;
        private RibbonButton _answerTransfert;
        private RibbonButton _answerDirectMessage;

        private RibbonPanel _panelTools;
        private RibbonButton _toolsNoConnection;
        private RibbonButton _toolsSendReceive;

        private RibbonPanel _panelMailBox;
        private RibbonButton _mailBoxConnection;
        private RibbonButton _mailBoxSetting;
        private RibbonButton _mailBoxInbox;

        private InterfaceEmail _intEmail;
        #endregion

        #region Properties
        #endregion

        #region Constructor
        public ToolStripMenuEmail(InterfaceEmail intEmail)
        {
            _intEmail = intEmail;
            Init();
        }
        #endregion

        #region Methods public
        public void OnAction(EventArgs e)
        {
            if (ActionAppened != null) ActionAppened(this, e);
        }
        public void UpdateLanguage()
        {
            _newElement.Text = GetText.Text(_newElement.Name);
            _newMail.Text = GetText.Text(_newMail.Name);
            _newElement.Text = GetText.Text(_newElement.Name);
            _delSpam.Text = GetText.Text(_delSpam.Name);
            _del.Text = GetText.Text(_del.Name);
            _newElement.Text = GetText.Text(_answer.Name);
            _answerAll.Text = GetText.Text(_answerAll.Name);
            _answerDirectMessage.Text = GetText.Text(_answerDirectMessage.Name);
            _answerTransfert.Text = GetText.Text(_answerTransfert.Name);
            _toolsNoConnection.Text = GetText.Text(_toolsNoConnection.Name);
            _toolsSendReceive.Text = GetText.Text(_toolsSendReceive.Name);
            _mailBoxConnection.Text = GetText.Text(_mailBoxConnection.Name);
            _mailBoxInbox.Text = GetText.Text(_mailBoxInbox.Name);
            _mailBoxSetting.Text = GetText.Text(_mailBoxSetting.Name);
            this.Text = GetText.Text("Email");
            
            _panelAnswer.Text = GetText.Text(_panelAnswer.Name);
            _panelMailBox.Text = GetText.Text(_panelMailBox.Name);
            _panelDelete.Text = GetText.Text(_panelDelete.Name);
            _panelNew.Text = GetText.Text(_panelNew.Name);
            _panelTools.Text = GetText.Text(_panelTools.Name);
        }
        public void RefreshData()
        {

        }
        #endregion

        #region Methods private
        private void Init()
        {
            BuildPanelNew();
            BuildPanelDelete();
            BuildPanelAnswer();
            BuildPanelTools();
            BuildPanelMailBox();
            this.Text = GetText.Text("Email");
        }
        private void BuildPanelNew()
        {
            _newMail = new RibbonButton();
            _newMail.Name = "NewMail";
            _newMail.Text = GetText.Text(_newMail.Name);
            _newMail.ToolTip = GetText.Text(_newMail.Name);
            _newMail.Click += new EventHandler(tsb_Click);
            _newMail.Image = Tools4Libraries.Resources.ResourceIconSet32Default.email;
            _newMail.SmallImage = Tools4Libraries.Resources.ResourceIconSet16Default.email;
            _newMail.MinSizeMode = RibbonElementSizeMode.Large;

            _newElement = new RibbonButton();
            _newElement.Name = "NewElement";
            _newElement.Text = GetText.Text(_newElement.Name);
            _newElement.ToolTip = GetText.Text(_newElement.Name);
            _newElement.Click += new EventHandler(tsb_Click);
            _newElement.Image = Tools4Libraries.Resources.ResourceIconSet32Default.elements;
            _newElement.SmallImage = Tools4Libraries.Resources.ResourceIconSet16Default.elements;
            _newElement.MinSizeMode = RibbonElementSizeMode.Large;

            _panelNew = new RibbonPanel();
            _panelNew.Name = "New";
            _panelNew.Text = GetText.Text(_panelNew.Name);
            _panelNew.Items.Add(_newMail);
            _panelNew.Items.Add(_newElement);
            this.Panels.Add(_panelNew);
        }
        private void BuildPanelDelete()
        {
            _delSpam = new RibbonButton();
            _delSpam.Name = "DelMail";
            _delSpam.Text = GetText.Text(_delSpam.Name);
            _delSpam.ToolTip = GetText.Text(_delSpam.Name);
            _delSpam.Click += new EventHandler(tsb_Click);
            _delSpam.Image = Tools4Libraries.Resources.ResourceIconSet32Default.email_delete;
            _delSpam.SmallImage = Tools4Libraries.Resources.ResourceIconSet16Default.email_delete;
            _delSpam.MinSizeMode = RibbonElementSizeMode.Large;

            _del= new RibbonButton();
            _del.Name = "Delete";
            _del.Text = GetText.Text(_delSpam.Name);
            _del.ToolTip = GetText.Text(_delSpam.Name);
            _del.Click += new EventHandler(tsb_Click);
            _del.Image = Tools4Libraries.Resources.ResourceIconSet32Default.delete;
            _del.SmallImage = Tools4Libraries.Resources.ResourceIconSet16Default.delete;
            _del.MinSizeMode = RibbonElementSizeMode.Large;

            _panelDelete = new RibbonPanel();
            _panelDelete.Name = "Delete";
            _panelDelete.Text = GetText.Text(_panelDelete.Name);
            _panelDelete.Items.Add(_delSpam);
            _panelDelete.Items.Add(_del);
            this.Panels.Add(_panelDelete);
        }
        private void BuildPanelAnswer()
        {
        //private RibbonButton _answerTransfert;
        //private RibbonButton _answerDirectMessage;

            _answer = new RibbonButton();
            _answer.Name = "Answer";
            _answer.Text = GetText.Text(_answer.Name);
            _answer.ToolTip = GetText.Text(_answer.Name);
            _answer.Click += new EventHandler(tsb_Click);
            _answer.Image = Tools4Libraries.Resources.ResourceIconSet32Default.email_to_friend;
            _answer.SmallImage = Tools4Libraries.Resources.ResourceIconSet16Default.email_to_friend;
            _answer.MinSizeMode = RibbonElementSizeMode.Large;

            _answerAll = new RibbonButton();
            _answerAll.Name = "AnswerAll";
            _answerAll.Text = GetText.Text(_answerAll.Name);
            _answerAll.ToolTip = GetText.Text(_answerAll.Name);
            _answerAll.Click += new EventHandler(tsb_Click);
            _answerAll.Image = Tools4Libraries.Resources.ResourceIconSet32Default.email_go;
            _answerAll.SmallImage = Tools4Libraries.Resources.ResourceIconSet16Default.email_go;
            _answerAll.MinSizeMode = RibbonElementSizeMode.Large;

            _answerTransfert = new RibbonButton();
            _answerTransfert.Name = "Transfert";
            _answerTransfert.Text = GetText.Text(_answerTransfert.Name);
            _answerTransfert.ToolTip = GetText.Text(_answerTransfert.Name);
            _answerTransfert.Click += new EventHandler(tsb_Click);
            _answerTransfert.Image = Tools4Libraries.Resources.ResourceIconSet32Default.email_link;
            _answerTransfert.SmallImage = Tools4Libraries.Resources.ResourceIconSet16Default.email_link;
            _answerTransfert.MinSizeMode = RibbonElementSizeMode.Large;

            _answerDirectMessage = new RibbonButton();
            _answerDirectMessage.Name = "DirectMessage";
            _answerDirectMessage.Text = GetText.Text(_answerDirectMessage.Name);
            _answerDirectMessage.ToolTip = GetText.Text(_answerDirectMessage.Name);
            _answerDirectMessage.Click += new EventHandler(tsb_Click);
            _answerDirectMessage.Image = Tools4Libraries.Resources.ResourceIconSet32Default.messenger;
            _answerDirectMessage.SmallImage = Tools4Libraries.Resources.ResourceIconSet16Default.messenger;
            _answerDirectMessage.MinSizeMode = RibbonElementSizeMode.Large;

            _panelAnswer = new RibbonPanel();
            _panelAnswer.Name = "Answer";
            _panelAnswer.Text = GetText.Text(_panelAnswer.Name);
            _panelAnswer.Items.Add(_answer);
            _panelAnswer.Items.Add(_answerAll);
            _panelAnswer.Items.Add(_answerTransfert);
            _panelAnswer.Items.Add(_answerDirectMessage);
            this.Panels.Add(_panelAnswer);
        }
        private void BuildPanelTools()
        {
            _toolsSendReceive = new RibbonButton();
            _toolsSendReceive.Name = "SendReceive";
            _toolsSendReceive.Text = GetText.Text(_toolsSendReceive.Name);
            _toolsSendReceive.ToolTip = GetText.Text(_toolsSendReceive.Name);
            _toolsSendReceive.Click += new EventHandler(tsb_Click);
            _toolsSendReceive.Image = Tools4Libraries.Resources.ResourceIconSet32Default.documents_email;
            _toolsSendReceive.SmallImage = Tools4Libraries.Resources.ResourceIconSet16Default.documents_email;
            _toolsSendReceive.MinSizeMode = RibbonElementSizeMode.Large;

            _toolsNoConnection = new RibbonButton();
            _toolsNoConnection.Name = "NoConnection";
            _toolsNoConnection.Text = GetText.Text(_toolsNoConnection.Name);
            _toolsNoConnection.ToolTip = GetText.Text(_toolsNoConnection.Name);
            _toolsNoConnection.Click += new EventHandler(tsb_Click);
            _toolsNoConnection.Image = Tools4Libraries.Resources.ResourceIconSet32Default.contact_email;
            _toolsNoConnection.SmallImage = Tools4Libraries.Resources.ResourceIconSet16Default.contact_email;
            _toolsNoConnection.MinSizeMode = RibbonElementSizeMode.Large;

            _panelTools = new RibbonPanel();
            _panelTools.Name = "Tools";
            _panelTools.Text = GetText.Text(_panelTools.Name);
            _panelTools.Items.Add(_toolsSendReceive);
            _panelTools.Items.Add(_toolsNoConnection);
            this.Panels.Add(_panelTools);
        }
        private void BuildPanelMailBox()
        {
            _mailBoxConnection = new RibbonButton();
            _mailBoxConnection.Name = "Connection";
            _mailBoxConnection.Text = GetText.Text(_mailBoxConnection.Name);
            _mailBoxConnection.ToolTip = GetText.Text(_mailBoxConnection.Name);
            _mailBoxConnection.Click += new EventHandler(tsb_Click);
            _mailBoxConnection.Image = Tools4Libraries.Resources.ResourceIconSet32Default.connect;
            _mailBoxConnection.SmallImage = Tools4Libraries.Resources.ResourceIconSet16Default.connect;
            _mailBoxConnection.MinSizeMode = RibbonElementSizeMode.Large;

            _mailBoxSetting = new RibbonButton();
            _mailBoxSetting.Name = "Setting";
            _mailBoxSetting.Text = GetText.Text(_mailBoxSetting.Name);
            _mailBoxSetting.ToolTip = GetText.Text(_mailBoxSetting.Name);
            _mailBoxSetting.Click += new EventHandler(tsb_Click);
            _mailBoxSetting.Image = Tools4Libraries.Resources.ResourceIconSet32Default.mail_server_setting;
            _mailBoxSetting.SmallImage = Tools4Libraries.Resources.ResourceIconSet16Default.mail_server_setting;
            _mailBoxSetting.MinSizeMode = RibbonElementSizeMode.Large;

            _mailBoxInbox = new RibbonButton();
            _mailBoxInbox.Name = "Inbox";
            _mailBoxInbox.Text = GetText.Text(_mailBoxInbox.Name);
            _mailBoxInbox.ToolTip = GetText.Text(_mailBoxInbox.Name);
            _mailBoxInbox.Click += new EventHandler(tsb_Click);
            _mailBoxInbox.Image = Tools4Libraries.Resources.ResourceIconSet32Default.mail_box;
            _mailBoxInbox.SmallImage = Tools4Libraries.Resources.ResourceIconSet16Default.mail_box;
            _mailBoxInbox.MinSizeMode = RibbonElementSizeMode.Large;

            _panelMailBox = new RibbonPanel();
            _panelMailBox.Name = "Mailbox";
            _panelMailBox.Text = GetText.Text(_panelMailBox.Name);
            _panelMailBox.Items.Add(_mailBoxInbox);
            _panelMailBox.Items.Add(_mailBoxConnection);
            _panelMailBox.Items.Add(_mailBoxSetting);
            this.Panels.Add(_panelMailBox);
        }
        #endregion

        #region Event
        private void tsb_Click(object sender, EventArgs e)
        {
            if (sender is RibbonButton)
            { 
                RibbonButton rb = sender as RibbonButton;
                ToolBarEventArgs action = new ToolBarEventArgs(rb.Name);
                OnAction(action);
            }
            else
            {
                throw new NotImplementedException();
            }
        }
        #endregion
    }
}
