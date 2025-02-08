namespace Ramino
{
    
    public class Giocatore
    {
        public string Nome {  get; set; }
        private int?[] _punteggi;
        

        public int NumeroPartite
        { 
            get
            {
                return _punteggi.Length;
            } 
        }

        public Giocatore(string nome, int partite)
        {
            Nome = nome;
            _punteggi = new int?[partite];
        }

        public void MemorizzaPunteggioPartita(int punteggio, int partita)
        {
            if (punteggio < 0 || punteggio > 100) throw new ArgumentOutOfRangeException("punteggio errato");

            if (partita < 1 || partita > NumeroPartite) throw new ArgumentOutOfRangeException("numero partita errato");

            if (partita > 1 && _punteggi[partita - 2] == null) throw new ArgumentException($"non è possibile salvare il punteggio per la partita {partita} perchè non è ancora stato definito il punteggio della partita {partita - 1}");
            
            if (partita == 1)
                _punteggi[partita - 1] = punteggio;
            else
                _punteggi[partita - 1] = _punteggi[partita - 2] + punteggio;
        }

        public int? ritornaPunteggioTotale()
        {
            if(_punteggi.Last() == null) { throw new ArgumentNullException("non hai terminato le partite"); }

            return _punteggi.Last();
        }

        public int? RicercaPartitaPerPunteggio(int punteggioDaCercare)
        {
            if (punteggioDaCercare < 0 || punteggioDaCercare > 100) throw new ArgumentOutOfRangeException("punteggio errato");

            int inizio = 0;
            int fine = _punteggi.Length - 1;
            int metà = (inizio + fine) / 2;
            bool trovato = false;
            int? valore = null;

            while (trovato == false)
            {
                if(inizio <= fine)
                {
                    if (_punteggi[metà] == punteggioDaCercare)
                    {
                        trovato = true;
                        return metà+1;
                    }
                    else if (_punteggi[metà] < punteggioDaCercare)
                    {
                        inizio = metà + 1;
                        metà = (inizio + fine) / 2;
                    }
                    else
                    {
                        fine = metà - 1;
                        metà = (inizio + fine) / 2;
                    }
                }else
                {
                    return null;
                }

                return null;

            }

        }

    }
}
