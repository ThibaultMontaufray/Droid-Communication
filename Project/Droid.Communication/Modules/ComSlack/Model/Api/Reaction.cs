using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Droid.Communication
{
    public class Reaction
    {
        private string _name;
        private int _count;
        private List<string> _users;

        public List<string> Users
        {
            get { return _users; }
            set { _users = value; }
        }
        public int Count
        {
            get { return _count; }
            set { _count = value; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public Reaction()
        {
            _users = new List<string>();
        }
    }
}
