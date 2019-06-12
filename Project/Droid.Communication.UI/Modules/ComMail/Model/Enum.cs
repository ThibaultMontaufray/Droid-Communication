using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Droid.Communication
{
    public enum MailEncryption
    {
        NONE,
        SSL,
        TLS
    }
    public enum ServerSetting
    {
        IMAP,
        SMTP
    }
}
