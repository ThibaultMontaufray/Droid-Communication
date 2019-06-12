using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Droid.Communication
{
    public class DoNotDisturb
    {
        private bool _ok;
        private bool _dndEnabled;
        private int _nextDndStartTs;
        private int _nextDndEndTs;
        private bool _snoozeEnabled;
        private int _snoozeEndTime;
        private int _snoozeRemaining;

        public int Snooze_Remaining
        {
            get { return _snoozeRemaining; }
            set { _snoozeRemaining = value; }
        }
        public int Snooze_EndTime
        {
            get { return _snoozeEndTime; }
            set { _snoozeEndTime = value; }
        }
        public bool Snooze_Enabled
        {
            get { return _snoozeEnabled; }
            set { _snoozeEnabled = value; }
        }
        public int Next_Dnd_End_Ts
        {
            get { return _nextDndEndTs; }
            set { _nextDndEndTs = value; }
        }
        public int Next_Dnd_Start_Ts
        {
            get { return _nextDndStartTs; }
            set { _nextDndStartTs = value; }
        }
        public bool Dnd_Enabled
        {
            get { return _dndEnabled; }
            set { _dndEnabled = value; }
        }
        public bool Ok
        {
            get { return _ok; }
            set { _ok = value; }
        }

        public DoNotDisturb()
        {

        }
    }
}
