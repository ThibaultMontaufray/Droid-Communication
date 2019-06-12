using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Droid.Communication
{
    public class Mpim : Permission
    {
        private string _id;
        private string _name;
        private bool _isMpim;
        private bool _isGroup;
        private int _created;
        private string _creator;
        private List<string> _members;
        private string _lastRead;
        private Latest _latest;
        private int _unreadCount;
        private int _unreadCountDisplay;

        public int Unread_Count_Display
        {
            get { return _unreadCountDisplay; }
            set { _unreadCountDisplay = value; }
        }
        public int Unread_Count
        {
            get { return _unreadCount; }
            set { _unreadCount = value; }
        }
        public Latest Latest
        {
            get { return _latest; }
            set { _latest = value; }
        }
        public string Last_Read
        {
            get { return _lastRead; }
            set { _lastRead = value; }
        }
        public List<string> Members
        {
            get { return _members; }
            set { _members = value; }
        }
        public string Creator
        {
            get { return _creator; }
            set { _creator = value; }
        }
        public int Created
        {
            get { return _created; }
            set { _created = value; }
        }
        public bool Is_Group
        {
            get { return _isGroup; }
            set { _isGroup = value; }
        }
        public bool Is_Mpim
        {
            get { return _isMpim; }
            set { _isMpim = value; }
        }
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

    }
}
