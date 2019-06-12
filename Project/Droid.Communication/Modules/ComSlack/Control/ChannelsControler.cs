using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Droid.Communication
{
    public class ChannelsControler
    {
        private const string URL = "https://slack.com/api/channels";

        public static List<Channel> List(SlackAdapter sa)
        {
            ChannelList channels = null;

            try
            {
                string answer = Accessor.JsonPostFormData(sa, URL + ".list");
                Response response = Accessor.Deserialize<Response>(answer);
                if (response.Ok)
                {
                    channels = Accessor.Deserialize<ChannelList>(answer);
                }
            }
            catch
            {
            }

            return channels == null ? null : channels.Channels;
        }
    }
}
