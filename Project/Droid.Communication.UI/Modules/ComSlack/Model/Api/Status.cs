using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Droid.Communication
{
    public class Status : Permission
    {
        #region Attributes
        private string _presence;
        private bool _online;
        private bool _autoAway;
        private bool _manualAway;
        private int _connectionCount;
        private string _lastActivity;
        #endregion

        #region Properties
        public string Last_Activity
        {
            get { return _lastActivity; }
            set { _lastActivity = value; }
        }
        public int Connection_Count
        {
            get { return _connectionCount; }
            set { _connectionCount = value; }
        }
        public bool Manual_Away
        {
            get { return _manualAway; }
            set { _manualAway = value; }
        }
        public bool Auto_Away
        {
            get { return _autoAway; }
            set { _autoAway = value; }
        }
        public bool Online
        {
            get { return _online; }
            set { _online = value; }
        }
        public string Presence
        {
            get { return _presence; }
            set { _presence = value; }
        }
        #endregion

        #region Constructor
        public Status()
        {

        }
        #endregion
    }
}
