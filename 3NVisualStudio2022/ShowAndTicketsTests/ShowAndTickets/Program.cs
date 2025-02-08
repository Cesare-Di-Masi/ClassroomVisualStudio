using System.Net.Sockets;
using ShowsTicketsLib;
class program
{
    static void Main(string[] args)
    {

        DateTime dateTime = DateTime.Now;
        Ticket[] ticketList = new Ticket[10];
        int[] wantedTicket = new int[2] { 3, 5 };
        Show show = new Show("Game", dateTime, 1, ticketList);
        show.sellTicket(wantedTicket);
    }
}
