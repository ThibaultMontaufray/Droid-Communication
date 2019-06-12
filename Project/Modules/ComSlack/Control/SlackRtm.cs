using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Websockets;

namespace Droid.Communication
{
    public class SlackRtm
    {
        #region Delegate / event
        public delegate void OnEventEvent(object sender, SlackEventArgs e);
        public event OnEventEvent OnAck;
        public event OnEventEvent OnEvent;
        #endregion

        #region Attributes
        private SlackAdapter _adapter;
        private int sendId = 0;
        private string Url;
        private List<Event> SentMessages = new List<Event>();
        private WebClient wc = new WebClient();
        private IWebSocketConnection webSocket;
        private SlackJsonConverter JsonConverter;
        #endregion

        #region Properties
        public SlackAdapter Adapter
        {
            get { return _adapter; }
            set { _adapter = value; }
        }
        public IEnumerable<Channel> JoinedChannels
        {
            get
            {
                return Channels.Where(n => n.Is_Member);
            }
        }
        public List<Channel> Channels { get; private set; }
        public bool Connected { get { return webSocket.IsOpen; } }
        public bool Connecting { get { return !RecievedHello && webSocket != null; } }
        public List<Im> Ims { get; private set; }
        public Channel PrimaryChannel { get; private set; }
        public bool RecievedHello { get; private set; }
        public Member Self { get; private set; }
        public TeamInfo TeamInfo { get; private set; }
        public List<Member> Users { get; private set; }
        #endregion

        #region Constructor
        public SlackRtm()
        {
            OnAck += Slack_OnAck;
            JsonConverter = new SlackJsonConverter(this);
            Websockets.Net.WebsocketConnection.Link();
        }
        public SlackRtm(SlackAdapter adapter)
        {
            _adapter = adapter;
            OnAck += Slack_OnAck;
            JsonConverter = new SlackJsonConverter(this);
            Websockets.Net.WebsocketConnection.Link();
        }
        #endregion

        #region Methods public 
        public bool Connect()
        {
            if (String.IsNullOrEmpty(_adapter.Token?.Key))
            {
                if (!string.IsNullOrEmpty(_adapter.Token.Key))
                    Init();
                else
                    throw new InvalidOperationException("No OAuth Token was provided");
            }
            if (webSocket != null)
            {
                webSocket.Close();
                webSocket.OnMessage -= webSocket_OnMessage; // Shouldn't be needed.
            }
            webSocket = WebSocketFactory.Create();
            webSocket.OnMessage += webSocket_OnMessage;
            webSocket.Open(Url);
            Url = null;
            return true;
        }
        public Channel GetChannel(string p)
        {
            if (string.IsNullOrEmpty(p) || p == "#" || p == "@")
                return null;
            if (p[0] == '@')
                return Ims.FirstOrDefault(c => c.Id == p || c.Name == p);
            if (p[0] == '#')
                p = p.Substring(1);
            return Channels.FirstOrDefault(c => c.Id == p || c.Name == p);
        }
        public Member GetUser(string p)
        {
            if (string.IsNullOrEmpty(p) || p == "@")
                return null;
            if (p[0] == '@')
                p = p.Substring(1);
            return Users.FirstOrDefault(c => c.Id == p || c.Name == p);
        }
        
        public bool Init()
        {
            JObject response = Api("rtm.start");
            if (response["ok"].Value<bool>() == false)
            {
                Console.WriteLine(response["error"]);
                return false;
            }
            TeamInfo = JsonConvert.DeserializeObject<TeamInfo>(response["team"].ToString(), JsonConverter);
            Channels = JsonConvert.DeserializeObject<List<Channel>>(response["channels"].ToString(), JsonConverter);
            Channels.AddRange(JsonConvert.DeserializeObject<List<Channel>>(response["groups"].ToString(), JsonConverter)); // Groups are glorified channels?
            Ims = JsonConvert.DeserializeObject<List<Im>>(response["ims"].ToString(), JsonConverter);  // They're also channels, but with 'User's instead of 'Name's.

            Users = JsonConvert.DeserializeObject<List<Member>>(response["users"].ToString(), JsonConverter);
            Self = Users.First(n => n.Id == response["self"]["id"].ToString());
            Url = response["url"].ToString();
            PrimaryChannel = Channels.FirstOrDefault(n => n.Is_General);
            //TODO: Bots.
            return true;
        }
        public void SendMessage(string channel, string text, params object[] args)
        {
            Message message;
            text = String.Format(text, args);
            var chan = GetChannel(channel);
            if (chan == null && Connect())
            {
                message = new Message(channel, text, sendId++); // The user might know what they're doing more than we do, so attempt it with the ID they provided.  Initally a fix for broken IM support.
                SentMessages.Add(message);
                webSocket.Send(message.ToJson());
            }
            else
            {
                SendMessage(chan, text, args);
            }
        }
        public bool SendMessage(Channel chan, string text, params object[] args)
        {
            if (Connect())
            {
                text = String.Format(text, new object());
                //if (!chan.IsMember)
                //    throw new NotInChannelException();
                var message = new Message(chan.Id, text, sendId++);
                SentMessages.Add(message);
                webSocket.Send(message.ToJson());
                return true;
            }
            return false;
        }
        /// <summary>
        /// Raw API call.  You hopefully don't need to call this.
        /// </summary>
        /// <param name="method"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        /// <remarks>Calling APIs directly might result in a confused state.  You may need to call <see cref="Slack.Init"/> to resynchronize the state. </remarks>
        public JObject Api(string method, params JProperty[] args)
        {
            var uri = new UriBuilder("https://slack.com/api/" + method);

            var query = "token=" + _adapter.Token.Key;
            foreach (var arg in args)
            {
                query += string.Format("&{0}={1}", arg.Name, arg.Value);
            }
            uri.Query = query;
            return JObject.Parse(wc.DownloadString(uri.Uri));
        }
        #endregion

        #region Methods private
        private void Slack_OnAck(object sender, SlackEventArgs e)
        {
            var ack = (e.Data as Ack);
        }
        private void webSocket_OnMessage(string text)
        {
            var data = Event.NewEvent(text);
            if (data.Type == "hello")
                RecievedHello = true;
            if (data is Ack)
                OnAck?.Invoke(this, new SlackEventArgs(data));
            else
                OnEvent?.Invoke(this, new SlackEventArgs(data));
        }
        private void CleanOldMessages()
        {
            while (SentMessages.Count > 1000)
            { 
                SentMessages.RemoveAt(0);
            }
        }
        #endregion
    }
}
