namespace Droid.Communication
{
    public class Team : Permission
    {
        private string _id;
        private string _name;
        private string _domain;
        private string _emailDomain;
        private Icon _icon;

        public Icon Icon
        {
            get { return _icon; }
            set { _icon = value; }
        }
        public string Email_Domain
        {
            get { return _emailDomain; }
            set { _emailDomain = value; }
        }
        public string Domain
        {
            get { return _domain; }
            set { _domain = value; }
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

        public Team()
        {
        }
    }
}
