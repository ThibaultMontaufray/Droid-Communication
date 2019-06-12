using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Droid.Communication
{
    public class Info
    {
        private Team _team;
        private Channel _channel;
        private Group _group;
        private Mpim _mpim;
        private Im _im;
        private AppHome _appHome;

        public AppHome App_Home
        {
            get { return _appHome; }
            set { _appHome = value; }
        }
        public Im Im
        {
            get { return _im; }
            set { _im = value; }
        }
        public Mpim Mp_im
        {
            get { return _mpim; }
            set { _mpim = value; }
        }
        public Group Group
        {
            get { return _group; }
            set { _group = value; }
        }
        public Channel Channel
        {
            get { return _channel; }
            set { _channel = value; }
        }
        public Team Team
        {
            get { return _team; }
            set { _team = value; }
        }

        public Info()
        {

        }
    }
}
