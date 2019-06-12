using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Droid.Communication
{
    public class GroupInfo
    {
        private bool _ok;
        private Group _group;

        public Group Group
        {
            get { return _group; }
            set { _group = value; }
        }
        public bool Ok
        {
            get { return _ok; }
            set { _ok = value; }
        }

        public GroupInfo()
        {

        }
    }
}
