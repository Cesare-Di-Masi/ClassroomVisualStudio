using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Ramino
{
    public class Torneo
    {
        private Giocatore[] _giocatori;
        private int _numeroPartite;
        public int NumeroPartite
        {
            get { return _numeroPartite; }
        }

        public Torneo(int numeroGiocatori, int numeroPartite)
        {
            _giocatori = new Giocatore[numeroGiocatori];
            _numeroPartite = numeroPartite;
            for (int i = 0; i < numeroGiocatori; i++)
            {
                _giocatori[i] = new Giocatore(i.ToString(), numeroPartite);
            }
        }

        public Torneo(string[] nomiGiocatori, int numeroPartite)
        {
            _giocatori = new Giocatore[nomiGiocatori.Length];
            _numeroPartite += numeroPartite;
            int i = 0;
            foreach(string nome in nomiGiocatori)
            {
                _giocatori[i] = new Giocatore(nome, numeroPartite);
                i += 1;
            }
        }

        public void aggiungiPunteggio(int posizioneGiocatore, int partita,int punteggio)
        {
            if (posizioneGiocatore < 1 || posizioneGiocatore > _giocatori.Length) { throw new ArgumentOutOfRangeException("posizione giocatore illegale"); }
            if (partita < 1 || partita > _numeroPartite) 
            if (punteggio < 1 || punteggio > 100) { throw new ArgumentOutOfRangeException("punteggio illegale"); }

            _giocatori[posizioneGiocatore-1].MemorizzaPunteggioPartita(punteggio, partita);

        }

        public string[] vincitore()
        {
            string[] listaNomi = new string[_giocatori.Length];
            int? max = 0;
            for (int i = 0; i < _giocatori.Length; i++) 
            {
                if (_giocatori[i].ritornaPunteggioTotale() >max)
                {
                    max = _giocatori[i].ritornaPunteggioTotale();
                }

            }
            int posizioneAttuale = 0;

            for(int i = 0;i < _numeroPartite;i++)
            {
                if (max == _giocatori[i].ritornaPunteggioTotale())
                {
                    listaNomi[posizioneAttuale] = _giocatori[i].Nome;
                    posizioneAttuale++;
                }
            }

            return listaNomi;
        }

        public int? RicercaPartitaPerPunteggio(int posizioneGiocatore,int punteggio)
        {
            if (posizioneGiocatore < 1 || posizioneGiocatore > _giocatori.Length) { throw new ArgumentOutOfRangeException("posizione giocatore illegale"); }
            if (punteggio < 1 || punteggio > 100) { throw new ArgumentOutOfRangeException("punteggio illegale"); }

            return _giocatori[posizioneGiocatore-1].RicercaPartitaPerPunteggio(punteggio);
        }


    }
}
