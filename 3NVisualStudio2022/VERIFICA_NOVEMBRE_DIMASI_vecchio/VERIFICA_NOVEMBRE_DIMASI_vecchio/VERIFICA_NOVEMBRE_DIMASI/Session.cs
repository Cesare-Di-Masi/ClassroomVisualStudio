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
        private bool _isIntensive;

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
                //nel caso la sessione sia di tipo standard ma la durata è maggiore di 4 o viceversa restituiamo un errore
                if (value == false && _hours > 4 || value == true && _hours < 4) { throw new ArgumentOutOfRangeException("Illegal type of Session"); }

                _isIntensive = value;
            }
        }


        public Session(int hours, int minutes, int seconds,bool isIntensive)  
        {
            Hours = hours;
            Minutes = minutes;
            Seconds = seconds;
            IsIntensive = isIntensive;
        }

        //per il controllo dei test sovrascrivo il metodo Equal

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;

            if (!(obj is Session)) return false;

            Session session = obj as Session;

            if (Hours == session.Hours && Minutes == session.Minutes && Seconds == session.Seconds && IsIntensive == session.IsIntensive) return true;
            return false;
        }

    }
}
