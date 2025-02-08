using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiceGame;
    

namespace DiceGameTest
{
    [TestClass]
    public class GameTest
    {

        [TestMethod]
        public void Game_WithInvalidSpecialRoll_ShouldThrow()
        {
            Player p1 = new Player("p1");
            Player p2 = new Player("p2");
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => { Game game = new Game(p1, p2, -1); });

        }

        [TestMethod]
        public void Game_WithInvalidMaxRounds_ShouldThrow()
        {
            Player p1 = new Player("p1");
            Player p2 = new Player("p2");
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => { Game game = new Game(p1, p2, 11,-1); });

        }

        [TestMethod]
        public void Game_WithInvalidMaxPoints_ShouldThrow()
        {
            Player p1 = new Player("p1");
            Player p2 = new Player("p2");
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => { Game game = new Game(p1, p2, 11, 15,-1); });

        }

        [TestMethod]
        public void SimulateGame_WithValidDice_IsCorrect()
        {
            Player p1 = new Player("p1");
            Player p2 = new Player("p2");
            Dice dice = new Dice(6);
            Game game = new Game(p1, p2);
            Player? result = game.SimulateGame(dice);

            if (result == null)
            {
                Assert.AreEqual(result, null);
            }
            else if (p1.Equals(result))
            {
                Assert.AreEqual(result, p1);
            }
            else 
            {
                Assert.AreEqual(result, p2);
            }

        }

    }
}
