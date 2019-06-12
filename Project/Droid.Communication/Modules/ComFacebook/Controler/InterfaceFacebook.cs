using SimpleFacebookClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Droid.Communication
{
    // https://graph.facebook.com/v2.11/me?fields=id,birthday,name,first_name,last_name,middle_name,name_format,political,public_key,quotes,relationship_status,religion,shared_login_upgrade_required_by,significant_other,link,sports,test_group,third_party_id,timezone,updated_time,verified,video_upload_limits,viewer_can_send_gift,website,work,locale,location,meeting_for,email,education,favorite_athletes,favorite_teams,hometown,inspirational_people,install_type,installed,interested_in,is_shared_login,is_verified,languages,gender,security_settings,cover,payment_pricepoints,devices,currency,picture&access_token="
    /*
     is_shared_login,
     shared_login_upgrade_required_by
         */
    //https://graph.facebook.com/v2.11/{userid}?fields=id,birthday,name,first_name,last_name,middle_name,name_format,political,public_key,quotes,relationship_status,religion,significant_other,link,sports,test_group,third_party_id,timezone,updated_time,verified,video_upload_limits,viewer_can_send_gift,website,work,locale,location,meeting_for,email,education,favorite_athletes,favorite_teams,hometown,inspirational_people,install_type,installed,interested_in,is_verified,languages,gender,security_settings,cover,payment_pricepoints,devices,currency,picture&access_token="
    // salma : 1625754514134931
    // camille : 1927436460617002
    public class FacebookAdapter : CommunicationAdapter
    {
        #region Attributes
        private string _token;
        private string _appId;
        private string _appSecret;
        #endregion

        #region Properties
        public string Token
        {
            get { return _token; }
            set
            {
                _token = value;
                Init();
            }
        }
        public string AppSecret
        {
            get { return _appSecret; }
            set { _appSecret = value; }
        }
        public string AppId
        {
            get { return _appId; }
            set { _appId = value; }
        }
        #endregion

        #region Constructor
        public FacebookAdapter(string token = "")
        {
            _token = token;
            Init();
        }
        public FacebookAdapter(InterfaceCommunication intCom, string token = "")
        {
            _parent = intCom;
            _token = token;
            Init();
        }
        #endregion

        #region Methods public
        public void PostToWall(string message)
        {
            //PostToWall(message, userId, fb.AccessToken);
        }
        #endregion

        #region Methods private
        private void Init()
        {
            if (!string.IsNullOrEmpty(_token))
            {
                //_appId = "1705001929734858";
                //_appSecret = "ffafdf4b593b42af0fdbca7a03eba34f";
                //FacebookClient _facebook = new FacebookClient(_token);

                //dynamic result = _facebook.Get<Task>("me/inbox", null);
                //dynamic result = _facebook.Get<var>("oauth/access_token", new
                //{
                //    client_id = _appId,
                //    client_secret = _appSecret,
                //    grant_type = "client_credentials"
                //});
                //_facebook.AccessToken = result.access_token;
            }
        }
        private void ProcessPostToWall(string message, string userId, string wallAccessToken)
        {
            //try
            //{
            //    var fb = new FacebookClient(wallAccessToken);
            //    string url = string.Format("{0}/{1}", userId, "feed");
            //    var argList = new Dictionary<string, object>();
            //    argList["message"] = message;
            //    fb.Post(url, argList);
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
        }
        #endregion

        #region Event
        #endregion
    }
}
