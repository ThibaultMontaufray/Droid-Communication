using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Droid.Communication
{
    public class Response
    {
        private bool _ok;
        private string _error;


        public string Error
        {
            get { return _error; }
            set { _error = value; }
        }
        public bool Ok
        {
            get { return _ok; }
            set { _ok = value; }
        }

        public Response()
        {

        }
    }
}
