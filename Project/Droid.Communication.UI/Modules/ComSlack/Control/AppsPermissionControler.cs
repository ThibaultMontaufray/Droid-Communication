using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Droid.Communication.Apps
{
    public class PermissionControler
    {
        private const string URL = "https://slack.com/api/apps.permissions.info";

        public static PermissionInfo GetInfo(SlackAdapter sa)
        {
            PermissionInfo pi = null;

            try
            {
                string answer = Accessor.JsonGet(sa, URL);
                Response response = Accessor.Deserialize<Response>(answer);
                if (response.Ok)
                { 
                    pi = Accessor.Deserialize<PermissionInfo>(answer);
                }
            }
            catch
            {
            }

            return pi;
        }
    }
}
