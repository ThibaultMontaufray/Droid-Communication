using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Droid.Communication
{
    public class SlackConversation
    {
        private bool _ok;
        private List<Message> _messages;
        private bool _hasMore;
        private int _pinCount;
        private ResponseMetadata _responseMetaData;

        public ResponseMetadata Response_MetaData
        {
            get { return _responseMetaData; }
            set { _responseMetaData = value; }
        }
        public int Pin_Count
        {
            get { return _pinCount; }
            set { _pinCount = value; }
        }
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

        public SlackConversation()
        {
            _messages = new List<Message>();
        }
    }
}
