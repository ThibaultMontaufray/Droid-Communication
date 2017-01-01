using Newtonsoft.Json;
using System;
using System.Collections.Specialized;
using System.Net;
using System.Text;

namespace Droid_communication
{
    public class SlackInterface
    {
        private Uri _uri;
        private Encoding _encoding = new UTF8Encoding();
        private string _proxyHost = "";
        private string _proxyLogin = "";
        private string _proxyPassword = "";
        private int _proxyPort = 8080;

        public SlackInterface(string urlWithAccessToken)
        {
            _uri = new Uri(urlWithAccessToken);
        }

        /// <summary>
        /// Post a message using simple strings
        /// </summary>
        /// <param name="text">text to send</param>
        /// <param name="username">your credentials</param>
        /// <param name="channel">the channel to post on</param>
        public void PostMessage(string text, string username = null, string channel = null)
        {
            _proxyHost = Tools4Libraries.Params.WebProxyHost;
            Payload payload = new Payload()
            {
                Channel = channel,
                Username = username,
                Text = text
            };

            PostMessage(payload);
        }

        /// <summary>
        /// Post a message using a Payload object
        /// </summary>
        /// <param name="payload">object to use</param>
        public void PostMessage(Payload payload)
        {
            string payloadJson = JsonConvert.SerializeObject(payload);

            using (WebClient client = new WebClient())
            {
                if (!string.IsNullOrEmpty(_proxyHost))
                { 
                    client.Proxy = new WebProxy(_proxyHost, _proxyPort);
                    client.Proxy.Credentials = new NetworkCredential(_proxyLogin, _proxyPassword);
                }
                NameValueCollection data = new NameValueCollection();
                data["payload"] = payloadJson;

                client.Credentials = new NetworkCredential("29216308806.33597466784", "bc4a3e7d1df9ac28f4dbfc9ee2e0c909");
                var response = client.UploadValues(_uri, "POST", data);

                //The response text is usually "ok"
                string responseText = _encoding.GetString(response);
            }
        }
    }

    //This class serializes into the Json payload required by Slack Incoming WebHooks
    public class Payload
    {
        [JsonProperty("channel")]
        public string Channel { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }
    }
}
