using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Droid.Communication
{
    public class Permission
    {
        protected List<string> _scopes;
        protected Resources _resources;

        public Resources Resources
        {
            get { return _resources; }
            set { _resources = value; }
        }
        public List<string> Scopes
        {
            get { return _scopes; }
            set { _scopes = value; }
        }

        public Permission()
        {
            _scopes = new List<string>();
        }
    }
}
