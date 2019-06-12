using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Droid.Communication
{
    public class SlackFile
    {
        private string _id;
        private int _timeStamp;
        private string _name;
        private string _title;
        private string _mimeType;
        private string _fileType;
        private string _prettyType;
        private string _user;
        private string _mode;
        private bool _editable;
        private bool _isExternal;
        private string _externalType;
        private int _size;
        private string _url;
        private string _urlDownload;
        private string _urlPrivate;
        private string _urlPrivateDownload;
        private string _thumb64;
        private string _thumb80;
        private string _thumb360;
        private string _thumb360Gif;
        private int _thumb360W;
        private int _thumb360H;
        private string _permaLink;
        private string _editLink;
        private string _preview;
        private string _previewHighlight;
        private int _lines;
        private int _linesMore;
        private bool _isPublic;
        private string _publicUrlShared;
        private List<string> _channels;
        private List<string> _groups;
        private string _initialComment;
        private int _numStars;
        private bool _isStarred;

        public bool Is_Starred
        {
            get { return _isStarred; }
            set { _isStarred = value; }
        }
        public int Num_Stars
        {
            get { return _numStars; }
            set { _numStars = value; }
        }
        public string Initial_Comment
        {
            get { return _initialComment; }
            set { _initialComment = value; }
        }
        public List<string> Groups
        {
            get { return _groups; }
            set { _groups = value; }
        }
        public List<string> Channels
        {
            get { return _channels; }
            set { _channels = value; }
        }
        public string Public_Url_Shared
        {
            get { return _publicUrlShared; }
            set { _publicUrlShared = value; }
        }
        public bool Is_Public
        {
            get { return _isPublic; }
            set { _isPublic = value; }
        }
        public int Lines_More
        {
            get { return _linesMore; }
            set { _linesMore = value; }
        }
        public int Lines
        {
            get { return _lines; }
            set { _lines = value; }
        }
        public string Preview_Highlight
        {
            get { return _previewHighlight; }
            set { _previewHighlight = value; }
        }
        public string Preview
        {
            get { return _preview; }
            set { _preview = value; }
        }
        public string Edit_Link
        {
            get { return _editLink; }
            set { _editLink = value; }
        }
        public string Perma_Link
        {
            get { return _permaLink; }
            set { _permaLink = value; }
        }
        public int Thumb_360_H
        {
            get { return _thumb360H; }
            set { _thumb360H = value; }
        }
        public int Thumb_360_W
        {
            get { return _thumb360W; }
            set { _thumb360W = value; }
        }
        public string Thumb_360_Gif
        {
            get { return _thumb360Gif; }
            set { _thumb360Gif = value; }
        }
        public string Thumb_360
        {
            get { return _thumb360; }
            set { _thumb360 = value; }
        }
        public string Thumb_80
        {
            get { return _thumb80; }
            set { _thumb80 = value; }
        }
        public string Thumb_64
        {
            get { return _thumb64; }
            set { _thumb64 = value; }
        }
        public string Url_Private_Download
        {
            get { return _urlPrivateDownload; }
            set { _urlPrivateDownload = value; }
        }
        public string Url_Private
        {
            get { return _urlPrivate; }
            set { _urlPrivate = value; }
        }
        public string Url_Download
        {
            get { return _urlDownload; }
            set { _urlDownload = value; }
        }
        public string Url
        {
            get { return _url; }
            set { _url = value; }
        }
        public int Size
        {
            get { return _size; }
            set { _size = value; }
        }
        public string External_Type
        {
            get { return _externalType; }
            set { _externalType = value; }
        }
        public bool Is_External
        {
            get { return _isExternal; }
            set { _isExternal = value; }
        }
        public bool Editable
        {
            get { return _editable; }
            set { _editable = value; }
        }
        public string Mode
        {
            get { return _mode; }
            set { _mode = value; }
        }
        public string User
        {
            get { return _user; }
            set { _user = value; }
        }
        public string Pretty_Type
        {
            get { return _prettyType; }
            set { _prettyType = value; }
        }
        public string File_Type
        {
            get { return _fileType; }
            set { _fileType = value; }
        }
        public string Mime_Type
        {
            get { return _mimeType; }
            set { _mimeType = value; }
        }
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public int TimeStamp
        {
            get { return _timeStamp; }
            set { _timeStamp = value; }
        }
        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public SlackFile()
        {
            _channels = new List<string>();
            _groups = new List<string>();
        }
    }
}
