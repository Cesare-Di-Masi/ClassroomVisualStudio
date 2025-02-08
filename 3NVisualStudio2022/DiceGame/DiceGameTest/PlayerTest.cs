using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DiceGame;
namespace DiceGameTest
{
    [TestClass]
    public class PlayerTest
    {

        [TestMethod]
        public void Player_WithValidNickname_UpdateNickname()
        {
            Player player = new Player("p1");
            string expected = "p1";
            string actual= player.Nickname;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Player_WithValidScore_UpdateScore()
        {
            Player player = new Player("p1", 10);
            int expected = 10;
            int actual = player.Score;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Player_WithInvalidSCore_ShouldThrow()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => { Player player = new Player("p1", -10); });
        }

        [TestMethod]
        public void Equals_WithValidPlayer_IsCorrect()
        {
            Player player1 = new Player("p1", 10);
            Player player2 = new Player("p1", 10);
            bool expected = true;
            bool actual = player1.Equals(player2);
            Assert.AreEqual(expected, actual);
        }

    } 
}
