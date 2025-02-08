using TrainLib;

namespace TestTrainLib
{
    [TestClass]
    public class TestTrain

    {
        [TestMethod]
        public void Train_WithInvalidTrainNumber_ShouldThrow()
        {
            DateAndTime h1 = new DateAndTime(12, 12, 12, 12, 12);
            DateAndTime h2 = new DateAndTime(13, 12, 13, 13, 13);
            DateAndTime h3 = new DateAndTime(16, 12, 16, 16, 16);
            DateAndTime h4 = new DateAndTime(17, 12, 17, 17, 17);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => { Train test = new Train(-1, "Roma", "Milano", h1, h3, h2, h4); });
        }

        [TestMethod]
        public void Train_WithInvalidStartAndEndStationName_ShouldThrow()
        {
            DateAndTime h1 = new DateAndTime(12, 12, 12, 12, 12);
            DateAndTime h2 = new DateAndTime(13, 12, 13, 13, 13);
            DateAndTime h3 = new DateAndTime(16, 12, 16, 16, 16);
            DateAndTime h4 = new DateAndTime(17, 12, 17, 17, 17);
            Assert.ThrowsException<ArgumentNullException>(() => { Train test = new Train(100, "", "Milano", h1, h3, h2, h4); });
            Assert.ThrowsException<ArgumentNullException>(() => { Train test = new Train(100, "Roma", "", h1, h3, h2, h4); });
        }

        [TestMethod]
        public void Train_WithInvalidExEnd_ShouldThrow()
        {
            DateAndTime h1 = new DateAndTime(12, 12, 12, 12, 12);
            DateAndTime h2 = new DateAndTime(13, 12, 13, 13, 13);
            DateAndTime h3 = new DateAndTime(11, 11, 16, 16, 16);
            DateAndTime h4 = new DateAndTime(17, 12, 17, 17, 17);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => { Train test = new Train(100, "Roma", "Milano", h1, h3, h2, h4); });
        }

        [TestMethod]
        public void Train_WithInvalidAcEnd_ShouldThrow()
        {
            DateAndTime h1 = new DateAndTime(12, 12, 12, 12, 12);
            DateAndTime h2 = new DateAndTime(13, 12, 13, 13, 13);
            DateAndTime h3 = new DateAndTime(16, 11, 16, 16, 16);
            DateAndTime h4 = new DateAndTime(11, 11, 11, 11, 11);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => { Train test = new Train(100, "Roma", "Milano", h1, h3, h2, h4); });
        }

        [TestMethod]
        public void DelayInMinute_WithValidValues_IsCorrect()
        {
            DateAndTime h1 = new DateAndTime(12, 12, 12, 12, 12);
            DateAndTime h2 = new DateAndTime(13, 12, 13, 13, 13);
            DateAndTime h3 = new DateAndTime(17, 11, 16, 16, 16);
            DateAndTime h4 = new DateAndTime(17, 11, 16, 17, 17);
            Train test = new Train(100, "Roma", "Milano", h1, h3, h2, h4);
            Assert.AreEqual(61, test.delayInMinutes());
        }
    }
}