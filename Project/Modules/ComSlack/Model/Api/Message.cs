using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Droid.Communication
{
    public class Message : Event
    {
        #region Attributes
        private string _type;
        private string _ts;
        private string _user;
        private string _text;
        private bool _isStarred;
        private List<Reaction> _reactions;
        private List<SlackAttachment> _attachments;
        private string _userName;
        private string _botId;
        private string _subType;
        private bool _hidden;
        private string _channel;
        private int _id;
        #endregion

        #region Properties
        public List<SlackAttachment> Attachements
        {
            get { return _attachments; }
            set { _attachments = value; }
        }
        public string SubType
        {
            get { return _subType; }
            set { _subType = value; }
        }
        public string Bot_Id
        {
            get { return _botId; }
            set { _botId = value; }
        }
        public string User_Name
        {
            get { return _userName; }
            set { _userName = value; }
        }
        public List<Reaction> Reactions
        {
            get { return _reactions; }
            set { _reactions = value; }
        }
        public bool IsStarred
        {
            get { return _isStarred; }
            set { _isStarred = value; }
        }
        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }
        public string User
        {
            get { return _user; }
            set { _user = value; }
        }
        public string Ts
        {
            get { return _ts; }
            set { _ts = value; }
        }
        public override string Type
        {
            get { return "message"; }
        }
        public bool Hidden
        {
            get { return _hidden; }
            set { _hidden = value; }
        }
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string Channel
        {
            get { return _channel; }
            set { _channel = value; }
        }
        #endregion

        #region Constructor
        public Message()
        {

        }
        internal Message(Newtonsoft.Json.Linq.JObject data)
        {
            this.Channel = data.Value<string>("channel");
            this.User = data.Value<string>("user");
            this.Text = data.Value<string>("text");
            this.Ts = data.Value<string>("ts");
            this.SubType = data.Value<string>("subtype");
            this.Hidden = data.Value<bool>("hidden");
            this.Id = -1;
        }
        internal Message(string channel, string text, int id)
        {
            // TODO: Complete member initialization
            this.Channel = channel;
            this.Text = text;
            this.Id = id;
        }
        #endregion

        #region Methods public
        public override string ToString()
        {
            return string.Format("<#{0}> <@{1}>: {2}", Channel, User, Text);
        }
        #endregion
    }
}
