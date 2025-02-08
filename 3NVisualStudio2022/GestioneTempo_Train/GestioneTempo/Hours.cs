using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeManagement
{
    public class Hours
    {
        private int _hour;
        private int _minute;

        public int Hour 
        {
            get
            { 
                return _hour;
            }
            private set
            {
                if (value < 0 || value>24)
                { throw new ArgumentOutOfRangeException("illegal hour"); }
                _hour = value;
            }
        }
        public int Minutes 
        {  
            get
            {
            return _minute; 
            }
            private set
            {
                if (value < 0 || value > 60)
                { throw new ArgumentOutOfRangeException("illegal minutes"); }
                _minute = value;
            }
        }

        //to do :spostare i controlli nelle proprietà
        public Hours(int hour, int minutes) 
        {   
            Hour = hour;
            Minutes = minutes;
        }

        public bool IsAm() 
        {
            if (Hour < 12)
                return true;
            else
                return false;
        }

        public void AddHours(int hourToAdd) 
        {

            if (Hour + hourToAdd > 24)
                Hour = (Hour + hourToAdd) % 24;
            else if (Hour + hourToAdd < 0)
                Hour = Math.Abs(24 + (Hour + hourToAdd)) ;
            else
                Hour += hourToAdd;
        }

        public void AddMinutes(int minutesToAdd)
        {

            if (Minutes + minutesToAdd > 60)
            {
                int hoursToAdd = (Minutes + minutesToAdd) / 60 ;
                AddHours(hoursToAdd);
                Minutes = (Minutes + minutesToAdd) % 60;
            }
            else if (Hour + minutesToAdd < 0)
            {
                int hoursToRemove = (Minutes + minutesToAdd) / 60 + 1 ;
                AddHours(-hoursToRemove);
                Minutes = Math.Abs(60 + (Minutes + minutesToAdd));
            }
            else
                Minutes += minutesToAdd;

        }

        public override string ToString()
        {
            return ($"{Hour}:{Minutes}");
        }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;

            if (!(obj is Hours)) return true;

            Hours hours = obj as Hours;

            if (Hour == hours.Hour && Minutes == hours.Minutes) return true;
            return false;
        }

    }
}
