using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TimeManagement;
using static System.Net.Mime.MediaTypeNames;

namespace TestTimeManagement
{
    public class DateAndTime
    {

        public Date myDate 
        { get; private set; }

        public Time myTime 
        { get; private set; }

     


        public DateAndTime(int day, int month, int year, int hour=0, int minutes=0) 
        {

            Date calendar = new Date(day, month, year);
            Time hours = new Time(hour, minutes);

            myDate = calendar;
            myTime = hours;
        }


        public void AddDays(int daysToAdd) 
        {
            myDate.AddDay(daysToAdd);
        }

        public void addMonths(int monthsToAdd)
        {
            myDate.AddMonth(monthsToAdd);
        }

        public void addYears(int yearsToAdd) 
        {
            myDate.AddYear(yearsToAdd);
        }

        public void AddHours(int hoursToAdd)
        {

           int days = (hoursToAdd+myTime.Hour) / 24;

           myTime.AddHours(hoursToAdd);
           myDate.AddDay(days);
        }

        public void AddMinutes(int minutesToAdd) 
        {
            int hours = (minutesToAdd + myTime.Hour) / 60;

            myTime.AddMinutes(minutesToAdd);
            AddHours(hours);
        }
        /// <summary>
        /// restituisce true se questo oggetto è minore (precedente) al parametro time; false altrimenti
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public bool IsBefore(DateAndTime time)
        {
            if ((myDate.Year < time.myDate.Year) ||
               (myDate.Year == time.myDate.Year && myDate.Month < time.myDate.Month)  || 
               (myDate.Year == time.myDate.Year && myDate.Month == time.myDate.Month && myDate.Day < time.myDate.Day )|| 
               (myDate.Equals(time.myDate) && myTime.Hour<time.myTime.Hour )||
               (myDate.Equals(time.myDate) && myTime.Hour == time.myTime.Hour && myTime.Minutes < time.myTime.Minutes ))
                return true; 
            return false;
        }

        /// <summary>
        /// calcolare i minuti che intercorrono tra la mia data-ora e quella di time
        /// devo poter caloclare anche differenze negative!
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public int MinutesBetween(DateAndTime time)
        {
            
            //calcolo dei minuti
            //devo fare la differenza tra ore minuti e secondi ma anche tra giorni mesi e anni
            //@TODO
            return 0;

        }

        public override string ToString()
        {
            return myDate.ToString() + " . " +myTime.ToString() ;
        }
        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (!(obj is DateAndTime)) return false;
            DateAndTime hourCalendar = obj as DateAndTime;
            if (myDate.Equals(hourCalendar.myDate) && myTime.Equals(hourCalendar.myTime)) return true;
            return false;
        }


    }
}
