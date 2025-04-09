using VERIFICA_TEORIA_DIMASI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TorneoTest
{
    [TestClass]
    public class TorneoTest
    {

        [TestMethod]
        public void Torneo_MaxPartiteZero_ThrowsException()
        {
            Giocatore[] giocatori = new Giocatore[2];
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Torneo(giocatori, 0));
        }

        
        [TestMethod]
        public void AggiungiPartita_Giocatore_NonEsiste_ThrowsException()
        {
            Giocatore g1 = new Giocatore("Giocatore1", DateTime.Now, 100, 1);
            Giocatore g2 = new Giocatore("Giocatore2", DateTime.Now, 200, 2);
            Giocatore[] giocatori = new Giocatore[] { g1, g2 };
            Giocatore g3 = new Giocatore("Giocatore3", DateTime.Now, 300, 3);

            Torneo torneo = new Torneo(giocatori, 5);

            Partita partita = new Partita(g1, g3, g3);

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => torneo.AggiungiPartita(partita));

        }

        [TestMethod]
        public void PartiteDaGiocatore_giocatore_NonEsiste() 
        {
            Giocatore g1 = new Giocatore("Giocatore1", DateTime.Now, 100, 1);
            Giocatore g2 = new Giocatore("Giocatore2", DateTime.Now, 200, 2);
            Giocatore[] giocatori = new Giocatore[] { g1, g2 };
            Giocatore g3 = new Giocatore("Giocatore3", DateTime.Now, 300, 3);
            Torneo torneo = new Torneo(giocatori, 5);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => torneo.PartiteDaGiocatore(g3));
        }

        [TestMethod]
        public void PartiteDaGiocatore_giocatore_ECorretto()
        {
            Giocatore g1 = new Giocatore("Giocatore1", DateTime.Now, 100, 0);
            Giocatore g2 = new Giocatore("Giocatore2", DateTime.Now, 200, 1);
            Giocatore[] giocatori = new Giocatore[] { g1, g2 };
            Torneo torneo = new Torneo(giocatori, 5);
            Partita partita = new Partita(g1, g2, g1);
            torneo.AggiungiPartita(partita);
            Assert.AreEqual(1, torneo.PartiteDaGiocatore(g1));
        }

        [TestMethod]
        public void PartiteVinteDaGiocatore_giocatore_NonEsiste()
        {
            Giocatore g1 = new Giocatore("Giocatore1", DateTime.Now, 100, 0);
            Giocatore g2 = new Giocatore("Giocatore2", DateTime.Now, 200, 1);
            Giocatore[] giocatori = new Giocatore[] { g1, g2 };
            Giocatore g3 = new Giocatore("Giocatore3", DateTime.Now, 300, 2);
            Torneo torneo = new Torneo(giocatori, 5);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => torneo.PartiteVinteDaGiocatore(g3));
        }

        [TestMethod]
        public void PartiteVinteDaGiocatore_giocatore_ECorretto()
        {
            Giocatore g1 = new Giocatore("Giocatore1", DateTime.Now, 100, 0);
            Giocatore g2 = new Giocatore("Giocatore2", DateTime.Now, 200, 1);
            Giocatore[] giocatori = new Giocatore[] { g1, g2 };
            Torneo torneo = new Torneo(giocatori, 5);
            Partita partita = new Partita(g1, g2, g1);
            torneo.AggiungiPartita(partita);
            Assert.AreEqual(1, torneo.PartiteDaGiocatore(g1));
        }

        [TestMethod]
        public void PartitePerseDaGiocatore_giocatore_NonEsiste()
        {
            Giocatore g1 = new Giocatore("Giocatore1", DateTime.Now, 100, 0);
            Giocatore g2 = new Giocatore("Giocatore2", DateTime.Now, 200, 1);
            Giocatore[] giocatori = new Giocatore[] { g1, g2 };
            Giocatore g3 = new Giocatore("Giocatore3", DateTime.Now, 300, 2);
            Torneo torneo = new Torneo(giocatori, 5);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => torneo.PartitePerseDaGiocatore(g3));
        }

        [TestMethod]
        public void PartitePerse_DaGiocatore_giocatore_ECorretto()
        {
            Giocatore g1 = new Giocatore("Giocatore1", DateTime.Now, 100, 0);
            Giocatore g2 = new Giocatore("Giocatore2", DateTime.Now, 200, 1);
            Giocatore[] giocatori = new Giocatore[] { g1, g2 };
            Torneo torneo = new Torneo(giocatori, 5);
            Partita partita = new Partita(g1, g2, g2);
            torneo.AggiungiPartita(partita);
            Assert.AreEqual(1, torneo.PartitePerseDaGiocatore(g1));
        }

        [TestMethod]
        public void PunteggiPartiteGiocatori_ECorretto()
        {
            Giocatore g1 = new Giocatore("Giocatore1", DateTime.Now, 100, 0);
            Giocatore g2 = new Giocatore("Giocatore2", DateTime.Now, 200, 1);
            Giocatore[] giocatori = new Giocatore[] { g1, g2 };
            Torneo torneo = new Torneo(giocatori, 5);
            Partita partita1 = new Partita(g1, g2, g1);
            Partita partita2 = new Partita(g1, g2, g2);
            int[,] punteggi = new int[2, 2];
            punteggi[0, 0] = 1;
            punteggi[0, 1] = -1;
            punteggi[1, 0] = -1;
            punteggi[1, 1] = 1;

            torneo.AggiungiPartita(partita1);
            torneo.AggiungiPartita(partita2);

            CollectionAssert.AreEqual(punteggi, torneo.PunteggiPartiteGiocatori(2));

        }

    }

    
   
}