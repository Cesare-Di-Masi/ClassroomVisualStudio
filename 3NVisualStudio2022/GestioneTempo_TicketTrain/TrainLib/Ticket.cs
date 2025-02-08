using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainLib;

namespace TrainLib
{
    public class Ticket
    {
        private int _trainNumber;

        public int TicketTrainNumber
        {
            get
            {
                return _trainNumber;
            }

            private set
            {
                if (value < 0) throw new ArgumentOutOfRangeException("illegal ticket number");
                _trainNumber = value;
            }
        }

        public DateTime? ValidateTime
        {
            get;
            private set;
        }

        public Ticket(int trainNumber, DateTime? validateTime = null)
        {
            TicketTrainNumber = trainNumber;
            ValidateTime = validateTime;
        }

        public void ValidateTicket(DateTime time)
        {
            if (ValidateTime == null)
            {
                ValidateTime = time;
            }
            else
            {
                throw new InvalidOperationException("biglietto già convalidato");
            }
        }

        public bool IsTicketStillValid(DateTime time)
        {
            if (DateTime.Compare(time,(DateTime)ValidateTime) < 0) throw new ArgumentOutOfRangeException("");

            TimeSpan span = (DateTime)ValidateTime - time;
            if (ValidateTime == null) return true;
            if (span.Minutes <= 180) return true;
            return false;
        }

        public bool isTicketFoATrain(int trainNumber)
        {
            return TicketTrainNumber == trainNumber;
        }

        public override bool Equals(object? obj)
        {
            if (!(obj is Ticket)) return false;

            Ticket ticket = obj as Ticket;

            if (TicketTrainNumber == ticket.TicketTrainNumber && ValidateTime.Equals(ticket.ValidateTime)) return true;
            return false;
        }
    }
}