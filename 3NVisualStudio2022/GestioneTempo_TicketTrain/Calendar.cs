using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeManagement
{
    public class Calendar
    {
        public int Day { get; private set; }  
        public int Month { get; private set; }
        public int Year { get; private set; }

        //to do :spostare i controlli nelle proprietà
        public Calendar(int day, int month, int year) 
        {
            if (day < 0 || day > 365 || (day == 366 && year % 4 != 0))
            { throw new ArgumentOutOfRangeException("illegal day"); }

            if (month < 1 || month > 12)
            { throw new ArgumentOutOfRangeException("illegal month"); }

            if(year<0)
            { throw new ArgumentOutOfRangeException("illegal year");}

            Day = day;
            Month = month;
            Year = year;

        }

    }
}
