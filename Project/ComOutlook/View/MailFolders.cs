using System.Windows.Forms;
using Droid_communication;
using Tools4Libraries.Resources;
using System.Drawing;
using Microsoft.Office.Interop.Outlook;

namespace Assistant.ComOutlook
{
    public delegate void MailFoldersEventHandler(object obj);
    public partial class MailFolders : UserControl
    {
        #region Attribute
        public event MailFoldersEventHandler FolderSelectionChanged;

        private OutlookInterface _outlookInterface;
        private ImageList _imageListTreeView;
        #endregion

        #region Properties
        public OutlookInterface OutLook
        {
            get { return _outlookInterface; }
            set { _outlookInterface = value; }
        }
        #endregion

        #region Constructor
        public MailFolders()
        {
            InitializeComponent();
            Init();
        }
        #endregion

        #region Methods public
        public void LoadMails()
        {
            if (_outlookInterface == null) return;
            Font boldRegular = new Font(_treeViewMail.Font, FontStyle.Regular);
            TreeNode inboxNode, rootNode, mailFoldersNode;

            _treeViewMail.Nodes.Clear();

            rootNode = new TreeNode(string.Format("Favorite mail", _outlookInterface.UnreadMailCount), _imageListTreeView.Images.IndexOfKey("favorite"), _imageListTreeView.Images.IndexOfKey("favorite"));
            rootNode.NodeFont = boldRegular;
            _treeViewMail.Nodes.Add(rootNode);
            mailFoldersNode = new TreeNode(string.Format("All mails items", _outlookInterface.UnreadMailCount), _imageListTreeView.Images.IndexOfKey("all"), _imageListTreeView.Images.IndexOfKey("all"));
            mailFoldersNode.NodeFont = boldRegular;
            _treeViewMail.Nodes.Add(mailFoldersNode);

            if (_outlookInterface.UnreadMailCount > 0)
            {
                inboxNode = new TreeNode(string.Format("Inbox ({0})", _outlookInterface.UnreadMailCount), _imageListTreeView.Images.IndexOfKey("inbox"), _imageListTreeView.Images.IndexOfKey("inbox"));
            }
            else
            {
                inboxNode = new TreeNode("Inbox", _imageListTreeView.Images.IndexOfKey("inbox"), _imageListTreeView.Images.IndexOfKey("inbox"));
                inboxNode.NodeFont = boldRegular;
                inboxNode.Name = "inbox";
            }
            rootNode.Nodes.Add(inboxNode);

            TreeNode sentNode = new TreeNode("Sent items", _imageListTreeView.Images.IndexOfKey("sentmail"), _imageListTreeView.Images.IndexOfKey("sentmail"));
            sentNode.NodeFont = boldRegular;
            sentNode.Name = "sent";
            rootNode.Nodes.Add(sentNode);


            var nameSpace = _outlookInterface.Outlook.GetNamespace("Mapi");
            foreach (Folder item in nameSpace.Folders)
            {
                inboxNode = new TreeNode(string.Format(item.Name, _outlookInterface.UnreadMailCount), _imageListTreeView.Images.IndexOfKey("folder"), _imageListTreeView.Images.IndexOfKey("folder"));
                inboxNode.NodeFont = boldRegular;
                inboxNode.Name = item.Name;
                mailFoldersNode.Nodes.Add(inboxNode);
            }
            _treeViewMail.ExpandAll();
        }
        #endregion

        #region Methods private
        private void Init()
        {
            _imageListTreeView = new ImageList();
            _imageListTreeView.TransparentColor = Color.Transparent;
            _imageListTreeView.Images.Add("inbox", ResourceIconSet16Default.mail_box);
            _imageListTreeView.Images.Add("sentmail", ResourceIconSet16Default.folder_page);
            _imageListTreeView.Images.Add("folder", ResourceIconSet16Default.folder);
            _imageListTreeView.Images.Add("all", ResourceIconSet16Default.folders);
            _imageListTreeView.Images.Add("favorite", ResourceIconSet16Default.star);

            _treeViewMail.ImageList = _imageListTreeView;
            _treeViewMail.AfterSelect += _treeViewMail_AfterSelect;
        }
        #endregion

        #region Event
        private void _treeViewMail_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (FolderSelectionChanged != null)
            {
                FolderSelectionChanged(_treeViewMail.SelectedNode.Name);
            }
        }
        #endregion
    }
}
