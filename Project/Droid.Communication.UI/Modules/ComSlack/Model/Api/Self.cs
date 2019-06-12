using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Droid.Communication
{
    public class Self
    {
        private string _id;
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public Self()
        {

        }
    }
}
