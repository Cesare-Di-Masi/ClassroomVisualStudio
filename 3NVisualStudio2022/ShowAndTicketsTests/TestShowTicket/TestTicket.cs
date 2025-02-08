using ShowsTicketsLib;
namespace TestShowTicket
{
    [TestClass]
    public class TestTicket
    {
        [TestMethod]
        public void Ticket_WithInvalidCost_ShouldThrow()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => { Ticket ticket = new Ticket(-1, 1, false); });
        }

        [TestMethod]
        public void Ticket_WithInvalidSeat_ShouldThrow()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => { Ticket ticket = new Ticket(1, -1, false); });
        }

        
    }
}