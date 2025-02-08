using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeManagement
{
    public class Hours
    {

        public int Hour { get; private set; }
        public int Minutes {  get; private set; }

        //to do :spostare i controlli nelle proprietà
        public Hours(int hour, int minutes) 
        {
            if (hour < 0 || hour > 24) 
            { throw new ArgumentOutOfRangeException("illegal hour"); }

            if (minutes<0 || minutes>60)
            { throw new ArgumentOutOfRangeException("illegal minutes"); }

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
            Hour += hourToAdd;

            if (Hour > 24)
                Hour -= 24;
            else if (Hour < 0)
                Hour = 24 - Hour;
        }

        public void AddMinutes(int minutesToAdd)
        {
            Minutes += minutesToAdd;

            if(Minutes > 60) 
            {
                Minutes -= 60;
                Hour++;
            }else if (Minutes < 0)
            {
                Minutes = 60-Minutes;
                Hour--;
            }

        }

        public override string ToString()
        {
            return ($"${Hour}:${Minutes}");
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
