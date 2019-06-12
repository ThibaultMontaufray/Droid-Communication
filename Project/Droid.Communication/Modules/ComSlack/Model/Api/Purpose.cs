using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Droid.Communication
{
    public class Purpose
    {
        private string _value;
        private string _creator;
        private long _lastSet;

        public long Last_Set
        {
            get { return _lastSet; }
            set { _lastSet = value; }
        }
        public string Creator
        {
            get { return _creator; }
            set { _creator = value; }
        }
        public string Value
        {
            get { return _value; }
            set { _value = value; }
        }

        public Purpose()
        {

        }
    }
}
