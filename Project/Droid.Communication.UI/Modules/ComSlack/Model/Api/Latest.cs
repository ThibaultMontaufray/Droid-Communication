using Newtonsoft.Json;

namespace Droid.Communication
{
    public class Latest
    {
        private string _latest;

        public string Text
        {
            get { return _latest; }
            set { _latest = value; }
        }

        public Latest()
        {

        }
    }
}