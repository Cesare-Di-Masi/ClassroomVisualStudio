using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VERIFICA_TEORIA_DIMASI
{
    public class Torneo
    {
        private Giocatore[] giocatori;
        private Partita[][] risultatiGiocatori;
        private int[] _partiteGiocate;

        public Torneo(Giocatore[] g, int maxPartite)
        {
            
            if (maxPartite <= 0) throw new ArgumentOutOfRangeException(nameof(maxPartite), "Il numero massimo di partite deve essere maggiore di zero.");


            giocatori = g;
            _partiteGiocate = new int[g.Length];
            inizializzaRisultati(maxPartite);
        }

        private void inizializzaRisultati(int maxPartite)
        {
            risultatiGiocatori = new Partita[giocatori.Length][];
            for (int i = 0; i < giocatori.Length; i++)
            {
                risultatiGiocatori[i] = new Partita[maxPartite];
            }
        }

        public void AggiungiPartita(Partita partita)
        {
            if (partita.Giocatore1.Numero < 0 || partita.Giocatore1.Numero >= giocatori.Length)
                throw new ArgumentOutOfRangeException("il giocatore1 non esiste");

            if (partita.Giocatore2.Numero < 0 || partita.Giocatore2.Numero >= giocatori.Length)
                throw new ArgumentOutOfRangeException("il giocatore2 non esiste");

            int vincitore = 0;
            int perdente = 0;

            if (partita.Vincitore == null)
            {
                int giocatore1 = partita.Giocatore1.Numero;
                int giocatore2 = partita.Giocatore2.Numero;
                risultatiGiocatori[giocatore1][_partiteGiocate[giocatore1]] = partita;
                risultatiGiocatori[giocatore2][_partiteGiocate[giocatore2]] = partita;
                _partiteGiocate[giocatore1]++;
                _partiteGiocate[giocatore2]++;


                PosizionaPunteggi(giocatore1, giocatore2, true);
        
    }
            else
            {
                if (partita.Vincitore == partita.Giocatore1)
                {
                    vincitore = partita.Giocatore1.Numero;
                    perdente = partita.Giocatore2.Numero;
                }
                else
                {
                    vincitore = partita.Giocatore2.Numero;
                    perdente = partita.Giocatore1.Numero;

                }
                risultatiGiocatori[vincitore][_partiteGiocate[vincitore]] = partita;
                _partiteGiocate[vincitore]++;
                risultatiGiocatori[perdente][_partiteGiocate[perdente]] = partita;
                _partiteGiocate[perdente]++;
                PosizionaPunteggi(vincitore, perdente, false);
                
}
        }

        private void PosizionaPunteggi(int vincitore, int perdente, bool pareggio)
        {
            if (pareggio == true)
            {
                giocatori[vincitore].AggiungiPunteggio(0);
                giocatori[perdente].AggiungiPunteggio(0);
            }
            else
            {
                giocatori[vincitore].AggiungiPunteggio(1);
                giocatori[perdente].AggiungiPunteggio(-1);

            }
        }

        public int PartiteDaGiocatore(Giocatore giocatore)
        {
            if (giocatore.Numero < 0 || giocatore.Numero > giocatori.Length - 1)
                throw new ArgumentOutOfRangeException("il giocatore non esiste");

            return giocatori[giocatore.Numero].PartiteGiocate;

        }

        public int PartiteVinteDaGiocatore(Giocatore giocatore)
        {
            if (giocatore.Numero < 0 || giocatore.Numero > giocatori.Length - 1)
                throw new ArgumentOutOfRangeException("il giocatore non esiste");

            int counter = 0;

            for (int i = 0; i < giocatori[giocatore.Numero].PartiteGiocate;)
            {
                if (giocatori[giocatore.Numero].RisultatiPartite[i] == 1)
                    counter++;
            }
            return counter;
        }
        public int PartitePerseDaGiocatore(Giocatore giocatore)
        {
            if (giocatore.Numero < 0 || giocatore.Numero > giocatori.Length - 1)
                throw new ArgumentOutOfRangeException("il giocatore non esiste");

            int counter = 0;

            for (int i = 0; i < giocatori[giocatore.Numero].PartiteGiocate;)
            {
                if (giocatori[giocatore.Numero].RisultatiPartite[i] == -1)
                    counter++;
            }
            return counter;
        }

        public int[,] PunteggiPartiteGiocatori(int partite)
        {
            if(partite < 0 || partite > giocatori[0].PartiteGiocate - 1)
                throw new ArgumentOutOfRangeException("il numero di partite non esiste");

            int[,] punteggi = new int[partite, giocatori.Length];
        
            for (int i = 0; i < giocatori.Length; i++)
            {
                for (int j = 0; j < partite; j++)
                {
                    punteggi[j, i] = giocatori[i].RisultatiPartite[partite];
                }
            }
            return punteggi;

        }


    }


}




