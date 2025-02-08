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

            DateAndTime testhourCalendar = new DateAndTime(1,1,1,12,0);
            testhourCalendar.AddHours(10);
            int expected = 22;
            int actual = testhourCalendar.myTime.Hour;
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void AddHour_WithValidHour_IsCorrectOutDayNext()
        {

            DateAndTime testhourCalendar = new DateAndTime(1, 1, 1, 12, 0);
            testhourCalendar.AddHours(14);
            int expected = 2;
            int actual = testhourCalendar.myTime.Hour;
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void AddHour_WithValidHour_IsCorrectOutDayBefore()
        {

            DateAndTime testhourCalendar = new DateAndTime(1, 1, 1, 12, 0);
            testhourCalendar.AddHours(-14);
            int expected = 22;
            int actual = testhourCalendar.myTime.Hour;
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void AddMinutes_WithValidMinute_IsCorrectNextDay()
        {
            DateAndTime testhourCalendar = new DateAndTime(1, 1, 1, 23, 30);
            testhourCalendar.AddMinutes(32);
            int expectedMinutes = 2;
            int actualMinutes = testhourCalendar.myTime.Hour;
            int expectedHours = 0;
            int actualHours = testhourCalendar.myTime.Hour;
            int expectedDays = 2;
            int actualDays = testhourCalendar.myDate.Day;
            Assert.AreEqual(expectedMinutes, actualMinutes);
            Assert.AreEqual(expectedHours, actualHours);
            Assert.AreEqual(expectedDays, actualDays);
        }

        [TestMethod]
        public void AddMinutes_WithValidMinute_IsCorrectBeforeDay()
        {
            DateAndTime testhourCalendar = new DateAndTime(2, 1, 1, 0, 30);
            testhourCalendar.AddMinutes(-32);
            int expectedMinutes = 58;
            int actualMinutes = testhourCalendar.myTime.Hour;
            int expectedHours = 23;
            int actualHours = testhourCalendar.myTime.Hour;
            int expectedDays = 1;
            int actualDays = testhourCalendar.myDate.Day;
            Assert.AreEqual(expectedMinutes, actualMinutes);
            Assert.AreEqual(expectedHours, actualHours);
            Assert.AreEqual(expectedDays, actualDays);
        }

        [TestMethod]
        public void isAfter_WithValidValues_IsCorrect()
        {
            DateAndTime testhourCalendar = new DateAndTime(23, 9, 2008, 12, 30);
            DateAndTime testhourCalendarAfter = new DateAndTime(12, 10, 2008, 13, 31);
            DateAndTime testhourCalendarBefore = new DateAndTime(30, 7, 2007, 18, 50);

            Assert.AreEqual(true, testhourCalendar.IsBefore(testhourCalendarAfter));
            Assert.AreEqual(false, testhourCalendar.IsBefore(testhourCalendarBefore));
        }

        [TestMethod]
        public void ToString_WithValidValues_IsCorrect()
        {
            DateAndTime testhourCalendar = new DateAndTime(23, 9, 2008, 12, 30);
            string expected = "23/9/2008 . 12:30";
            string actual = testhourCalendar.ToString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Equal_WithValidValues_IsCorrectTrue()
        {
            DateAndTime testhourCalendar1 = new DateAndTime(23, 9, 2008, 12, 30);
            DateAndTime testhourCalendar2 = new DateAndTime(23, 9, 2008, 12, 30);
            bool expected = true;
            bool actual = testhourCalendar1.Equals(testhourCalendar2);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Equal_WithValidValues_IsCorrectFalse()
        {
            DateAndTime testhourCalendar1 = new DateAndTime(23, 9, 2008, 12, 30);
            DateAndTime testhourCalendar2 = new DateAndTime(24, 10, 2008, 11, 30);
            bool expected = false;
            bool actual = testhourCalendar1.Equals(testhourCalendar2);
            Assert.AreEqual(expected, actual);
        }

    }
}
