using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Droid.Communication
{
    public class Im : Channel
    {
        private string _id;
        private bool _isIm;
        private string _user;
        private double _created;
        private bool _isUserDeleted;
        private bool _isOrgShared;

        public bool Is_Org_Shared
        {
            get { return _isOrgShared; }
            set { _isOrgShared = value; }
        }
        public bool Is_User_Deleted
        {
            get { return _isUserDeleted; }
            set { _isUserDeleted = value; }
        }
        public double Created
        {
            get { return _created; }
            set { _created = value; }
        }
        public string User
        {
            get { return _user; }
            set { _user = value; }
        }
        public bool Is_Im
        {
            get { return _isIm; }
            set { _isIm = value; }
        }
        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public Im()
        {

        }
    }
}
