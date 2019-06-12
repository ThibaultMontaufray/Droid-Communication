using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Droid.Communication
{
    public class Paging
    {
        private int _count;
        private int _total;
        private int _page;
        private int _pages;

        public int Pages
        {
            get { return _pages; }
            set { _pages = value; }
        }
        public int Page
        {
            get { return _page; }
            set { _page = value; }
        }
        public int Total
        {
            get { return _total; }
            set { _total = value; }
        }
        public int Count
        {
            get { return _count; }
            set { _count = value; }
        }

        public Paging()
        {

        }
    }
}
