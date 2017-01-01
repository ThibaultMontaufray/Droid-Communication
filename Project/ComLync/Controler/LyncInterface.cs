namespace Droid_communication
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.Lync;
    using Microsoft.Lync.Model;
    using Microsoft.Lync.Model.Group;
    using Microsoft.Lync.Model.Conversation;

    public delegate void LyncInterfaceEventHandler();
    public delegate void LyncInterfaceEventHandlerConversation(string message);
    public class LyncInterface
    {
        #region Attribute
        private LyncClient _lyncClient;
        private List<string> _searchResult;
        private Dictionary<string, int> _dicoResult;
        private Conversation _conversation;
        private string _participantIm;

        public event LyncInterfaceEventHandler SearchListChanged;
        public event LyncInterfaceEventHandler StatusChanged;
        public event LyncInterfaceEventHandlerConversation MessageReceived;
        #endregion

        #region Properties
        public List<string> SearchResult
        {
            get
            {
                return _searchResult;
            }
            set
            {
                _searchResult = value;
            }
        }
        public LyncClient Client
        {
            get { return _lyncClient; }
        }
        public Dictionary<string, int> Dico
        {
            get { return _dicoResult; }
        }
        #endregion

        #region Constructor
        public LyncInterface()
        {
            _searchResult = new List<string>();
            _dicoResult = new Dictionary<string, int>();

            _lyncClient = LyncClient.GetClient();

            ContactManager contactMng = _lyncClient.ContactManager;

            if (_lyncClient.SignInConfiguration.SignedInFromIntranet)
            {
                if (contactMng.GetSearchProviderStatus(SearchProviders.ExchangeService) == SearchProviderStatusType.SyncSucceeded)
                {
                    //var v1 = SearchProviders.ExchangeService;
                }
                if (contactMng.GetSearchProviderStatus(SearchProviders.Expert) == SearchProviderStatusType.SyncSucceeded)
                {
                    //var v2 = SearchProviders.Expert;
                }
                if (contactMng.GetSearchProviderStatus(SearchProviders.GlobalAddressList) == SearchProviderStatusType.SyncSucceeded)
                {
                    //var v3 = SearchProviders.GlobalAddressList;
                }
            }


            var lstConversation = _lyncClient.ConversationManager.Conversations;
            foreach (var conv in lstConversation)
            {
                string lstPart = string.Empty;
                foreach (var part in conv.Participants)
                {
                    Console.WriteLine(part.Contact.Uri);
                }
                //Console.WriteLine("Participants " + conv.Participants.);
            }
            //foreach (var group in cm.Groups)
            //{
            //    Console.WriteLine(group.Name);
            //}

            Console.WriteLine(_lyncClient.State);
            GetAllContacts();
        }
        #endregion

        #region Methods protected
        protected void OnSearchListChanged()
        {
            if (SearchListChanged != null) SearchListChanged();
        }
        protected void OnStatusChanged()
        {
            if (StatusChanged != null) StatusChanged();
        }
        protected void OnMessageReceived(string message)
        {
            if (MessageReceived != null) MessageReceived(message);
        }
        #endregion

        #region Methods public
        public void SearchForContacts(string searchKey)
        {
            if (!string.IsNullOrEmpty(searchKey) && _lyncClient.SignInConfiguration.SignedInFromIntranet == true)
            {
                Console.WriteLine("Searching for contacts on " + searchKey);
                string retVal = string.Empty;

                _searchResult.Clear();
                _lyncClient.ContactManager.BeginSearch(
                    searchKey,
                    (ar) =>
                    {
                        SearchResults sr = _lyncClient.ContactManager.EndSearch(ar);
                        if (sr.Contacts.Count > 0)
                        {
                            Console.WriteLine(sr.Contacts.Count.ToString() + " found");

                            string s;
                            foreach (Contact contact in sr.Contacts)
                            {
                                //  + " " + (contact.GetContactInformation(ContactInformationType.Availability).ToString() == "3500" ? "ONLINE" : "OFFLINE")
                                s = contact.GetContactInformation(ContactInformationType.DisplayName).ToString();
                                SearchResult.Add(s);
                                retVal += s + " - ";
                                //Console.WriteLine(s);
                            }
                        }
                        OnSearchListChanged();
                    },
                    null
                );
            }
        }
        public void GetStatus(string userName)
        {
            if (!string.IsNullOrEmpty(userName) && _lyncClient.SignInConfiguration.SignedInFromIntranet == true)
            {
                _lyncClient.ContactManager.BeginSearch(
                    userName,
                    (ar) =>
                    {
                        SearchResults sr = _lyncClient.ContactManager.EndSearch(ar);
                        if (sr.Contacts.Count == 1)
                        {
                            _dicoResult[sr.Contacts[0].GetContactInformation(ContactInformationType.DisplayName).ToString()] = (int)sr.Contacts[0].GetContactInformation(ContactInformationType.Availability);
                            //Console.WriteLine(sr.Contacts[0].GetContactInformation(ContactInformationType.DisplayName).ToString());
                            //result = sr.Contacts[0].GetContactInformation(ContactInformationType.Availability).ToString() == "3500" ? true : false;
                            //foreach (Contact contact in sr.Contacts)
                            //{
                            //    //  + " " + (contact.GetContactInformation(ContactInformationType.Availability).ToString() == "3500" ? "ONLINE" : "OFFLINE")
                            //    s = <contact.GetContactInformation(ContactInformationType.DisplayName).ToString();
                            //    SearchResult.Add(s);
                            //    retVal += s + " - ";
                            //    Console.WriteLine(s);
                            //}
                            OnStatusChanged();
                        }
                    },
                    null
                );
            }
        }
        public void GetUserDetails(string userName)
        {
            object result;
            string s;
            string retVal = string.Empty;

            if (!string.IsNullOrEmpty(userName) && _lyncClient.SignInConfiguration.SignedInFromIntranet == true)
            {
                _lyncClient.ContactManager.BeginSearch(
                    userName,
                    (ar) =>
                    {
                        SearchResults sr = _lyncClient.ContactManager.EndSearch(ar);
                        if (sr.Contacts.Count == 1)
                        {
                            _dicoResult[sr.Contacts[0].GetContactInformation(ContactInformationType.DisplayName).ToString()] = (int)sr.Contacts[0].GetContactInformation(ContactInformationType.Availability);
                            //Console.WriteLine(sr.Contacts[0].GetContactInformation(ContactInformationType.DisplayName).ToString());
                            result = sr.Contacts[0].GetContactInformation(ContactInformationType.Availability).ToString() == "3500" ? true : false;
                            foreach (Contact contact in sr.Contacts)
                            {
                                //  + " " + (contact.GetContactInformation(ContactInformationType.Availability).ToString() == "3500" ? "ONLINE" : "OFFLINE")
                                s = contact.GetContactInformation(ContactInformationType.DisplayName).ToString();
                                s += " - " + contact.GetContactInformation(ContactInformationType.Office).ToString();
                                SearchResult.Add(s);
                                retVal += s + " - ";
                                Console.WriteLine(s);
                            }
                            OnStatusChanged();
                        }
                    },
                    null
                );
            }
        }
        public void SendMessage(string message, string dest)
        {
            _participantIm = dest;
            Contact contact = _lyncClient.ContactManager.GetContactByUri(_participantIm);

            _conversation = _lyncClient.ConversationManager.AddConversation();
            _conversation.ParticipantAdded += new EventHandler<ParticipantCollectionChangedEventArgs>(conversation_ParticipantAdded);
            _conversation.AddParticipant(contact);

            Dictionary<InstantMessageContentType, String> messages = new Dictionary<InstantMessageContentType, String>();
            messages.Add(InstantMessageContentType.PlainText, message);

            InstantMessageModality m = (InstantMessageModality)_conversation.Modalities[ModalityTypes.InstantMessage];
            m.BeginSendMessage(messages, null, messages);
            _conversation.ContextDataReceived += new EventHandler<ContextEventArgs>(conversation_ContextDataReceived);
            _conversation.End();
        }

        private void conversation_ParticipantAdded(object sender, ParticipantCollectionChangedEventArgs e)
        {
            var instantMessageModality = e.Participant.Modalities[ModalityTypes.InstantMessage] as InstantMessageModality;
            instantMessageModality.InstantMessageReceived += this.Participant_InstantMessageReceived;
        }

        private void Participant_InstantMessageReceived(object sender, MessageSentEventArgs e)
        {
            OnMessageReceived(e.Text);
        }
        private void conversation_ContextDataReceived(object sender, ContextEventArgs e)
        {
            OnMessageReceived(e.ContextData);
        }
        #endregion

        #region Methods private
        #endregion

        private static char[] Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
        public void GetAllContacts()
        {
            int initialLetterIndex = 0;

            var res = _lyncClient.ContactManager.BeginSearch(Alphabet[initialLetterIndex].ToString(),
                SearchProviders.GlobalAddressList,
                SearchFields.FirstName,
                SearchOptions.ContactsOnly,
                300,
                SearchAllCallback,
                new object[] { initialLetterIndex, new List<Contact>() }
              );
        }

        private void SearchAllCallback(IAsyncResult result)
        {
            string s;
            foreach (char letter in Alphabet)
            {
                _lyncClient.ContactManager.BeginSearch(
                    letter.ToString(),
                    (ar) =>
                    {
                        try
                        {
                            SearchResults sr = _lyncClient.ContactManager.EndSearch(ar);
                            if (sr.Contacts.Count == 1)
                            {
                                _dicoResult[sr.Contacts[0].GetContactInformation(ContactInformationType.DisplayName).ToString()] = (int)sr.Contacts[0].GetContactInformation(ContactInformationType.Availability);
                                //Console.WriteLine(sr.Contacts[0].GetContactInformation(ContactInformationType.DisplayName).ToString());
                                foreach (Contact contact in sr.Contacts)
                                {
                                    //  + " " + (contact.GetContactInformation(ContactInformationType.Availability).ToString() == "3500" ? "ONLINE" : "OFFLINE")
                                    s = contact.GetContactInformation(ContactInformationType.DisplayName).ToString();
                                    s += " - " + contact.GetContactInformation(ContactInformationType.Office).ToString();
                                    SearchResult.Add(s);
                                    Console.WriteLine(s);
                                }
                                OnStatusChanged();
                            }
                        }
                        catch (Exception exp)
                        {
                            Console.WriteLine("Search all : " + exp.Message);
                        }
                    },
                    null
                );
            }
        }
    }
}
