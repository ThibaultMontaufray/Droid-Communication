using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Droid.Communication
{
    public class Users : Response
    {
        private bool _status;
        private List<Member> _member;
        private int _cacheTs;

        public int Cache_Ts
        {
            get { return _cacheTs; }
            set { _cacheTs = value; }
        }
        public List<Member> Members
        {
            get { return _member; }
            set { _member = value; }
        }
        public bool Status
        {
            get { return _status; }
            set { _status = value; }
        }

        public Users()
        {
            _member = new List<Member>();
        }
    }
}
