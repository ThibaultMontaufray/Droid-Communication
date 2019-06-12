using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Droid.Communication
{
    public class CommentDetail
    {
        private string _id;
        private int _timeStamp;
        private string _user;
        private string _comment;

        public string Comment
        {
            get { return _comment; }
            set { _comment = value; }
        }
        public string User
        {
            get { return _user; }
            set { _user = value; }
        }
        public int TimeStamp
        {
            get { return _timeStamp; }
            set { _timeStamp = value; }
        }
        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public CommentDetail()
        {

        }
    }
}
