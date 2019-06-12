using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Droid.Communication
{
    public class Resources
    {
        private List<string> _ids;
        private bool _wildCard;
        private List<string> _excludeIds;

        public List<string> Exclude_Ids
        {
            get { return _excludeIds; }
            set { _excludeIds = value; }
        }
        public bool WildCard
        {
            get { return _wildCard; }
            set { _wildCard = value; }
        }
        public List<string> Ids
        {
            get { return _ids; }
            set { _ids = value; }
        }

        public Resources()
        {
            _ids = new List<string>();
            _excludeIds = new List<string>();
        }
    }
}
