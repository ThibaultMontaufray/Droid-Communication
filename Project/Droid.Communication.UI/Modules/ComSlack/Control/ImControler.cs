using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Droid.Communication
{
    public class ImControler
    {
        private const string URL = "https://slack.com/api/im";

        public static List<Im> List(SlackAdapter sa)
        {
            List<Im> ims = null;

            try
            {
                string answer = Accessor.JsonPostFormData(sa, URL + ".list");
                Response response = Accessor.Deserialize<Response>(answer);
                if (response.Ok)
                {
                    ims = Accessor.Deserialize<List<Im>>(answer);
                }
            }
            catch
            {
            }

            return ims;
        }
    }
}
