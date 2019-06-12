using MailKit;

namespace Droid.Communication
{
    public class MessageInfo
    {
        #region Attributes
        public readonly IMessageSummary Summary;
        public MessageFlags Flags;
        #endregion

        #region Properties
        #endregion

        #region Constructor
        public MessageInfo(IMessageSummary summary)
        {
            Summary = summary;

            if (summary.Flags.HasValue)
                Flags = summary.Flags.Value;
        }
        #endregion
    }
}
