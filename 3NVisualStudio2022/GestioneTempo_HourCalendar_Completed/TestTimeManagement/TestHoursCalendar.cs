using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeManagement;

namespace TestTimeManagement
{
    [TestClass]
    public class TestHoursCalendar
    {

        [TestMethod]
        public void AddHour_WithValidHour_IsCorrectInDay()
        {

            HoursCalendar testhourCalendar = new HoursCalendar(1,1,1,12,0);
            testhourCalendar.AddHours(10);
            int expected = 22;
            int actual = testhourCalendar.Hour.Hour;
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void AddHour_WithValidHour_IsCorrectOutDayNext()
        {

            HoursCalendar testhourCalendar = new HoursCalendar(1, 1, 1, 12, 0);
            testhourCalendar.AddHours(14);
            int expected = 2;
            int actual = testhourCalendar.Hour.Hour;
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void AddHour_WithValidHour_IsCorrectOutDayBefore()
        {

            HoursCalendar testhourCalendar = new HoursCalendar(1, 1, 1, 12, 0);
            testhourCalendar.AddHours(-14);
            int expected = 22;
            int actual = testhourCalendar.Hour.Hour;
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void AddMinutes_WithValidMinute_IsCorrectNextDay()
        {
            HoursCalendar testhourCalendar = new HoursCalendar(1, 1, 1, 23, 30);
            testhourCalendar.AddMinutes(32);
            int expectedMinutes = 2;
            int actualMinutes = testhourCalendar.Hour.Hour;
            int expectedHours = 0;
            int actualHours = testhourCalendar.Hour.Hour;
            int expectedDays = 2;
            int actualDays = testhourCalendar.Calendar.Day;
            Assert.AreEqual(expectedMinutes, actualMinutes);
            Assert.AreEqual(expectedHours, actualHours);
            Assert.AreEqual(expectedDays, actualDays);
        }

        [TestMethod]
        public void AddMinutes_WithValidMinute_IsCorrectBeforeDay()
        {
            HoursCalendar testhourCalendar = new HoursCalendar(2, 1, 1, 0, 30);
            testhourCalendar.AddMinutes(-32);
            int expectedMinutes = 58;
            int actualMinutes = testhourCalendar.Hour.Hour;
            int expectedHours = 23;
            int actualHours = testhourCalendar.Hour.Hour;
            int expectedDays = 1;
            int actualDays = testhourCalendar.Calendar.Day;
            Assert.AreEqual(expectedMinutes, actualMinutes);
            Assert.AreEqual(expectedHours, actualHours);
            Assert.AreEqual(expectedDays, actualDays);
        }

        [TestMethod]
        public void ToString_WithValidValues_IsCorrect()
        {
            HoursCalendar testhourCalendar = new HoursCalendar(23, 9, 2008, 12, 30);
            string expected = "23/9/2008 . 12:30";
            string actual = testhourCalendar.ToString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Equal_WithValidValues_IsCorrectTrue()
        {
            HoursCalendar testhourCalendar1 = new HoursCalendar(23, 9, 2008, 12, 30);
            HoursCalendar testhourCalendar2 = new HoursCalendar(23, 9, 2008, 12, 30);
            bool expected = true;
            bool actual = testhourCalendar1.Equals(testhourCalendar2);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Equal_WithValidValues_IsCorrectFalse()
        {
            HoursCalendar testhourCalendar1 = new HoursCalendar(23, 9, 2008, 12, 30);
            HoursCalendar testhourCalendar2 = new HoursCalendar(24, 10, 2008, 11, 30);
            bool expected = false;
            bool actual = testhourCalendar1.Equals(testhourCalendar2);
            Assert.AreEqual(expected, actual);
        }

    }
}
