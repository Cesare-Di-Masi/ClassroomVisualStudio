using TimeManagement;
namespace TestTimeManagement
{
    [TestClass]
    public class TestHours
    {
        [TestMethod]
        public void Hours_WithInvalidHourNegative_ShouldThrow() 
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => { Time test = new Time(-1, 20); });
        }

        [TestMethod]
        public void Hours_WithInvalidHourBigger_ShouldThrow()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => { Time test = new Time(25, 20); });
        }

        [TestMethod]
        public void Hous_WithInvalidMinutesNegative_ShouldThrow()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => { Time test = new Time(20, -1); });
        }

        [TestMethod]
        public void Hous_WithInvalidMinutesBigger_ShouldThrow()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => { Time test = new Time(20, 61); });
        }

        [TestMethod]
        public void  IsAm_WithValidHoursAndMinutes_IsCorrectTrue()
        {
            Time test = new Time(1, 20);
            bool expected = true;
            bool actual = test.IsAm();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IsAm_WithValidHoursAndMinutes_IsCorrectFalse()
        {
            Time test = new Time(20, 1);
            bool expected = false;
            bool actual = test.IsAm();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddHours_WithPositiveHourToAdd_IsCorrectInTheDay()
        {
            Time test = new Time(12, 0);
            test.AddHours(1);
            int expected = 13;
            int actual = test.Hour;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddHours_WithPositiveHourToAdd_IsCorrectOutTheDay()
        {
            Time test = new Time(12, 0);
            test.AddHours(13);
            int expected = 1;
            int actual = test.Hour;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddHours_WithNegativeHourToAdd_IsCorrectInTheDay()
        {
            Time test = new Time(12, 0);
            test.AddHours(-1);
            int expected = 11;
            int actual = test.Hour;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddHours_WithNegativeHourToAdd_IsCorrectOutTheDay()
        {
            Time test = new Time(12, 0);
            test.AddHours(-13);
            int expected = 23;
            int actual = test.Hour;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddMinutes_WithPositiveMinutesToAdd_IsCorrectInTheHour()
        {
            Time test = new Time(12, 20);
            test.AddMinutes(1);
            int expected = 21;
            int actual = test.Minutes;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddMinutes_WithPositiveMinutesToAdd_IsCorrectOutTheHour()
        {
            Time test = new Time(12, 20);
            test.AddMinutes(50);
            int expectedMinutes = 10;
            int expectedHours = 13;
            int actualMinutes = test.Minutes;
            int actualHours = test.Hour;
            Assert.AreEqual(expectedMinutes, actualMinutes);
            Assert.AreEqual(expectedHours, actualHours);
        }

        [TestMethod]
        public void AddMinutes_WithNegativeMinutesToAdd_IsCorrectInTheDay()
        {
            Time test = new Time(12, 20);
            test.AddMinutes(-1);
            int expected = 19;
            int actual = test.Minutes;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddMinutes_WithNegativeMinutesToAdd_IsCorrectOutTheDay()
        {
            Time test = new Time(12, 20);
            test.AddMinutes(-30);
            int expectedMinutes = 50;
            int expectedHours = 11;
            int actualMinutes = test.Minutes;
            int actualHours = test.Hour;
            Assert.AreEqual(expectedMinutes, actualMinutes);
            Assert.AreEqual(expectedHours, actualHours);
        }

        [TestMethod]
        public void ToString_WithValidHoursAndMinutes_IsCorrect()
        {
            Time test = new Time(6, 9);
            string expected = "6:9";
            string actual = test.ToString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Equals_WithValidHoursAndMinutes_IsCorrectTrue()
        {
            Time test1 = new Time(12, 20);
            Time test2 = new Time(12, 20);
            bool expected = true;
            bool actual = test1.Equals(test2);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Equals_WithValidHoursAndMinutes_IsCorrectFalse()
        {
            Time test1 = new Time(12, 20);
            Time test2 = new Time(12, 21);
            bool expected = false;
            bool actual = test1.Equals(test2);
            Assert.AreEqual(expected, actual);
        }

    }
}