using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Droid.Communication
{
    public class Hello : Event
    {
        public override string Type
        {
            get { return "hello"; }
        }
        public override string ToString()
        {
            return "hello";
        }
    }

}
