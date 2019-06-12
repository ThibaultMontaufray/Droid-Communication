using MailKit;

namespace Droid.Communication
{
    public class FolderSelectedEventArgs
    {
        public FolderSelectedEventArgs(IMailFolder folder)
        {
            Folder = folder;
        }

        public IMailFolder Folder
        {
            get; private set;
        }
    }

}
