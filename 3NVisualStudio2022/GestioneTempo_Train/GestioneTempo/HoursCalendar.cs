using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TimeManagement;

namespace TestTimeManagement
{
    public class HoursCalendar
    {

        public Calendars Calendar 
        { get; private set; }

        public Hours Hour 
        { get; private set; }

     


        public HoursCalendar(int day, int month, int year, int hour=0, int minutes=0) 
        {

            Calendars calendar = new Calendars(day, month, year);
            Hours hours = new Hours(hour, minutes);

            Calendar = calendar;
            Hour = hours;
        }


        public void AddDays(int daysToAdd) 
        {
            Calendar.AddDay(daysToAdd);
        }

        public void addMonths(int monthsToAdd)
        {
            Calendar.AddMonth(monthsToAdd);
        }

        public void addYears(int yearsToAdd) 
        {
            Calendar.AddYear(yearsToAdd);
        }

        public void AddHours(int hoursToAdd)
        {

           int days = (hoursToAdd+Hour.Hour) / 24;

           Hour.AddHours(hoursToAdd);
           Calendar.AddDay(days);
        }

        public void AddMinutes(int minutesToAdd) 
        {
            int hours = (minutesToAdd + Hour.Hour) / 60;

            Hour.AddMinutes(minutesToAdd);
            AddHours(hours);
        }

        public override string ToString()
        {
            return Calendar.ToString() + " . " +Hour.ToString() ;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (!(obj is HoursCalendar)) return false;

            HoursCalendar hourCalendar = obj as HoursCalendar;

            if (Calendar.Equals(hourCalendar.Calendar) && Hour.Equals(hourCalendar.Hour)) return true;
            return false;

        }


    }
}
