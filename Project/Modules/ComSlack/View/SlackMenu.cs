using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Droid.Communication.Modules.ComSlack.View;

namespace Droid.Communication
{
    public delegate void SlackMenuEventHandler(object o);
    public partial class SlackMenu : UserControl
    {
        #region Attributes
        public event SlackMenuEventHandler OnChannelChanged;
        public event SlackMenuEventHandler OnUserChanged;
        public event SlackMenuEventHandler OnChannelsLoaded;
        public event SlackMenuEventHandler OnUsersLoaded;
        public event SlackMenuEventHandler OnInfoLoaded;
        private SlackAdapter _adapter;

        private TreeView _tmpTnChannels;
        private TreeView _tmpTnUsers;
        #endregion

        #region Properties
        public SlackAdapter Adapter
        {
            get { return _adapter; }
            set { _adapter = value; }
        }
        #endregion

        #region Construction
        public SlackMenu()
        {
            InitializeComponent();
            Init();
        }
        public SlackMenu(SlackAdapter adapter)
        {
            _adapter = adapter;
            InitializeComponent();
            Init();
        }
        #endregion

        #region Methods public
        public async void RefreshData()
        {
            try
            {
                _adapter.OnMessagesUpdated += _slackAdapter_OnMessagesUpdated;

                Task tInfo = new Task(LoadInfo);
                tInfo.Start();
                await tInfo;
                OnInfoLoaded?.Invoke(null);

                Task tChannels = new Task(LoadChannels);
                tChannels.Start();
                await tChannels;
                OnChannelsLoaded?.Invoke(null);

                Task tUsers = new Task(LoadUsers);
                tUsers.Start();
                await tUsers;
                OnUsersLoaded?.Invoke(null);
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }
        #endregion

        #region Methods private
        private void Init()
        {
            OnChannelsLoaded += _slackMenu_OnChannelsLoaded;
            OnInfoLoaded += _slackMenu_OnInfoLoaded;
            OnUsersLoaded += _slackMenu_OnUsersLoaded;
        }
        private void LoadChannels()
        {
            try
            {
                TreeNode tn;
                if (_tmpTnChannels == null) { _tmpTnChannels = new TreeView(); }
                _tmpTnChannels.Nodes.Clear();
                if (Adapter.Channels != null)
                {
                    TreeNode root = _tmpTnChannels.Nodes.Add("Channels");
                    root.ImageIndex = -1;
                    root.ImageKey = "";
                    foreach (Channel item in Adapter.Channels.Where(c => !c.Is_Archived && c.Is_Member).OrderBy(c => c.Name))
                    {
                        tn = new TreeNode(item.Name);
                        tn.Tag = item;
                        root.Nodes.Add(tn);
                    }
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }
        private void LoadUsers()
        {
            try
            {
                Status connected;
                TreeNode tn;
                if (_tmpTnUsers == null) { _tmpTnUsers = new TreeView(); }
                _tmpTnUsers.Nodes.Clear();
                if (Adapter.Users != null)
                {
                    TreeNode root = _tmpTnUsers.Nodes.Add("Members");
                    root.ImageIndex = -1;
                    root.ImageKey = null;
                    foreach (Member item in Adapter.Users)
                    {
                        connected = UserControler.GetStatus(_adapter, item);
                        tn = new TreeNode(item.Name);
                        tn.Tag = item;
                        switch (connected.Presence)
                        {
                            case "active":
                                tn.ImageKey = connected.Last_Activity == null ? "connected" : "unactive";
                                break;
                            case "away":
                                tn.ImageKey = "disconnected";
                                break;
                            default:
                                tn.ImageKey = "unknow";
                                break;
                        }
                        tn.ImageIndex = imageListStatus.Images.IndexOfKey(tn.ImageKey);
                        root.Nodes.Add(tn);
                    }
                    root.ExpandAll();
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }
        private void LoadInfo()
        {
            try
            {
                if (_adapter.Team != null)
                {
                    labelTitle.Text = _adapter.Team.Name;
                    pictureBoxIcon.Load(_adapter.Team.Icon.Image_34);
                }
                else
                {
                    labelTitle.Text = "Slack";
                    pictureBoxIcon.Image = null;
                }
                if (_adapter.CurrentUser != null)
                { 
                    labelCurrentUser.Text = _adapter.CurrentUser.Profile?.Real_Name;
                    SetStatus();
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }
        private void SetStatus()
        {
            Status status = UserControler.GetStatus(_adapter, _adapter.CurrentUser);
            if (status != null &&  status.Presence != null)
            { 
                switch (status.Presence)
                {
                    case "active":
                        pictureBoxStatus.Image = status.Last_Activity == null ? imageListStatus.Images[imageListStatus.Images.IndexOfKey("connected")] : imageListStatus.Images[imageListStatus.Images.IndexOfKey("disconnected")];
                        break;
                    case "away":
                        pictureBoxStatus.Image = imageListStatus.Images[imageListStatus.Images.IndexOfKey("disconnected")];
                        break;
                    default:
                        pictureBoxStatus.Image = imageListStatus.Images[imageListStatus.Images.IndexOfKey("unknow")];
                        break;
                }
            }
            else
            {
                pictureBoxStatus.Image = imageListStatus.Images[imageListStatus.Images.IndexOfKey("unknow")];
            }
        }
        private void UpdateTreeNodeUsers()
        {
            Copy(_tmpTnUsers, _treeViewUsers);
            _treeViewUsers.ExpandAll();
            panelUsers.Height = 30 + _treeViewUsers.Nodes[0].Nodes.Count * 20;
            this.Refresh();
            this.Invalidate();
        }
        private void UpdateTreeNodeChannels()
        {
            Copy(_tmpTnChannels, _treeViewChannels);
            _treeViewChannels.ExpandAll();
            panelChannels.Height = 30 + _treeViewChannels.Nodes[0].Nodes.Count * 20;
            this.Refresh();
            this.Invalidate();
        }
        private void Copy(TreeView treeviewSrc, TreeView treeviewTarget)
        {
            TreeNode newTn;
            if (treeviewTarget != null) { treeviewTarget.Nodes.Clear(); }
            foreach (TreeNode tn in treeviewSrc.Nodes)
            {
                newTn = new TreeNode(tn.Text, tn.ImageIndex, tn.SelectedImageIndex);
                newTn.Tag = tn.Tag;
                CopyChilds(newTn, tn);
                treeviewTarget.Nodes.Add(newTn);
            }
        }
        private void CopyChilds(TreeNode parent, TreeNode willCopied)
        {
            TreeNode newTn;
            foreach (TreeNode tn in willCopied.Nodes)
            {
                newTn = new TreeNode(tn.Text, tn.ImageIndex, tn.SelectedImageIndex);
                newTn.Tag = tn.Tag;
                parent.Nodes.Add(newTn);
            }
        }
        private void ParseMessage(Message msg)
        {
            foreach (TreeNode node in _treeViewChannels.Nodes)
            {
                if (((Channel)node.Tag).Id.Equals(msg.Channel))
                {
                    node.NodeFont = new Font(_treeViewChannels.Font, FontStyle.Bold);
                    if (msg.Text.Contains(_adapter.CurrentUser.Name))
                    {
                        node.ForeColor = Color.Red;
                    }
                }
            }
        }
        #endregion

        #region Event
        private void _treeViewChannels_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            OnChannelChanged?.Invoke(e.Node.Tag);
        }
        private void _treeViewUsers_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            OnUserChanged?.Invoke(e.Node.Tag);
        }
        private void buttonSettings_Click(object sender, EventArgs e)
        {
            //SlackConnection ss = new SlackConnection();
            //ss.StartPosition = FormStartPosition.Manual;
            //ss.Top = this.ParentForm.Top + buttonSettings.Top + buttonSettings.Height + 30;
            //ss.Left = this.ParentForm.Left + buttonSettings.Left;
            //ss.LoadData(_slackAdapter);

            //ss.ShowDialog();
        }
        private void _slackMenu_OnUsersLoaded(object o)
        {
            UpdateTreeNodeUsers();
        }
        private void _slackMenu_OnInfoLoaded(object o)
        {
            this.Refresh();
            this.Invalidate();
        }
        private void _slackMenu_OnChannelsLoaded(object o)
        {
            UpdateTreeNodeChannels();
        }
        private void _slackAdapter_OnMessagesUpdated(object o)
        {
            ParseMessage((Message)o);
        }
        #endregion
    }
}
