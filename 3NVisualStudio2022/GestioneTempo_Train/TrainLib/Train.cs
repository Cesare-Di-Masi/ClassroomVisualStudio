using TestTimeManagement;
using TimeManagement;
namespace TrainLib
{
    public class Train
    {
        private int _trainNumber;
        private string _startStation, _endStation;
        private HoursCalendar _exStart, _exEnd, acStart, acEnd;

        public int TrainNumber
        {
            get { return _trainNumber; }

            private set 
            {
                if(value < 0 ) throw new ArgumentOutOfRangeException("Illegal train number");
                _trainNumber = value; 
            }
        }

        public string StartStation
        {
            get { return _startStation; }

            private set 
            {
                if(String.IsNullOrWhiteSpace(value) ) throw new ArgumentNullException("illegal start Station name");
                _startStation = value.ToLower();
            }
        }

        public string EndStation
        {
            get { return _endStation; }

            private set
            {
                if (String.IsNullOrWhiteSpace(value)) throw new ArgumentNullException("illegal end Station name");
                _endStation = value.ToLower();
            }
        }

        public HoursCalendar ExStart
        {
            get;

            private set;
        }

        public HoursCalendar ExEnd
        {
            get { return _exEnd; }

            private set 
            {
                if(value.Calendar.Year < ExStart.Calendar.Year || value.Calendar.Month < ExStart.Calendar.Month || (value.Calendar.Day < ExStart.Calendar.Day && value.Calendar.Month == ExStart.Calendar.Month)
                  (value.Hour.Hour < ExStart.Hour.Hour && value.Calendar.Day == ExStart.Calendar.Day) || (value.Hour.Minutes < ExStart.Hour.Minutes && value.Hour.Hour == ExStart.Hour.Hour) )
            }
        }


        public Train(int trainNumber, string startStation, string endStation, HoursCalendar exStart, HoursCalendar exEnd, HoursCalendar acStart, HoursCalendar acEnd ) 
        {




        }



    }
}
