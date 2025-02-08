using TestTimeManagement;
using TimeManagement;
namespace TrainLib
{
    public class Train
    {
        private int _trainNumber;
        private string _startStation, _endStation;
        private HoursCalendar _exStart, _exEnd, _acStart, _acEnd;
        
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
                if (value.Calendar.Year < ExStart.Calendar.Year ||(value.Calendar.Year == ExStart.Calendar.Year &&(value.Calendar.Month < ExStart.Calendar.Month ||(value.Calendar.Month == ExStart.Calendar.Month &&
                   (value.Calendar.Day < ExStart.Calendar.Day ||(value.Calendar.Day == ExStart.Calendar.Day &&(value.Hour.Hour < ExStart.Hour.Hour ||(value.Hour.Hour == ExStart.Hour.Hour &&value.Hour.Minutes < ExStart.Hour.Minutes))))))))
                {
                    throw new ArgumentOutOfRangeException("illegal expected end");
                }
                _exStart = value;
            }
        }

        public HoursCalendar AcStart
        { 
            get; 
            
            private set; 
        }

        public HoursCalendar AcEnd
        {
            get { return _acStart; }

            private set 
            {
                if (value.Calendar.Year < AcStart.Calendar.Year || (value.Calendar.Year == AcStart.Calendar.Year && (value.Calendar.Month < AcStart.Calendar.Month || (value.Calendar.Month == AcStart.Calendar.Month &&
                   (value.Calendar.Day < AcStart.Calendar.Day || (value.Calendar.Day == AcStart.Calendar.Day && (value.Hour.Hour < AcStart.Hour.Hour || (value.Hour.Hour == AcStart.Hour.Hour && value.Hour.Minutes < AcStart.Hour.Minutes))))))))
                {
                    throw new ArgumentOutOfRangeException("illegal actual end");
                }
            }
        }

        private bool _isDelayed;

        public bool IsDelayed
        {
            get 
            {
                return _isDelayed;
            }
            private set
            {
                _isDelayed = delayInMinutes() > 0 ? true : false; 
            }
        }

        private bool _isCanceled;

        public bool IsCancelled    
        {
            get
            {
                return _isCanceled;
            }
            private set 
            {

                _isCanceled = delayInMinutes() > 240 ?   true : false;
            } 
        }


        public Train(int trainNumber, string startStation, string endStation, HoursCalendar exStart, HoursCalendar exEnd, HoursCalendar acStart, HoursCalendar acEnd ) 
        {
            TrainNumber = trainNumber;
            StartStation = startStation;
            EndStation = endStation;
            ExStart = exStart;
            ExEnd = exEnd;
            AcStart = acStart;
            AcEnd = acEnd;

        }

        public int delayInMinutes()
        {
            return (AcEnd.Hour.Hour-ExEnd.Hour.Hour)*60+AcEnd.Hour.Minutes-ExEnd.Hour.Minutes;
        }


        private HoursCalendar calculateDuration(HoursCalendar end, HoursCalendar start)
        {

            HoursCalendar duration = new HoursCalendar(end.Calendar.Day - start.Calendar.Day, end.Calendar.Month - start.Calendar.Month, start.Calendar.Year - end.Calendar.Year, end.Hour.Hour - start.Hour.Hour, end.Hour.Minutes - start.Hour.Minutes);

            return duration;
        }

        public HoursCalendar exDuration()
        {
            return calculateDuration(ExEnd, ExStart);
        }

        public HoursCalendar acDuration() 
        {
            return calculateDuration(AcStart, AcEnd);
        }

        
        

    }
}
