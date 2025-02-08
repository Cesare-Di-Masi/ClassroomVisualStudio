using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VERIFICA_NOVEMBRE_DIMASI
{
    public class Session
    {
        private int _hours, _minutes,_seconds;
        private bool _isIntensive=false;

        public int Hours
        {
            get 
            {
                return _hours; 
            }

            private set
            {
                if (value < 0) { throw new ArgumentOutOfRangeException("Hour is illegal"); }

                _hours = value;
            }
        }

        public int Minutes
        {
            get
            {
                return _minutes;
            }

            private set 
            {
                if (value < 0 || value > 60) { throw new ArgumentOutOfRangeException("minutes is Illegal"); }

                _minutes = value;
            }
        }

        public int Seconds
        {
            get
            {
                return _seconds;
            }

            private set
            {
                if (value < 0 || value >60) { throw new ArgumentOutOfRangeException("seconds is Illegal"); }

                _seconds = value;
            }
        }

        public bool IsIntensive
        { 
            get
            {
                return _isIntensive;
            }
            private set
            {
                
                if (Hours > 4 && (Minutes >0 || Seconds >0)) 
                    _isIntensive = true;
                else
                    _isIntensive = false;
                
            }
        }


        public Session(int hours, int minutes, int seconds)  
        {
            Hours = hours;
            Minutes = minutes;
            Seconds = seconds;
        }

        public int getMinutes()
        {
            return Minutes + Hours * 60;
        }

        public int getSeconds()
        {
            return Seconds + Minutes * 60 + Hours * 3600;
        }


        //per il controllo dei test sovrascrivo il metodo Equal

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;

            if (!(obj is Session)) return false;

            Session session = obj as Session;

            if (Hours == session.Hours && Minutes == session.Minutes && Seconds == session.Seconds) return true;
            return false;
        }

    }
}
