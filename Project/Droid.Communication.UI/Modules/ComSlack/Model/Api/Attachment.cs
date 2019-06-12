using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Droid.Communication
{
    public class SlackAttachment
    {
        private string _text;
        private string _id;
        private string _fallBack;
        private string _serviceName;
        private string _thumbUrl;
        private int _thumbWidth;
        private int _thumbHeight;

        public int Thumb_Height
        {
            get { return _thumbHeight; }
            set { _thumbHeight = value; }
        }
        public int Thumb_Width
        {
            get { return _thumbWidth; }
            set { _thumbWidth = value; }
        }
        public string Thumb_Url
        {
            get { return _thumbUrl; }
            set { _thumbUrl = value; }
        }
        public string Service_Name
        {
            get { return _serviceName; }
            set { _serviceName = value; }
        }
        public string Fall_Back
        {
            get { return _fallBack; }
            set { _fallBack = value; }
        }
        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }

        public SlackAttachment()
        {

        }
    }
}
