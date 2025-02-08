using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace TimeManagement
{
    public class Calendar
    {
        private int _day,_month,_year;


        public int Year
        {
            get
            {
                return _year;
            }
            private set
            {
                if (value < 0)
                { throw new ArgumentOutOfRangeException("illegal year"); }
                _year = value;
            }
        }

        public int Month
        {
            get 
            {
                return _month;
            }
            private set
            {
                if (value < 1 || value > 12)
                { throw new ArgumentOutOfRangeException("illegal month"); }
                _month = value;
            }

        }
        public int Day 
        {
            get 
            {
                return _day;
            }
            private set
            {
                if (value < 0 || value > 31)
                {
                    throw new ArgumentOutOfRangeException("illegal day");
                }
                else if (value == 31 && !IsA31DaysMonth())
                {
                    throw new ArgumentOutOfRangeException("illegal day");
                }
                else if (value == 29 && Month == 2 && IsLeapYear()==false)
                {
                    throw new ArgumentOutOfRangeException("illegal day");
                }else
                    _day = value;
            }
        }  

        //to do :spostare i controlli nelle proprietà
        public Calendar(int day, int month, int year)
        {
            Year = year;
            Month = month;
            Day = day; 
        }

        public bool IsLeapYear()
        {
           if(Year % 100 != 0 && Year % 4 == 0) return true;
           if(Year % 100 == 0 && Year % 400 == 0) return true; 
           return false;
        }

        private bool IsA31DaysMonth()
        {
            if(Month == 1 || Month == 3 || Month == 5 || Month == 7 || Month == 8 || Month == 10 || Month == 12) 
                return true;
            return false;
        }

        public string ReturnMonthName(int monthNumber) 
        {
            if(monthNumber<0 || monthNumber > 12) { throw new ArgumentOutOfRangeException("illegal monthNumber"); }

            switch (monthNumber) 
            {
                case 1: return "January";
                case 2: return "February";
                case 3: return "March";
                case 4: return "April";
                case 5: return "May";
                case 6: return "June";
                case 7: return "July";
                case 8: return "August";
                case 9: return "September";
                case 10: return "October";
                case 11: return "November";
                default: return "December";
                break;
            }

        }

        public void AddYear(int yearToAdd) 
        {

            Year += yearToAdd;

        }

        public void AddMonth(int monthToAdd) 
        {
            if (Month + monthToAdd > 12) 
            {
                Month = (monthToAdd+monthToAdd)%12;
                AddYear(1);
            }else if(Month + monthToAdd < 1)
            {
                Month = Math.Abs(12 + (Month + Month));
                AddYear(-1);
            }else
            {
                Month += monthToAdd;
            }

        }

        public void AddDay(int dayToAdd)
        {

            if (Day + dayToAdd > 31 && IsA31DaysMonth())
            {
                Day = (Day + dayToAdd) % 31;
                AddMonth(1);
            }
            else if (Day + dayToAdd > 31 && !IsA31DaysMonth())
            {
                Day = (Day + dayToAdd) % 30;
                AddMonth(1);
            }
            else if (Day + dayToAdd > 28 && Month == 2 && IsLeapYear() == false)
            {
                Day = (Day + dayToAdd) % 28;
                AddMonth(1);
            }
            else if (Day + dayToAdd > 28 && Month == 2 && IsLeapYear() == true)
            {
                Day = (Day + dayToAdd) % 29;
            }
            else if (Day + dayToAdd < 0 && IsA31DaysMonth())
            {
                Day = Math.Abs(31 + (Day + dayToAdd));
                AddMonth(-1);
            }
            else if (Day + dayToAdd < 0 && !IsA31DaysMonth())
            {
                Day = Math.Abs(30 + (Day + dayToAdd));
                AddMonth(-1);
            }
            else if (Day + dayToAdd < 0 && Month == 2 && IsLeapYear() == false)
            {
                Day = Math.Abs(28 + (Day + dayToAdd));
                AddMonth(-1);
            }
            else if (Day + dayToAdd < 0 && Month == 2 && IsLeapYear() == true)
            {
                Day = Math.Abs(29 + (Day + dayToAdd));
                AddMonth(-1);
            }
            else
            {
                Day += dayToAdd;
            }
        }


        public override string ToString()
        {
            return ($"{Day}/{Month}/{Year}");
        }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (!(obj is Calendar)) return false;
                   
            Calendar calendar = obj as Calendar;

            if (calendar.Day == Day && calendar.Month == Month && calendar.Year == Year)
                return true;
            return false;

        }


    }


    }
}
