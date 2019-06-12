using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Droid.Communication
{
    public class Group : Channel
    {
        private string _id;
        private string _name;
        private string _isGroup;
        private long _created;
        private string _creator;
        private bool _isArchived;
        private List<string> _members;
        private Topic _topic;
        private Purpose _purpose;
        private int _lastRead;
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
        public int Last_Read
        {
            get { return _lastRead; }
            set { _lastRead = value; }
        }
        public Purpose Purpose
        {
            get { return _purpose; }
            set { _purpose = value; }
        }
        public Topic Topic
        {
            get { return _topic; }
            set { _topic = value; }
        }
        public List<string> Members
        {
            get { return _members; }
            set { _members = value; }
        }
        public bool Is_Archived
        {
            get { return _isArchived; }
            set { _isArchived = value; }
        }
        public string Creator
        {
            get { return _creator; }
            set { _creator = value; }
        }
        public long Created
        {
            get { return _created; }
            set { _created = value; }
        }
        public string Is_Group
        {
            get { return _isGroup; }
            set { _isGroup = value; }
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

        public Group()
        {
            _members = new List<string>();
        }
    }
}
