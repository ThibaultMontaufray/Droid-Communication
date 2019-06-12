using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Droid.Communication
{
    public class Member
    {
        private string _id;
        private string _teamId;
        private string _name;
        private bool _deleted;
        private string _color;
        private string _realName;
        private string _tz;
        private string _tzName;
        private int _tzOffset;
        private bool _isAdmin;
        private bool _isOwner;
        private bool _isPrimaryOwner;
        private bool _isRestricted;
        private bool _isUltraRestricted;
        private bool _isBot;
        private string _updated;
        private bool _isAppUser;
        private bool _has2fa;
        private Profile _profile;

        public Profile Profile
        {
            get { return _profile; }
            set { _profile = value; }
        }
        public bool Has_2_fa
        {
            get { return _has2fa; }
            set { _has2fa = value; }
        }
        public bool Is_App_User
        {
            get { return _isAppUser; }
            set { _isAppUser = value; }
        }
        public string Updated
        {
            get { return _updated; }
            set { _updated = value; }
        }
        public bool Is_Bot
        {
            get { return _isBot; }
            set { _isBot = value; }
        }
        public bool Is_Ultra_Restricted
        {
            get { return _isUltraRestricted; }
            set { _isUltraRestricted = value; }
        }
        public bool Is_Restricted
        {
            get { return _isRestricted; }
            set { _isRestricted = value; }
        }
        public bool Is_Primary_Owner
        {
            get { return _isPrimaryOwner; }
            set { _isPrimaryOwner = value; }
        }
        public bool Is_Owner
        {
            get { return _isOwner; }
            set { _isOwner = value; }
        }
        public bool Is_Admin
        {
            get { return _isAdmin; }
            set { _isAdmin = value; }
        }
        public int Ts_Offset
        {
            get { return _tzOffset; }
            set { _tzOffset = value; }
        }
        public string Ts_Name
        {
            get { return _tzName; }
            set { _tzName = value; }
        }
        public string Ts
        {
            get { return _tz; }
            set { _tz = value; }
        }
        public string Real_Name
        {
            get { return _realName; }
            set { _realName = value; }
        }
        public string Color
        {
            get { return _color; }
            set { _color = value; }
        }
        public bool Deleted
        {
            get { return _deleted; }
            set { _deleted = value; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string Team_Id
        {
            get { return _teamId; }
            set { _teamId = value; }
        }
        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public Member()
        {

        }
    }
}
