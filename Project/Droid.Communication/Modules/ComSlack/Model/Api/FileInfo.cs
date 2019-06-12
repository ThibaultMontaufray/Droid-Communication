using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Droid.Communication
{
    public class FileInfo
    {
        private bool _ok;
        private SlackFile _file;
        private List<CommentDetail> _comments;
        private Paging _paging;

        public Paging Paging
        {
            get { return _paging; }
            set { _paging = value; }
        }
        public List<CommentDetail> Comments
        {
            get { return _comments; }
            set { _comments = value; }
        }
        public SlackFile File
        {
            get { return _file; }
            set { _file = value; }
        }
        public bool Ok
        {
            get { return _ok; }
            set { _ok = value; }
        }

        public FileInfo()
        {
            _comments = new List<CommentDetail>();
        }
    }
}
