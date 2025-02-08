using VERIFICA_NOVEMBRE_DIMASI;
namespace TEST_VERIFICA_NOVEMBRE_DIMASI
{
    [TestClass]
    public class TestSession
    {
        [TestMethod]
        public void Session_WithInvalidHours_ShouldThrow()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>{ Session session = new Session(-1, 12, 34, false); });
        }

        [TestMethod]
        public void SessionWithInvalidMinutes_ShouldThrow()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => { Session session = new Session(3, -1, 34, false); });
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => { Session session = new Session(3, 61, 34, false); });
        }

        [TestMethod]
        public void Session_WithInvaliSeconds_ShouldThrow()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => { Session session = new Session(3, 11, -1, false); });
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => { Session session = new Session(3, 11, 61, false); });
        }

        [TestMethod]
        public void Session_WithInvalidTypeOfSession_ShouldThrow()
        {
             Assert.ThrowsException<ArgumentOutOfRangeException>(() => { Session session = new Session(3, 11, 11, true); });
             Assert.ThrowsException<ArgumentOutOfRangeException>(() => { Session session = new Session(5, 11, 11, false); });
        }

        [TestMethod]
        public void Equal_WithValidValue_IsCorrect_True()
        {
            Session s1 = new Session(6, 11, 11, true);
            Session s2 = new Session(6, 11, 11, true);

            bool expected = true;
            bool actual = s1.Equals(s2);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Equal_WithValidValue_IsCorrect_False()
        {
            Session s1 = new Session(6, 11, 11, true);
            Session s2 = new Session(3, 12, 54, false);

            bool expected = false;
            bool actual = s1.Equals(s2);

            Assert.AreEqual(expected, actual);
        }


    }

}