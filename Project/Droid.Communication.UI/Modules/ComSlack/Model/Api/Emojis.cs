using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Droid.Communication
{
    public class Emojis : Response
    {
        private Emoji _emoji;
        private int _cacheTimeStamp;

        public int Cache_Ts
        {
            get { return _cacheTimeStamp; }
            set { _cacheTimeStamp = value; }
        }
        public Emoji Emoji
        {
            get { return _emoji; }
            set { _emoji = value; }
        }

        public Emojis()
        {

        }
    }
}
