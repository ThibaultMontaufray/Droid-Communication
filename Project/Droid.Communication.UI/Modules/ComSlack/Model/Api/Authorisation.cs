using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Droid.Communication
{
    public class Authorisation
    {
        private bool _ok;
        private string _url;
        private string _team;
        private string _user;
        private string _teamId;
        private string _userId;

        public string User_Id
        {
            get { return _userId; }
            set { _userId = value; }
        }
        public string Team_Id
        {
            get { return _teamId; }
            set { _teamId = value; }
        }
        public string User
        {
            get { return _user; }
            set { _user = value; }
        }
        public string Team
        {
            get { return _team; }
            set { _team = value; }
        }
        public string Url
        {
            get { return _url; }
            set { _url = value; }
        }
        public bool Ok
        {
            get { return _ok; }
            set { _ok = value; }
        }

        public Authorisation()
        {

        }
    }
}
