using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeManagement;

namespace TestTimeManagement
{
    [TestClass]
    public class TestCalendar
    {

        [TestMethod]
        public void Calendar_WithInvalidYear_ShouldThrow()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => { Calendar calendar = new Calendar(10, 10, -1); });
        }

        [TestMethod]
        public void Calendar_WithInvalidMonth_ShouldThrowNegative()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => { Calendar calendar = new Calendar(10, -1, 2024); });
        }

        [TestMethod]
        public void Calendar_WithInvalidMonth_ShouldThrowBigger()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => { Calendar calendar = new Calendar(10, 13, 2024); });
        }

        [TestMethod]
        public void Calendar_WithInvalidDay_ShouldThrowNegative()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => { Calendar calendar = new Calendar(-1, 10, 2024); });
        }

        [TestMethod]
        public void Calendar_WithInvalidDay_ShouldThrowBigger()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => { Calendar calendar = new Calendar(32, 10, 2024); });
        }

        [TestMethod]
        public void Calendar_WithInvalidDay_ShouldThrow31WhenNot31DaysMonth()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => { Calendar calendar = new Calendar(31, 4, 2024); });
        }

        [TestMethod]
        public void Calendar_WithInvalidDay_ShouldThrow29WhenNotLeapYear()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => { Calendar calendar = new Calendar(29, 2, 2023); });
        }


    }
}
