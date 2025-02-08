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
        public void Game_WithInvalidPlayer_ShouldThrow()
        {
            Player p1 = new Player("p1");
            Player p2 = new Player("p1");
            Assert.ThrowsException<ArgumentException>(() => { Game game = new Game(p1, p2); }); 
        }

        [TestMethod]
        public void Game_WithInvalidSpecialRoll_ShouldThrow()
        {
            Player p1 = new Player("p1");
            Player p2 = new Player("p2");
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => { Game game = new Game(p1, p2, -1,10,10); });

        }

        [TestMethod]
        public void Game_WithInvalidMaxRounds_ShouldThrow()
        {
            Player p1 = new Player("p1");
            Player p2 = new Player("p2");
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => { Game game = new Game(p1, p2, 11,-1,10); });

        }

        [TestMethod]
        public void Game_WithInvalidMaxPoints_ShouldThrow()
        {
            Player p1 = new Player("p1");
            Player p2 = new Player("p2");
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => { Game game = new Game(p1, p2, 11, 15,-1); });

        }

        [TestMethod]
        public void SimulateGame_WithValidDice_IsWinnerCorrect()
        {
            Player p1 = new Player("p1");
            Player p2 = new Player("p2");
            Dice dice = new Dice(6);
            Game game = new Game(p1, p2);
            Player? result = game.SimulateGame(dice);

            if (game.Player1.Score == game.Player2.Score)
            {
                Assert.AreEqual(result, null);
            }
            else if (game.Player1.Score>game.Player2.Score)
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
