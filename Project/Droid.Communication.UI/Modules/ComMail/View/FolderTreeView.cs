using MailKit;
using MailKit.Net.Imap;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Droid.Communication
{
    delegate void UpdateFolderNodeDelegate(IMailFolder folder);

    [ToolboxItem(true)]
    public class FolderTreeView : TreeView
    {
        #region Attributes
        readonly Dictionary<IMailFolder, TreeNode> map = new Dictionary<IMailFolder, TreeNode>();

        public event EventHandler<FolderSelectedEventArgs> FolderSelected;
        private EmailAdapter _intEmail;
        #endregion

        #region Properties
        public EmailAdapter InterfaceEmail
        {
            get { return _intEmail; }
            set { _intEmail = value; }
        }
        #endregion

        #region Constructor
        public FolderTreeView()
        {
        }
        public FolderTreeView(EmailAdapter intEmail)
        {
            _intEmail = intEmail;
        }
        #endregion

        #region Methods public
        public void LoadFolders()
        {
            if (!_intEmail.Client.IsConnected) { _intEmail.Reconnect(); }
            if (_intEmail.Client.PersonalNamespaces.Count > 0)
            { 
                var personal = _intEmail.Client.GetFolder(_intEmail.Client.PersonalNamespaces[0]);
                PathSeparator = personal.DirectorySeparator.ToString();
                LoadChildFolders(personal);
            }
        }
        #endregion

        #region Methods protected
        protected override void OnBeforeExpand(TreeViewCancelEventArgs e)
        {
            if (e.Node.Nodes.Count == 1 && e.Node.Nodes[0].Tag == null)
            {
                // this folder has never been expanded before...
                var folder = (IMailFolder)e.Node.Tag;

                LoadChildFolders(folder);
            }

            base.OnBeforeExpand(e);
        }
        protected override void OnBeforeSelect(TreeViewCancelEventArgs e)
        {
            var folder = (IMailFolder)e.Node.Tag;

            // don't allow the user to select a folder with the \NoSelect or \NonExistent attribute
            if (folder == null || folder.Attributes.HasFlag(FolderAttributes.NoSelect) ||
                folder.Attributes.HasFlag(FolderAttributes.NonExistent))
            {
                e.Cancel = true;
                return;
            }

            base.OnBeforeSelect(e);
        }
        protected override void OnAfterSelect(TreeViewEventArgs e)
        {
            var handler = FolderSelected;

            if (handler != null)
                handler(this, new FolderSelectedEventArgs((IMailFolder)e.Node.Tag));

            base.OnAfterSelect(e);
        }
        #endregion

        #region Methods private
        private bool CheckFolderForChildren(IMailFolder folder)
        {
            if (_intEmail.Client.Capabilities.HasFlag(ImapCapabilities.Children))
            {
                if (folder.Attributes.HasFlag(FolderAttributes.HasChildren))
                    return true;
            }
            else if (!folder.Attributes.HasFlag(FolderAttributes.NoInferiors))
            {
                return true;
            }

            return false;
        }
        private void UpdateFolderNode(IMailFolder folder)
        {
            var node = map[folder];

            if (folder.Unread > 0)
            {
                node.Text = string.Format("{0} ({1})", folder.Name, folder.Unread);
                node.NodeFont = new Font(node.NodeFont, FontStyle.Bold);
            }
            else
            {
                node.NodeFont = new Font(node.NodeFont, FontStyle.Regular);
                node.Text = folder.Name;
            }

            if (folder.Attributes.HasFlag(FolderAttributes.Trash))
                node.SelectedImageKey = node.ImageKey = folder.Count > 0 ? "trash-full" : "trash-empty";
        }
        private TreeNode CreateFolderNode(IMailFolder folder)
        {
            var node = new TreeNode(folder.Name) { Tag = folder, ToolTipText = folder.FullName };

            node.NodeFont = new Font(Font, FontStyle.Regular);

            if (folder == _intEmail.Client.Inbox)
                node.SelectedImageKey = node.ImageKey = "inbox";
            else if (folder.Attributes.HasFlag(FolderAttributes.Archive))
                node.SelectedImageKey = node.ImageKey = "archive";
            else if (folder.Attributes.HasFlag(FolderAttributes.Drafts))
                node.SelectedImageKey = node.ImageKey = "drafts";
            else if (folder.Attributes.HasFlag(FolderAttributes.Flagged))
                node.SelectedImageKey = node.ImageKey = "important";
            else if (folder.Attributes.HasFlag(FolderAttributes.Junk))
                node.SelectedImageKey = node.ImageKey = "junk";
            else if (folder.Attributes.HasFlag(FolderAttributes.Sent))
                node.SelectedImageKey = node.ImageKey = "sent";
            else if (folder.Attributes.HasFlag(FolderAttributes.Trash))
                node.SelectedImageKey = node.ImageKey = folder.Count > 0 ? "trash-full" : "trash-empty";
            else
                node.SelectedImageKey = node.ImageKey = "folder";

            if (CheckFolderForChildren(folder))
                node.Nodes.Add("Loading...");

            return node;
        }
        private void LoadChildFolders(IMailFolder folder, IEnumerable<IMailFolder> children)
        {
            TreeNodeCollection nodes;
            TreeNode node;

            if (map.TryGetValue(folder, out node))
            {
                nodes = node.Nodes;
                nodes.Clear();
            }
            else
            {
                nodes = Nodes;
            }

            foreach (var child in children)
            {
                node = CreateFolderNode(child);
                map[child] = node;
                nodes.Add(node);

                // Note: because we are using the *Async() methods, these events will fire
                // in another thread so we'll have to proxy them back to the main thread.
                child.MessageFlagsChanged += UpdateUnreadCount_TaskThread;
                child.CountChanged += UpdateUnreadCount_TaskThread;

                if (!child.Attributes.HasFlag(FolderAttributes.NonExistent) && !child.Attributes.HasFlag(FolderAttributes.NoSelect))
                {
                    child.StatusAsync(StatusItems.Unread).ContinueWith(task => {
                        Invoke(new UpdateFolderNodeDelegate(UpdateFolderNode), child);
                    });
                }
            }
        }
        private async void LoadChildFolders(IMailFolder folder)
        {
            var children = await folder.GetSubfoldersAsync();

            LoadChildFolders(folder, children);
        }
        private async void UpdateUnreadCount(object sender, EventArgs e)
        {
            var folder = (IMailFolder)sender;

            await folder.StatusAsync(StatusItems.Unread);
            UpdateFolderNode(folder);
        }
        private void UpdateUnreadCount_TaskThread(object sender, EventArgs e)
        {
            // proxy to the main thread
            Invoke(new EventHandler<EventArgs>(UpdateUnreadCount), sender, e);
        }
        #endregion

        #region Event
        #endregion
    }
}
