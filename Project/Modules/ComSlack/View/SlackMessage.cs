using System;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Droid.Communication
{
    public partial class SlackMessage : UserControl
    {
        #region Attributes
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private extern static int GetWindowLong(IntPtr hWnd, int index);

        private Message _currentMessage;
        private Member _currentMember;
        private SlackAdapter _slackAdapter;
        private readonly string[] SMILEY = new string[] { "wink", "skull", "grinning", "innocent", "slightly_smiling_face", "ok_hand", "pensive", "yeux_en_coeur", "déçu", "trollface", "joy" };
        #endregion

        #region Properties
        public Member CurrentMember
        {
            get { return _currentMember; }
            set { _currentMember = value; }
        }
        public SlackAdapter SlackAdapter
        {
            get { return _slackAdapter; }
            set { _slackAdapter = value; }
        }
        public Message CurrentMessage
        {
            get { return _currentMessage; }
            set { _currentMessage = value; }
        }
        #endregion

        #region Constructor
        public SlackMessage()
        {
            InitializeComponent();
            Init();
        }
        #endregion

        #region Methods public
        public void LoadMessage(SlackAdapter slackAdapter, Message message)
        {
            _currentMessage = message;
            _slackAdapter = slackAdapter;
            if (message.User != null)
            {
                _currentMember = _slackAdapter.Users.Where(s => s.Id.Equals(message.User)).First();
                pictureBox1.Load(_currentMember.Profile.Image_48);
                labelName.Text = _currentMember.Name;
            }
            if (_currentMessage != null)
            {
                System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
                dtDateTime = dtDateTime.AddSeconds(double.Parse(_currentMessage.Ts.Replace('.', ','))).ToLocalTime();
                labelDate.Text = dtDateTime.ToString("hh:mm tt");
                _textBox.Text = _currentMessage.Text;
                CleanTextBox();
                AddSmileys();
                AddReaction();
            }
        }
        #endregion

        #region Methods private
        private void Init()
        {
            this.Resize += SlackMessage_Resize;
        }
        private void CleanTextBox()
        {
            if (!string.IsNullOrEmpty(_textBox.Text) && Regex.IsMatch(_textBox.Text, "<(.*?)>"))
            {
                foreach (var item in Regex.Matches(_textBox.Text, "<http(.*?)>"))
                {
                    _textBox.Text = _textBox.Text.Replace(item.ToString(), item.ToString().Substring(1, item.ToString().Length - 2));
                }
                foreach (var item in Regex.Matches(_textBox.Text, "<(.*?)>"))
                {
                    foreach (var user in _slackAdapter.Users)
                    {
                        if (_textBox.Text.Contains(user.Id))
                        {
                            _textBox.Text = _textBox.Text.Replace(string.Format("<@{0}>", user.Id), string.Format("@{0}", user.Name));

                            //_textBox.Select(0, _textBox.Text.Length);
                            //_textBox.SelectionBackColor = System.Drawing.Color.Yellow;

                            //Select the line from it's number

                            string word = string.Format("@{0}", user.Name);
                            int startIndex = 0;
                            int index;

                            while ((index = _textBox.Text.IndexOf(word, startIndex)) != -1)
                            {
                                _textBox.Select(index, word.Length);
                                _textBox.SelectionBackColor = Color.Yellow;
                                startIndex = index + word.Length;
                            }


                            //int startIndex = _textBox.Find(string.Format("@{0}", user.Name));
                            //_textBox.Select(startIndex, string.Format("@{0}", user.Name).Length - 1);

                            ////Set the selected text fore and background color
                            //_textBox.SelectionBackColor = System.Drawing.Color.FromArgb(100, 255, 200, 0);
                        }
                    }
                }
            }
            _textBox.Text = _textBox.Text.Replace("<!channel>", "@Channel");
        }
        private void AddSmileys()
        {
            try
            {
                foreach (var item in SMILEY)
                {
                    ProcessSmiley(item);
                }
            }
            catch (Exception exp)
            {

            }
        }
        private void AddReaction()
        {
            if (_currentMessage.Reactions != null)
            {
                int index = labelName.Left + (labelName.Width/2) + 5;
                ButtonReaction br;
                foreach (Reaction reaction in _currentMessage.Reactions)
                {
                    br = new ButtonReaction();
                    br.LoadReaction(reaction);
                    br.Top = labelDate.Top - 2;
                    br.Left = index;
                    index += br.Width + 2;
                    this.Controls.Add(br);
                }
            }
        }
        private void ProcessSmiley(string smileyName)
        {
            while (_textBox.Text.Contains(string.Format(":{0}:", smileyName)))
            {
                _textBox.SelectionStart = _textBox.Find(string.Format(":{0}:", smileyName), RichTextBoxFinds.WholeWord);
                _textBox.SelectionLength = string.Format(":{0}:", smileyName).Length;

                Image img = (Image)Properties.Resources.ResourceManager.GetObject(smileyName);
                
                Bitmap bmp2 = new Bitmap(img.Width, img.Height);
                Rectangle rect = new Rectangle(Point.Empty, img.Size);
                using (Graphics G = Graphics.FromImage(bmp2))
                {
                    G.Clear(this.BackColor);
                    G.DrawImageUnscaledAndClipped(img, rect);
                }

                Clipboard.SetImage(bmp2);
                _textBox.Paste();
            }
        }
        private void ResizeComponent()
        {
            Size lengthText = TextRenderer.MeasureText(_textBox.Text, _textBox.Font);
            int boxWidth = this.Width == 0 ? 3 : this.Width;
            _textBox.Height = (lengthText.Width * 18) / (boxWidth / 3);
            if (_textBox.Height < 18) { _textBox.Height = 18; }
            this.Height = _textBox.Height + 33;
        }
        #endregion

        #region Event
        private void SlackMessage_Resize(object sender, EventArgs e)
        {
            ResizeComponent();
        }
        #endregion
    }
}
