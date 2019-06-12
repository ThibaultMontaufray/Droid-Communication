using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Droid.Communication
{
    public class ConversationControler
    {
        private const string URL = "https://slack.com/api/conversations";

        public static SlackConversation History(SlackAdapter sa, string channel)
        {
            SlackConversation conversation = null;

            try
            {
                Dictionary<string, string> data = new Dictionary<string, string>();
                data.Add("channel", channel);
                string answer = Accessor.JsonPostFormData(sa, URL + ".history", data);
                Response response = Accessor.Deserialize<Response>(answer);
                if (response.Ok)
                {
                    conversation = Accessor.Deserialize<SlackConversation>(answer);
                }
            }
            catch (Exception exp)
            {
            }

            return conversation;
        }
    }
}
