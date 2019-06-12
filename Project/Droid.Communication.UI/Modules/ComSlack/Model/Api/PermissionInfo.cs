using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Droid.Communication
{
    public class PermissionInfo
    {
        private bool _ok;
        private Info _info;

        public Info Info
        {
            get { return _info; }
            set { _info = value; }
        }
        public bool Ok
        {
            get { return _ok; }
            set { _ok = value; }
        }

        public PermissionInfo()
        {

        }
    }
}
