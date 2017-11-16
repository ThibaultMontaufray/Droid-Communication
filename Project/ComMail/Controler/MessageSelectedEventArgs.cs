using MailKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Droid_communication
{
    public class MessageSelectedEventArgs
    {
        public MessageSelectedEventArgs(IMailFolder folder, UniqueId uid, BodyPart body)
        {
            Folder = folder;
            UniqueId = uid;
            Body = body;
        }

        public IMailFolder Folder
        {
            get; private set;
        }

        public UniqueId UniqueId
        {
            get; private set;
        }

        public BodyPart Body
        {
            get; private set;
        }
    }
}
