namespace Droid_communication
{
    using Assistant;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Mail;
    using Tools4Libraries;

    /// <summary>
    /// Interface for Tobi Assistant application : take care, some french word here to allow Tobi to speak with natural langage.
    /// </summary>            
    public class Interface_com : GPInterface
    {
        #region Attribute
        #endregion

        #region Constructor
        public Interface_com()
        {

        }
        #endregion

        #region Actions
        public static void ACTION_130_envoyer_mail(string titre, List<MailAddress> mail_destinataire, string message, List<Attachment> piece_jointe = null, string mail_destinataire_copie = "", string mail_destinataire_copie_cache = "")
        {
            //Mail.SendMail(titre, mail_destinataire, piece_jointe, message, mail_destinataire_copie, mail_destinataire_copie_cache);
        }
        public static bool ACTION_131_envoyer_message(string canal, string message, string destinataire)
        {
            try
            {
                switch(canal.ToLower())
                {
                    case "lync":
                    case "lynk":
                    case "linc":
                    case "link":
                        break;
                    case "mail":
                    case "outlook":
                    case "gmail":
                        break;
                    case "slack":
                    case "slac":
                    case "slak":
                        break;
                }

                using (var client = new WebClient())
                {
                    using (var stream = client.OpenRead("http://www.google.com"))
                    {
                        return true;
                    }
                }
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region Methods public
        public override void GoAction(string action)
        {
            throw new System.NotImplementedException();
        }
        #endregion
    }
}
