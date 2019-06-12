using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Droid.Communication
{
    public class TeamControler
    {
        private const string URL = "https://slack.com/api/team";

        public static Team Info(SlackAdapter sa)
        {
            Team team = null;

            try
            {
                string answer = Accessor.JsonPostFormData(sa, URL + ".info");
                Response response = Accessor.Deserialize<Response>(answer);
                if (response.Ok)
                {
                    TeamInfo teamInfo = Accessor.Deserialize<TeamInfo>(answer);
                    team = teamInfo.Team!= null ? teamInfo.Team : null;
                }
            }
            catch
            {
            }

            return team;
        }
    }
}
