using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Droid.Communication
{
    public class Profile
    {
        private string _firstName;
        private string _lastName;
        private string _avatarHash;
        private string _title;
        private string _skype;
        private string _phone;
        private string _image24;
        private string _image32;
        private string _image48;
        private string _image72;
        private string _image192;
        private string _image512;
        private string _image1024;
        private string _imageOriginal;
        private string _realName;
        private string _displayName;
        private string _realNameNormalized;
        private string _displayNameNormalized;
        private string _email;
        private string _team;

        public string Team
        {
            get { return _team; }
            set { _team = value; }
        }
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        public string Display_Name_Normalized
        {
            get { return _displayNameNormalized; }
            set { _displayNameNormalized = value; }
        }
        public string Real_Name_Normalized
        {
            get { return _realNameNormalized; }
            set { _realNameNormalized = value; }
        }
        public string Display_Name
        {
            get { return _displayName; }
            set { _displayName = value; }
        }
        public string Real_Name
        {
            get { return _realName; }
            set { _realName = value; }
        }
        public string Image_Original
        {
            get { return _imageOriginal; }
            set { _imageOriginal = value; }
        }
        public string Image_1024
        {
            get { return _image1024; }
            set { _image1024 = value; }
        }
        public string Image_512
        {
            get { return _image512; }
            set { _image512 = value; }
        }
        public string Image_192
        {
            get { return _image192; }
            set { _image192 = value; }
        }
        public string Image_72
        {
            get { return _image72; }
            set { _image72 = value; }
        }
        public string Image_48
        {
            get { return _image48; }
            set { _image48 = value; }
        }
        public string Image_32
        {
            get { return _image32; }
            set { _image32 = value; }
        }
        public string Image_24
        {
            get { return _image24; }
            set { _image24 = value; }
        }
        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }
        public string Skype
        {
            get { return _skype; }
            set { _skype = value; }
        }
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
        public string Avatar_Hash
        {
            get { return _avatarHash; }
            set { _avatarHash = value; }
        }
        public string Last_Name
        {
            get { return _lastName; }
            set { _lastName = value; }
        }
        public string First_Name
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        public Profile()
        {

        }
    }
}
