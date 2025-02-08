using TrainLib;
using TimeManagement;
using TestTimeManagement;
namespace TestTrainLib
{
    [TestClass]
    public class TestTrain

    {
        [TestMethod]
        public void Train_WithInvalidTrainNumber_ShouldThrow()
        {
            HoursCalendar h1 = new HoursCalendar(12,12,12,12,12);
            HoursCalendar h2 = new HoursCalendar(13,12,13,13,13);
            HoursCalendar h3 = new HoursCalendar(16, 12, 16, 16, 16);
            HoursCalendar h4 = new HoursCalendar(17, 12, 17, 17, 17);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => { Train test = new Train(-1, "Roma", "Milano", h1, h3, h2, h4); });
        }

        [TestMethod]
        public void Train_WithInvalidStartAndEndStationName_ShouldThrow()
        {
            HoursCalendar h1 = new HoursCalendar(12, 12, 12, 12, 12);
            HoursCalendar h2 = new HoursCalendar(13, 12, 13, 13, 13);
            HoursCalendar h3 = new HoursCalendar(16, 12, 16, 16, 16);
            HoursCalendar h4 = new HoursCalendar(17, 12, 17, 17, 17);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => { Train test = new Train(100, "", "Milano", h1, h3, h2, h4); });
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => { Train test = new Train(100, "Roma", "", h1, h3, h2, h4); });
        }

        [TestMethod]
        public void Train_WithInvalidExEnd_ShouldThrow()
        {
            HoursCalendar h1 = new HoursCalendar(12, 12, 12, 12, 12);
            HoursCalendar h2 = new HoursCalendar(13, 12, 13, 13, 13);
            HoursCalendar h3 = new HoursCalendar(11, 11, 16, 16, 16);
            HoursCalendar h4 = new HoursCalendar(17, 12, 17, 17, 17);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => { Train test = new Train(100, "Roma", "Milano", h1, h3, h2, h4); });
        }

        [TestMethod]
        public void Train_WithInvalidAcEnd_ShouldThrow()
        {
            HoursCalendar h1 = new HoursCalendar(12, 12, 12, 12, 12);
            HoursCalendar h2 = new HoursCalendar(13, 12, 13, 13, 13);
            HoursCalendar h3 = new HoursCalendar(16, 11, 16, 16, 16);
            HoursCalendar h4 = new HoursCalendar(11, 11, 11, 17, 17);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => { Train test = new Train(100, "Roma", "Milano", h1, h3, h2, h4); });
        }

        [TestMethod]
        public void DelayInMinute_WithValidValues_IsCorrect()
        {
            HoursCalendar h1 = new HoursCalendar(12, 12, 12, 12, 12);
            HoursCalendar h2 = new HoursCalendar(13, 12, 13, 13, 13);
            HoursCalendar h3 = new HoursCalendar(17, 11, 16, 16, 16);
            HoursCalendar h4 = new HoursCalendar(17, 11, 16, 17, 17);
            Train test = new Train(100, "Roma", "Milano", h1, h3, h2, h4);
            Assert.AreEqual(61, test.delayInMinutes());
        }

    }
}