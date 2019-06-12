using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Droid.Communication
{
    public class EmojiControler
    {
        private const string URL = "https://slack.com/api/emoji";

        public static Emoji List(SlackAdapter sa)
        {
            Emojis emojis = null;

            try
            {
                string answer = Accessor.JsonPostFormData(sa, URL + ".list");
                Response response = Accessor.Deserialize<Response>(answer);
                if (response.Ok)
                {
                    emojis = Accessor.Deserialize<Emojis>(answer);
                }
            }
            catch
            {
            }

            return emojis == null ? null : emojis.Emoji;
        }
    }
}
