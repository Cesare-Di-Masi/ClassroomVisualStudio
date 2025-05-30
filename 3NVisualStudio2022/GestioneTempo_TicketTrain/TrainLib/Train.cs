﻿using System;
namespace TrainLib
{
    public class Train
    {
        private int _trainNumber;
        private string _startStation, _endStation;
        private DateTime _expectedStart, _expectedEnd;
        private DateTime? _actualStart, _actualEnd;

        public int TrainNumber
        {
            get { return _trainNumber; }

            private set
            {
                if (value < 0) throw new ArgumentOutOfRangeException("Illegal train number");
                _trainNumber = value;
            }
        }

        public string StartStation
        {
            get { return _startStation; }

            private set
            {
                if (String.IsNullOrWhiteSpace(value)) throw new ArgumentNullException("illegal start Station name");
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

        public DateTime ExpectedStart
        {
            get;

            private set;
        }

        public DateTime ExpectedEnd
        {
            get { return _expectedEnd; }

            private set
            {
                if (DateTime.Compare(value, ExpectedStart) <= 0 )
                    throw new ArgumentOutOfRangeException("illegal expected end");

                _expectedEnd = value;
            }
        }

        public DateTime? ActualStart
        {
            get { return _actualStart; }

            set
            {
                if (value != null && DateTime.Compare((DateTime)value, ExpectedStart) < 0)

                    throw new ArgumentOutOfRangeException("illegal start");
                _actualStart = value;
            }
        }

        public DateTime? ActualEnd
        {
            get { return _actualEnd; }

            private set
            {
                if (value is not null && ActualStart is not null)
                {
                   
                    if (DateTime.Compare((DateTime)value, (DateTime)ActualStart) <= 0)
                    throw new ArgumentOutOfRangeException("illegal actual end");
                }
                _actualEnd = value;
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
                _isDelayed = DelayInMinutes.Minutes > 0 ? true : false;
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
                _isCanceled = DelayInMinutes.Minutes > 240 ? true : false;
            }
        }

        public Train(int trainNumber, string startStation, string endStation, DateTime exStart, DateTime exEnd, DateTime? acStart = null, DateTime? acEnd = null)
        {
            TrainNumber = trainNumber;
            StartStation = startStation;
            EndStation = endStation;
            ExpectedStart = exStart;
            ExpectedEnd = exEnd;
            ActualStart = acStart;
            ActualEnd = acEnd;
        }

        public TimeSpan DelayInMinutes
        {
            get 
            {
                if (ActualEnd == null )
                {
                    throw new InvalidOperationException();
                }
                    return (DateTime)ActualEnd - ExpectedEnd; 
            }   
        }

        public TimeSpan ActualDurationInMinutes
        {
            get
            {
                if (ActualEnd == null || ActualStart == null) { throw new InvalidOperationException(); }
                return (DateTime)ActualEnd - (DateTime)ActualStart;
            }
        }

        public TimeSpan ExpectedDuration
        {
            get { return ExpectedEnd - ExpectedStart; }
        }
    }
}