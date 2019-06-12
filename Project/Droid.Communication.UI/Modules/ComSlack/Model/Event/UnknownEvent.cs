using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Droid.Communication
{
    public class UnknownEvent : Event
    {
        #region Attributes
        public Newtonsoft.Json.Linq.JObject data;
        #endregion

        #region Constructor
        internal UnknownEvent(JObject data)
        {
            this.data = data;
        }
        #endregion

        #region Methods public
        public override string Type
        {
            get { return data["type"].ToString(); }
        }
        public override string ToString()
        {
            return data.ToString();
        }
        #endregion
    }
}
