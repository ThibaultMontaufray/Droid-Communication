using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Droid.Communication
{
    public class Token
    {
        #region Attributes
        private string _key;
        private DateTime _expiration;
        private bool _isUsed;
        #endregion

        #region Properties
        public bool IsUsed
        {
            get { return _isUsed; }
            set { _isUsed = value; }
        }
        public DateTime Expiration
        {
            get { return _expiration; }
            set { _expiration = value; }
        }
        public string Key
        {
            get { return _key; }
            set { _key = value; }
        }
        #endregion

        #region Constructor
        public Token()
        {
            _expiration = DateTime.MaxValue;
            _isUsed = false;
        }
        #endregion

        #region Methods public
        #endregion

        #region Methods private
        #endregion
    }
}
