using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ShowsTicketsLib;
namespace TestShowTicket
{
    [TestClass]
    public class TestShow
    {
        [TestMethod]
        public void Show_WithInvalidName_ShouldThrow()
        {
            DateTime dateTime = DateTime.Now;
            Ticket[] ticketList = new Ticket[10];
            Assert.ThrowsException<ArgumentNullException>(() => { Show show = new Show("", dateTime, 1, ticketList ); });
        }

        [TestMethod]
        public void Show_WithInvalidCost_ShouldThrow()
        {
            DateTime dateTime = DateTime.Now;
            Ticket[] ticketList = new Ticket[10];
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => { Show show = new Show("Game", dateTime, -1, ticketList); });
        }

        [TestMethod]
        public void sellTicket_Sell1RandomTicket_IsCorrect()
        {
            DateTime dateTime = DateTime.Now;
            Ticket[] ticketList = new Ticket[10];
            Show show = new Show("Game", dateTime, 1, ticketList);
            show.sellTicket();
            Assert.AreEqual(true, show.TicketList[0].IsSold);
        }

        [TestMethod]
        public void sellTicket_SellSelectedTicket_IsCorrect()
        {
            DateTime dateTime = DateTime.Now;
            Ticket[] ticketList = new Ticket[10];
            Show show = new Show("Game", dateTime, 1, ticketList);
            show.sellTicket(3);
            Assert.AreEqual(true, show.TicketList[2].IsSold);
        }

        [TestMethod]
        public void sellTicket_SellMultipleSelectedTicket_IsCorrect()
        {
            DateTime dateTime = DateTime.Now;
            Ticket[] ticketList = new Ticket[10];
            int[] wantedTicket = new int[2] {3,5 };
            Show show = new Show("Game", dateTime, 1, ticketList);
            show.sellTicket(wantedTicket);
            Assert.AreEqual(true, show.TicketList[2].IsSold);
            Assert.AreEqual(true, show.TicketList[4].IsSold);
        }

        [TestMethod]
        public void sellTicket_SellMultipleRandomTicket_IsCorrect()
        {
            DateTime dateTime = DateTime.Now;
            Ticket[] ticketList = new Ticket[10];
            int[] wantedTicket = new int[2] { 3, 5 };
            Show show = new Show("Game", dateTime, 1, ticketList);
            show.sellTicket(2);
            show.sellMoreTicket(3);
            Assert.AreEqual(true, show.TicketList[0].IsSold);
            Assert.AreEqual(true, show.TicketList[2].IsSold);
            Assert.AreEqual(true, show.TicketList[3].IsSold);
        }

    }
}
