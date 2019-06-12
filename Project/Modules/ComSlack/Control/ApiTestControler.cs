using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Droid.Communication.Api
{
    public static class TestControler
    {
        private const string URL = "https://slack.com/api/api.test";

        public static bool TestSuccess(SlackAdapter sa)
        {
            bool ret = false;

            try
            {
                string answer = Accessor.JsonGet(sa, URL);
                Response response = Accessor.Deserialize<Response>(answer);
                ret = response.Ok;
            }
            catch
            {

            }

            return ret;
        }
    }
}
