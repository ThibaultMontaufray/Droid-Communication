using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Droid.Communication
{
    public class GroupControler
    {
        private const string URL = "https://slack.com/api/groups";

        public static List<Group> List(SlackAdapter sa)
        {
            List<Group> groups = new List<Group>();

            try
            {
                string answer = Accessor.JsonPostFormData(sa, URL + ".list");
                Response response = Accessor.Deserialize<Response>(answer);
                if (response.Ok)
                {
                    groups = Accessor.Deserialize<List<Group>>(answer);
                }
            }
            catch
            {
            }

            return groups;
        }
    }
}
