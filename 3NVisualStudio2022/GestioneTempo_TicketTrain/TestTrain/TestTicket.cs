using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTimeManagement;
using TimeManagement;
using TrainLib;

namespace TestTrain
{
    [TestClass]
    public class TestTicket
    {
        [TestMethod]
        public void Ticket_WithInvalidTicketTrainNumber_ShouldThrow()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => { Ticket test = new Ticket(-1); });
        }

        [TestMethod]
        public void ValidateTicket_WithValidValues_UpdateValidateTime()
        {
            Ticket test = new Ticket(1);
            DateAndTime time = new DateAndTime(23, 9, 2008, 12, 30);
            test.ValidateTicket(time);
            Assert.AreEqual(time, test.ValidateTime);
        }
    }
}