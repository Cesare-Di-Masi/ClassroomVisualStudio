using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VERIFICA_NOVEMBRE_DIMASI;

namespace TEST_VERIFICA_NOVEMBRE_DIMASI
{
    [TestClass]
    public class TestAthlete
    {

        [TestMethod]
        public void Athlete_WithInvalidCardNumber_ShouldThrow()
        {
            Session s1 = new Session(1, 10, 15);
            Session s2 = new Session(5, 10, 15);

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => { Athlete athlete = new Athlete(-1, "test", s2, s1); });
        }

        [TestMethod]
        public void Athlete_WithInvalidName_ShouldThrow()
        {
            Session s1 = new Session(1, 10, 15);
            Session s2 = new Session(5, 10, 10);

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => { Athlete athlete = new Athlete(1, " ", s2, s1); });
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => { Athlete athlete = new Athlete(1, "", s2, s1); });
        }

        [TestMethod]
        public void getBestIntensiveSessionMinutes_WithValidValues_IsCorrect()
        {
            Session s1 = new Session(1, 10, 15);
            Session s2 = new Session(5, 10, 10);

            Athlete athlete = new Athlete(1, "Test", s2, s1);

            int expected = 310;
            int actual = athlete.getBestIntensiveSessionMinutes();

            Assert.AreEqual(expected, actual);        
        }

        [TestMethod]
        public void getBestStandardSessionMinutes_WithValidValues_IsCorrect()
        {
            Session s1 = new Session(1, 10, 15);
            Session s2 = new Session(5, 10, 10);

            Athlete athlete = new Athlete(1, "Test", s2, s1);

            int expected = 70;
            int actual = athlete.getBestStandardSessionMinutes();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IsNewSessionBetter_WithValidValues_IsCorrectUpdate()
        {
            Session s1 = new Session(1, 10, 15);
            Session s2 = new Session(5, 10, 10);

            Athlete athlete = new Athlete(1, "Test", s2, s1);

            Session newS1 = new Session(3, 28, 9);
            Session newS2 = new Session(6, 15, 15);

            athlete.IsNewSessionBetter(newS1);
            athlete.IsNewSessionBetter(newS2);

            Assert.AreEqual(true, athlete.BestStandard.Equals(newS1));
            Assert.AreEqual(true, athlete.BestIntensive.Equals(newS2));

        }

        [TestMethod]
        public void IsNewSessionBetter_WithValidValues_IsCorrectDoNotUpdate()
        {
            Session s1 = new Session(3, 10, 15);
            Session s2 = new Session(6, 10, 10);

            Athlete athlete = new Athlete(1, "Test", s2, s1);

            Session newS1 = new Session(1, 28, 9 );
            Session newS2 = new Session(4, 24, 15);

            athlete.IsNewSessionBetter(newS1);
            athlete.IsNewSessionBetter(newS2);

            Assert.AreEqual(false, athlete.BestStandard.Equals(newS1));
            Assert.AreEqual(false, athlete.BestIntensive.Equals(newS2));
        }


    }
}
