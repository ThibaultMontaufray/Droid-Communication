using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Droid.Communication
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Channel : Permission
    {
        #region Attributes
        private string _id;
        private string _name;
        private bool _isChannel;
        private bool _isGroup;
        private int _created;
        private bool _isArchived;
        private bool _isGeneral;
        private int _unlinked;
        private string _creator;
        private string _nameNormalized;
        private bool _isShared;
        private bool _isExtShared;
        private List<string> _pendingShared;
        private bool _isPendingShared;
        private bool _isOrgShared;
        private bool _isMember;
        private bool _isPrivate;
        private bool _isMpim;
        private bool _isIm;
        private List<string> _members;
        private Topic _topic;
        private Purpose _purpose;
        private List<string> _previousNames;
        private int _numMembers;
        #endregion

        #region Properties
        public bool Is_Pending_Shared
        {
            get { return _isPendingShared; }
            set { _isPendingShared = value; }
        }
        public List<string> Pending_Shared
        {
            get { return _pendingShared; }
            set { _pendingShared = value; }
        }
        public bool Is_Ext_Shared
        {
            get { return _isExtShared; }
            set { _isExtShared = value; }
        }
        public bool Is_Im
        {
            get { return _isIm; }
            set { _isIm = value; }
        }
        public bool Is_Group
        {
            get { return _isGroup; }
            set { _isGroup = value; }
        }
        public int Number_Members
        {
            get { return _numMembers; }
            set { _numMembers = value; }
        }
        public List<string> Previous_Names
        {
            get { return _previousNames; }
            set { _previousNames = value; }
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
        public bool Is_Mpim
        {
            get { return _isMpim; }
            set { _isMpim = value; }
        }
        public bool Is_Private
        {
            get { return _isPrivate; }
            set { _isPrivate = value; }
        }
        public bool Is_Member
        {
            get { return _isMember; }
            set { _isMember = value; }
        }
        public bool Is_Org_Shared
        {
            get { return _isOrgShared; }
            set { _isOrgShared = value; }
        }
        public bool Is_Shared
        {
            get { return _isShared; }
            set { _isShared = value; }
        }
        public string Name_Normalized
        {
            get { return _nameNormalized; }
            set { _nameNormalized = value; }
        }
        public string Creator
        {
            get { return _creator; }
            set { _creator = value; }
        }
        public int Unlinked
        {
            get { return _unlinked; }
            set { _unlinked = value; }
        }
        public bool Is_General
        {
            get { return _isGeneral; }
            set { _isGeneral = value; }
        }
        public bool Is_Archived
        {
            get { return _isArchived; }
            set { _isArchived = value; }
        }
        public int Created
        {
            get { return _created; }
            set { _created = value; }
        }
        public bool Is_Channel
        {
            get { return _isChannel; }
            set { _isChannel = value; }
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
        #endregion

        #region Constructor
        public Channel()
        {
            _previousNames = new List<string>();
            _members = new List<string>();
            _scopes = new List<string>();
        }
        #endregion
    }
}
