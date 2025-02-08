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
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => { Date calendar = new Date(10, 10, -1); });
        }

        [TestMethod]
        public void Calendar_WithInvalidMonth_ShouldThrowNegative()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => { Date calendar = new Date(10, -1, 2024); });
        }

        [TestMethod]
        public void Calendar_WithInvalidMonth_ShouldThrowBigger()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => { Date calendar = new Date(10, 13, 2024); });
        }

        [TestMethod]
        public void Calendar_WithInvalidDay_ShouldThrowNegative()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => { Date calendar = new Date(-1, 10, 2024); });
        }

        [TestMethod]
        public void Calendar_WithInvalidDay_ShouldThrowBigger()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => { Date calendar = new Date(32, 10, 2024); });
        }

        [TestMethod]
        public void Calendar_WithInvalidDay_ShouldThrow31WhenNot31DaysMonth()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => { Date calendar = new Date(31, 4, 2024); });
        }

        [TestMethod]
        public void Calendar_WithInvalidDay_ShouldThrow29WhenNotLeapYear()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => { Date calendar = new Date(29, 2, 2023); });
        }

        [TestMethod]
        public void IsALeapYear_WithValidYear_IsCorrectTrue()
        {
            Date calendar = new Date(28, 2, 2024);
            bool expected = true;
            bool actual = calendar.IsLeapYear();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IsALeapYear_WithValidYear_IsCorrectTrueSecular()
        {
            Date calendar = new Date(28, 2, 1600);
            bool expected = true;
            bool actual = calendar.IsLeapYear();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IsALeapYear_WithValidYear_IsCorrectFalse()
        {
            Date calendar = new Date(28, 2, 2023);
            bool expected = false;
            bool actual = calendar.IsLeapYear();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IsALeapYear_WithValidYear_IsCorrectFalseSecular()
        {
            Date calendar = new Date(28, 2, 1900);
            bool expected = false;
            bool actual = calendar.IsLeapYear();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ReturnMonthName_WithValidMonth_IsCorrect()
        {
            Date calendar = new Date(28, 2, 1900);
            string expected = "February";
            string actual = calendar.ReturnMonthName(calendar.Month);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddYear_WithValidYear_IsCorrect()
        {
            Date calendar = new Date(28, 2, 1900);
            calendar.AddYear(11);
            int expected = 1911;
            int actual = calendar.Year;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddMonth_WithValidMonth_IsCorrectInYear()
        {
            Date calendar = new Date(28, 2, 1900);
            calendar.AddMonth(3);
            int expected = 5;
            int actual = calendar.Month;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddMonth_WithValidMonth_IsCorrectOutYearNext()
        {
            Date calendar = new Date(28, 2, 1900);
            calendar.AddMonth(13);
            int expectedMonth = 3;
            int actualMonth = calendar.Month;
            int expectedYear = 1901;
            int actualYear = calendar.Year;
            Assert.AreEqual(expectedMonth, actualMonth);
            Assert.AreEqual(expectedYear, actualYear);
        }

        [TestMethod]
        public void AddMonth_WithValidMonth_IsCorrectOutYearBefore()
        {
            Date calendar = new Date(28, 2, 1900);
            calendar.AddMonth(-13);
            int expectedMonth = 1;
            int actualMonth = calendar.Month;
            int expectedYear = 1899;
            int actualYear = calendar.Year;
            Assert.AreEqual(expectedMonth, actualMonth);
            Assert.AreEqual(expectedYear, actualYear);
        }

        [TestMethod]
        public void AddDay_WithValidDay_IsCorrectInMonth()
        {
            Date calendar = new Date(1, 4, 1900);
            calendar.AddDay(13);
            int expectedDay = 14;
            int actualDay = calendar.Day;
            Assert.AreEqual(expectedDay, actualDay);
        }

        [TestMethod]
        public void AddDay_WithValidDay_IsCorrectInMonth31True()
        {
            Date calendar = new Date(15, 1, 1900);
            calendar.AddDay(16);
            int expectedDay = 31;
            int actualDay = calendar.Day;
            Assert.AreEqual(expectedDay, actualDay);
        }

        [TestMethod]
        public void AddDay_WithValidDay_IsCorrectOutMonth31True()
        {
            Date calendar = new Date(15, 1, 1900);
            calendar.AddDay(17);
            int expectedDay = 1;
            int actualDay = calendar.Day;
            Assert.AreEqual(expectedDay, actualDay);
        }

        [TestMethod]
        public void AddDay_WithValidDay_IsCorrectOutMonth31False()
        {
            Date calendar = new Date(15, 4, 1900);
            calendar.AddDay(17);
            int expectedDay = 2;
            int actualDay = calendar.Day;
            Assert.AreEqual(expectedDay, actualDay);
        }

        [TestMethod]
        public void AddDay_WithValidDay_IsCorrectOutMonthFebruaryTrueLeapFalse()
        {
            Date calendar = new Date(15, 2, 1900);
            calendar.AddDay(17);
            int expectedDay = 4;
            int actualDay = calendar.Day;
            Assert.AreEqual(expectedDay, actualDay);
        }

        [TestMethod]
        public void AddDay_WithValidDay_IsCorrectOutMonthFebruaryTrueLeapTrue()
        {
            Date calendar = new Date(15, 2, 2000);
            calendar.AddDay(17);
            int expectedDay = 3;
            int actualDay = calendar.Day;
            Assert.AreEqual(expectedDay, actualDay);
        }

        [TestMethod]
        public void AddDay_WithValidDay_IsCorrectOutMonthBefore31True()
        {
            Date calendar = new Date(15, 2, 1900);
            calendar.AddDay(-17);
            int expectedDay = 29;
            int actualDay = calendar.Day;
            Assert.AreEqual(expectedDay, actualDay);
        }

        [TestMethod]
        public void AddDay_WithValidDay_IsCorrectOutMonthBefore31False()
        {
            Date calendar = new Date(15, 5, 1900);
            calendar.AddDay(-17);
            int expectedDay = 28;
            int actualDay = calendar.Day;
            Assert.AreEqual(expectedDay, actualDay);
        }

        [TestMethod]
        public void AddDay_WithValidDay_IsCorrectOutMonthBeforeFebruaryTrueLeapFalse()
        {
            Date calendar = new Date(15, 3, 1900);
            calendar.AddDay(-17);
            int expectedDay = 26;
            int actualDay = calendar.Day;
            Assert.AreEqual(expectedDay, actualDay);
        }

        [TestMethod]
        public void AddDay_WithValidDay_IsCorrectOutMonthBeforeFebruaryTrueLeapTrue()
        {
            Date calendar = new Date(15, 2, 2000);
            calendar.AddDay(-17);
            int expectedDay = 29;
            int actualDay = calendar.Day;
            Assert.AreEqual(expectedDay, actualDay);
        }

    }
}
