using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Droid.Communication
{
    public class Ack : Event
    {
        #region Attributes
        [JsonProperty("ts")]
        public string Timestamp { get; set; }
        public bool Ok { get; set; }
        public int ReplyTo { get; set; }
        public string Text { get; set; }
        public dynamic Error { get; set; }
        #endregion

        #region Methods public
        public override string Type
        {
            get { return "Ack"; }
        }
        public override string ToString()
        {
            return ToJson();
        }
        #endregion
    }
}
