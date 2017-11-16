using MailKit;

namespace Droid_communication
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
