using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using TrainLib;
class TestClass
{
    static void Main(string[] args)
    {
        Train t1 = new Train(9806, "Milano", "Roma", new DateTime(2020, 1, 1, 10, 0, 0), new DateTime(2020, 1, 1, 12, 0, 0));
        Train t2 = new Train(9808, "Roma", "Milano", new DateTime(2020, 1, 1, 12, 0, 0), new DateTime(2020, 1, 1, 14, 0, 0));
        Ticket ticket = new Ticket(9806);
        ticket.ValidateTicket(new DateTime(2020, 1, 1, 9, 11, 0));
        Console.WriteLine(ticket.IsTicketStillValid(new DateTime(2020, 1, 1, 9, 13, 0)));
        Console.WriteLine(ticket.IsTicketStillValid(new DateTime(2020, 1, 1, 10, 15, 0)));
        Console.WriteLine(ticket.IsTicketStillValid(new DateTime(2020, 1, 1, 12, 10, 0)));
        Console.WriteLine(ticket.IsTicketStillValid(new DateTime(2020, 1, 1, 14, 11, 0)));


    }
}
