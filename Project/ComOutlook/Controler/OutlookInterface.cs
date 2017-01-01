using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Runtime.InteropServices;
using Microsoft.Office.Interop.Outlook;
using OutlookLib = Microsoft.Office.Interop.Outlook;
using System.Drawing;
using System.IO;

namespace Droid_communication
{
    public delegate void OutlookInterfaceEventHandler(object o);
    public class OutlookInterface
    {
        #region Attribute
        public event OutlookInterfaceEventHandler MailReceived;

        private MAPIFolder _inbox;
        private List<MailItem> _mailsInbox;
        private MAPIFolder _sentbox;
        private List<MailItem> _mailsSentBox;
        private NameSpace _namespace;
        private OutlookLib.Application _outlook = Marshal.GetActiveObject("Outlook.Application") as OutlookLib.Application;
        private int _unread;

        private static OutlookInterface intOutlook;
        #endregion

        #region Properties
        public List<MailItem> MailsInbox
        {
            get { return _mailsInbox; }
            set { _mailsInbox = value; }
        }
        public List<MailItem> MailsSentBox
        {
            get { return _mailsSentBox; }
            set { _mailsSentBox = value; }
        }
        public int UnreadMailCount
        {
            get { return _unread; }
        }
        public OutlookLib.Application Outlook
        {
            get { return _outlook; }
            set { _outlook = value;  }
        }
        #endregion

        #region Constructor
        public OutlookInterface()
        {
            _unread = 0;
            _mailsInbox = new List<MailItem>();
            _mailsSentBox = new List<MailItem>();
            _namespace = _outlook.GetNamespace("Mapi");
            _inbox = _namespace.GetDefaultFolder(OlDefaultFolders.olFolderInbox);
            _inbox.Items.ItemAdd += Items_ItemAdd;
            _sentbox = _namespace.GetDefaultFolder(OlDefaultFolders.olFolderSentMail);
            UpdateInbox();
        }
        #endregion

        #region Methods public
        public static bool ACTION_130_envoyer_mail(string titre, List<string> mail_destinataire, string message, List<string> piece_jointe = null, List<string> mail_destinataire_copie = null, List<string> mail_destinataire_copie_cache = null)
        {
            try
            {
                if (intOutlook == null) intOutlook = new OutlookInterface();
                OutlookLib.MailItem mail = intOutlook.Outlook.CreateItem(OutlookLib.OlItemType.olMailItem) as OutlookLib.MailItem;
                mail.Subject = titre;
                OutlookLib.AddressEntry currentUser = intOutlook.Outlook.Session.CurrentUser.AddressEntry;
                if (currentUser.Type == "EX")
                {
                    OutlookLib.ExchangeUser manager = currentUser.GetExchangeUser().GetExchangeUserManager();

                    mail.To = string.Empty;
                    foreach (string mailAdress in mail_destinataire)
                    {
                        mail.Recipients.Add(mailAdress);
                    }
                    mail.Recipients.ResolveAll();
                    mail.CC = string.Empty;
                    if (mail_destinataire_copie != null)
                    { 
                        foreach (string mailAdress in mail_destinataire_copie)
                        {
                            if (!string.IsNullOrEmpty(mail.CC)) { mail.CC += ";"; }
                            mail.CC += mailAdress;
                        }
                    }
                    mail.BCC = string.Empty;
                    if (mail_destinataire_copie_cache != null)
                    {
                        foreach (string mailAdress in mail_destinataire_copie_cache)
                        {
                            if (!string.IsNullOrEmpty(mail.BCC)) { mail.BCC += ";"; }
                            mail.BCC += mailAdress;
                        }
                    }
                    if (piece_jointe != null)
                    { 
                        foreach (string attachmentPath in piece_jointe)
                        {
                            mail.Attachments.Add(attachmentPath, OutlookLib.OlAttachmentType.olByValue, Type.Missing, Type.Missing);
                        }
                    }
                    mail.Body = message;
                    mail.Send();
                }
                return true;
            }
            catch (System.Exception exp)
            {
                Console.WriteLine(exp.Message);
                return false;
            }
        }
        public static List<MailItem> ACTION_131_lister_mail(string folder = null)
        {
            if (intOutlook == null) intOutlook = new OutlookInterface();
            if (string.IsNullOrEmpty(folder)) { folder = "inbox"; }

            MAPIFolder selectedFolder = null;
            switch (folder.ToLower())
            {
                case "calendar":
                    selectedFolder = intOutlook._namespace.GetDefaultFolder(OlDefaultFolders.olFolderCalendar);
                    break;
                case "conflict":
                    selectedFolder = intOutlook._namespace.GetDefaultFolder(OlDefaultFolders.olFolderConflicts);
                    break;
                case "contact":
                    selectedFolder = intOutlook._namespace.GetDefaultFolder(OlDefaultFolders.olFolderContacts);
                    break;
                case "deleted":
                    selectedFolder = intOutlook._namespace.GetDefaultFolder(OlDefaultFolders.olFolderDeletedItems);
                    break;
                case "draft":
                    selectedFolder = intOutlook._namespace.GetDefaultFolder(OlDefaultFolders.olFolderDrafts);
                    break;
                case "journal":
                    selectedFolder = intOutlook._namespace.GetDefaultFolder(OlDefaultFolders.olFolderJournal);
                    break;
                case "sent":
                    selectedFolder = intOutlook._namespace.GetDefaultFolder(OlDefaultFolders.olFolderSentMail);
                    break;
                case "tasks":
                    selectedFolder = intOutlook._namespace.GetDefaultFolder(OlDefaultFolders.olFolderTasks);
                    break;
                case "todo":
                    selectedFolder = intOutlook._namespace.GetDefaultFolder(OlDefaultFolders.olFolderToDo);
                    break;
                case "inbox":
                    selectedFolder = intOutlook._namespace.GetDefaultFolder(OlDefaultFolders.olFolderInbox);
                    break;
                default:
                    try
                    {
                        foreach (Folder item in intOutlook._namespace.Folders)
                        {
                            if (item.Name.Equals(folder))
                            {
                                selectedFolder = item;
                                break;
                            }
                        }
                    }
                    catch (System.Exception exp)
                    {
                        Console.WriteLine(exp.Message);
                    }
                    break;
            }
            List<MailItem> mails = new List<MailItem>();
            if (selectedFolder != null)
            { 
                foreach (object item in selectedFolder.Items)
                {
                    if (item is MailItem) mails.Add((MailItem)item);
                }
            }
            return mails;
        }
        public static bool ACTION_132_supprimer_mail(string title, string author, DateTime date, string folder)
        {
            List<MailItem> mails = ACTION_131_lister_mail(folder);
            mails = mails.Where(m => m.Subject.Equals(title) && m.ReceivedTime == date && m.SenderEmailAddress.Equals(author)).ToList();
            if (mails.Count == 1)
            {
                mails[0].Delete();
                return true;
            }
            return false;
        }
        public static string ACTION_133_donner_login()
        {
            if (intOutlook == null) intOutlook = new OutlookInterface();
            return intOutlook.Outlook.Session.CurrentUser.Name;
        }
        public static string ACTION_134_chercher_mail(string nom, string prenom)
        {
            if (intOutlook == null) intOutlook = new OutlookInterface();
            
            NameSpace outlookNameSpace = intOutlook.Outlook.GetNamespace("MAPI");
            MAPIFolder contactsFolder = outlookNameSpace.GetDefaultFolder(OlDefaultFolders.olFolderContacts);
            Items contactItems = contactsFolder.Items;

            try
            {
                ContactItem contact = contactItems.Find(String.Format("[FirstName]='{0}' and "+ "[LastName]='{1}'", prenom, nom)) as ContactItem;
                if (contact != null)
                {
                    return contact.MailingAddress;
                }
                else
                {
                    Console.WriteLine("The contact information was not found.");
                }
            }
            catch (System.Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
            return string.Empty;
        }

        public bool IsMailReplied(MailItem mail)
        {
            return _mailsSentBox.Where(m => m.Subject.Contains(mail.Subject) && m.CreationTime > mail.ReceivedTime && m.To.Contains(mail.SenderName)).ToList().Count > 0;
        }
        public bool IsMailForwarded(MailItem mail)
        {
            return _mailsSentBox.Where(m => m.Subject.Contains(mail.Subject) && m.CreationTime > mail.ReceivedTime && !m.To.Contains(mail.SenderName)).ToList().Count > 0;
        }
        #endregion

        #region Mehtods private
        private void UpdateInbox()
        {
            object _missing = Type.Missing;

            _namespace.Logon(_missing, _missing, false, true);
            _unread = _inbox.UnReadItemCount;

            _mailsInbox.Clear();
            foreach (object item in _inbox.Items)
            {
                if (item is MailItem) _mailsInbox.Add((MailItem)item);
            }
            _mailsSentBox.Clear();
            foreach (object item in _sentbox.Items)
            {
                if (item is MailItem) _mailsSentBox.Add((MailItem)item);
            }
        }
        private void CreateMail(string titre, List<string> mail_destinataire, string message, List<string> piece_jointe = null, string mail_destinataire_copie = "", string mail_destinataire_copie_cache = "")
        {
            OutlookLib.OlItemType itemType = OutlookLib.OlItemType.olMailItem;
            OutlookLib.MailItem mail = _outlook.CreateItem(itemType) as OutlookLib.MailItem;
            mail.Subject = titre;
            OutlookLib.AddressEntry currentUser = _outlook.Session.CurrentUser.AddressEntry;
            if (currentUser.Type == "EX")
            {
                OutlookLib.ExchangeUser manager =currentUser.GetExchangeUser().GetExchangeUserManager();
                // Add recipient using display name, alias, or smtp address
                mail.Recipients.Add(manager.PrimarySmtpAddress);
                mail.Recipients.ResolveAll();
                mail.Attachments.Add(@"c:\sales reports\fy06q4.xlsx", OutlookLib.OlAttachmentType.olByValue, Type.Missing,Type.Missing);
                mail.Send();
            }
        }
        #endregion

        #region Event
        private void Items_ItemAdd(object Item)
        {
            if (MailReceived != null)
            {
                MailReceived(Item);
            }
        }
        #endregion
    }
}
