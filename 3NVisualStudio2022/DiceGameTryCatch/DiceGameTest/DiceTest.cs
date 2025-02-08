using  DiceGame;
namespace DiceGameTest
{
    [TestClass]
    public class DiceTest
    {
        [TestMethod]
        public void Dice_WithValidnFaces_UpdatenFaces()
        {
            Dice diceTest = new Dice(6);
            int expected = 6;
            int actual = diceTest.NFaces;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Dice_WithInValidnFacesNegative_ShouldThrow()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => { Dice diceTest = new Dice(-1); });
        }

        [TestMethod]
        public void Dice_WithInValidnFacesOdd_ShouldThrow()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => { Dice diceTest = new Dice(7); });
        }

        [TestMethod]
        public void RollDice_WithValidnFaces_IsCorrect() 
        {
            Dice diceTest = new Dice(6);
            int actual = diceTest.RollDice();
            bool expected;
            if (actual is >= 1 and <= 6) expected = true;
            else expected = false;

            Assert.AreEqual(expected,true);
        }

        [TestMethod]
        public void RolldDiceMoreThan1Time_WithValidnFaces_Is_Correct()
        {
            Dice diceTest = new Dice();
            int actual = diceTest.RolldDiceMoreTimes(2);
            bool expected;
            if (actual is >= 2 and <= 12) expected = true;
            else expected = false;

            Assert.AreEqual(expected, true);
        }
    }
}