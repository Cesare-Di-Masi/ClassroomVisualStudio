using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowsTicketsLib
{
    public class Show
    {
        private string _title;

        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                if(String.IsNullOrEmpty(value)) throw new ArgumentNullException("Illegal title");
                _title = value;
            }
        }

        public DateTime Date
        {
            get; private set;
        }

        public int Cost
        {
            get; private set;
        }

        public Ticket[] TicketList
        {
            get; private set;
        }

        public Show(string title, DateTime date, int cost ,Ticket[] ticketList) 
        {
            Ticket[] list = new Ticket[ticketList.Length];
            Title = title;
            Date = date;
            Cost = cost;

            for (int i = 0; i < list.Length; i++)
            {
                list[i] = new Ticket(cost, i + 1, false);
            }

            TicketList = list;
        }

        public void sellTicket()
        {
            bool isSellable = false;
            int counter = 0;

            while (isSellable == false)
            {
                if (counter != TicketList.Length)
                {
                    if (TicketList[counter].IsSold == false)
                    {
                        TicketList[counter].IsSold = true;
                        isSellable = true;
                    }
                    else
                    {
                        counter++;
                    }
                }
                else
                {
                    throw new ArgumentException("no tickets left, sold out");
                }
            }
        }

        public void sellTicket(int seatNumber)
        {
            if (seatNumber <= 0 || seatNumber > TicketList.Length || TicketList[seatNumber - 1].IsSold == true) throw new ArgumentOutOfRangeException("illegal wanted seat");

            TicketList[seatNumber-1].IsSold = true;

        }

        public void sellTicket(int[] seatList)
        {
            for (int i = 0; i < seatList.Length; i++)
            {
                if (seatList[i] <= 0 || seatList[i] > TicketList.Length || TicketList[seatList[i]-1].IsSold == true) throw new ArgumentOutOfRangeException("illegal wanted seat");
            }

            for(int i = 0;i < TicketList.Length; i++)
            {
                TicketList[seatList[i]-1].IsSold=true;
            }

        }

        public void sellMoreTicket(int nTickets)
        {
            if(nTickets < 1  || nTickets > TicketList.Length) throw new ArgumentOutOfRangeException("Illega ticket number");
            for (int i = 0; i < nTickets; i++)
            {
                sellTicket();
            }
        }



    }
}
