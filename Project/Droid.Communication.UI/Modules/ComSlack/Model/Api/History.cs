using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Droid.Communication
{
    public class History
    {
        private bool _ok;
        private List<Message> _messages;
        private bool _hasMore;

        public bool Has_More
        {
            get { return _hasMore; }
            set { _hasMore = value; }
        }
        public List<Message> Messages
        {
            get { return _messages; }
            set { _messages = value; }
        }
        public bool Ok
        {
            get { return _ok; }
            set { _ok = value; }
        }

        public History()
        {
            _messages = new List<Message>();
        }
    }
}
