using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Droid.Communication
{
    public class TeamInfo : Response
    {
        private Team _team;

        public Team Team
        {
            get { return _team; }
            set { _team = value; }
        }
    }
}
