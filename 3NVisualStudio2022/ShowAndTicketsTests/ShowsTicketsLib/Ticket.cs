namespace ShowsTicketsLib
{
    public class Ticket
    {
        private int _cost, _seat;
        public int Cost
        {
            get
            {
            return _cost; 
            }
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException("illegal ticket's cost");
                _cost = value;
            }
        }

        public int Seat
        {
            get
            {
                return _seat;
            }
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException("illegal ticket's seat");
                _seat = value;
            }
        }

        public bool IsSold
        {
            get; set;
        }

        public Ticket(int cost, int seat, bool isSold) 
        {
            Cost = cost;
            Seat = seat;
            IsSold = isSold;
        }

    }
}
