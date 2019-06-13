using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Droid.Communication
{
    public abstract class Event
    {
        #region Attributes
        public abstract string Type { get; }
        #endregion

        #region Methods public
        public static Event NewEvent(string Json)
        {
            return JsonConvert.DeserializeObject<Event>(Json, new SlackJsonConverter());
        }
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, new SlackJsonConverter());
        }
        #endregion
    }
}
