using StatistisDiceLib;
namespace StatistcDiceTest
{
    [TestClass]
    public class TestPlayer
    {
        [TestMethod]
        public void Player_WithInvalidName_ShouldThrow()
        {
            int[] list = new int[10];
            Dice dice = new Dice();
            Assert.ThrowsException<ArgumentNullException>(() => { Player test = new Player("", dice,list); });
        }

        [TestMethod]
        public void PlayGames_WithValidValues_ShouldBeCorrect()
        {
            int[] list = new int[10];
            Dice dice = new Dice();
            Player test = new Player("Russo", dice, list);
            
            test.PlayGames();

            bool expected = true;
            bool actual=true;

            for (int i = 0; i < list.Length; i++)
            {
                if(list[i] < 0 || list[i] > dice.NFaces)
                    actual=false;
            }

            Assert.AreEqual(expected, actual);
        }
    }
}