using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Droid.Communication
{
    public class ChannelList : Response
    {
        private List<Channel> _channels;
        private ResponseMetadata _responseMetadata;

        public ResponseMetadata Response_Metadata
        {
            get { return _responseMetadata; }
            set { _responseMetadata = value; }
        }
        public List<Channel> Channels
        {
            get { return _channels; }
            set { _channels = value; }
        }
     
        public ChannelList()
        {
            _channels = new List<Channel>();
        }
    }
}
