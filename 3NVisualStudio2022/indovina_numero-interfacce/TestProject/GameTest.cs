using CoreLibrary;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.ObjectModel;

namespace TestProject
{
    [TestClass]
    public class GameTest
    {
        /*
         * Questo progetto è molto semplice ed ora conel interfacce è anche testabile
         * Definiamo per i Test una classe FixedGenerator che implemnta l'interface IGenerator
         * e che restituisce come numeor da indovinare un numero fisso; in questo modo possiamo testare 
         * il corretto comportamento della partita 
         */

        [TestMethod]
        public void Attempts_attemptEqualsToNumberToGuess_GameStatusWin()
        {
            int fixedNumber = 100;
            FixedGenerator generator = new FixedGenerator(fixedNumber);

            Game game = new Game(10, 1000, generator);

            Assert.AreEqual(GameStatus.WIN, game.Attempts(fixedNumber));
        }
        
        [TestMethod]
        public void Attempts_attemptNotEqualsToNumerToGuess_GameStatusInProgress()
        {
            int fixedNumber = 100;
            FixedGenerator generator = new FixedGenerator(fixedNumber);

            Game game = new Game(10, 1000, generator);

            Assert.AreEqual(GameStatus.IN_PROGRESS, game.Attempts(fixedNumber+1));
        }

        [TestMethod]
        public void Attempts_attemptNotEqualsToNumerToGuessAndNoMoreRemainingAttempts_GameStatusLose()
        {
            int fixedNumber = 100;
            FixedGenerator generator = new FixedGenerator(fixedNumber);

            Game game = new Game(10, 1000, generator);

            //provo 9 volte quello sbagliato
            for(int i = 0;i< 9; i++) 
            { 
                game.Attempts(fixedNumber + 1); 
            }

            //verifico che alla decima volta dia lose
            Assert.AreEqual(GameStatus.LOSE, game.Attempts(fixedNumber + 1));
        }

    }
}