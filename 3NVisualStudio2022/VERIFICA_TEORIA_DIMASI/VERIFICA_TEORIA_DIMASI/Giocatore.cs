namespace VERIFICA_TEORIA_DIMASI
{
    public class Giocatore
    {
        private int _partiteGiocate = 0;

        public int Numero { get; private set; }
        public string Nome { get; set; }
        public DateTime DataIscrizione { get; set; }
        public int PunteggioMassimo { get; set; }

        private List<int> _risultatiPartite = new List<int>(0);
        public int PartiteGiocate { get { return _partiteGiocate; } }

        public List<int> RisultatiPartite { get { return _risultatiPartite; } }


        public Giocatore(string nome, DateTime dataIscrizione, int punteggioMassimo, int numero)
        {
            Numero = numero;
            Nome = nome;
            DataIscrizione = dataIscrizione;
            PunteggioMassimo = punteggioMassimo;
        }

        public void AggiungiPunteggio(int punteggio)
        {
            _risultatiPartite.Add(punteggio);
            _partiteGiocate++;
        }
        public override bool Equals(object? obj)
        {
            if (obj == null || !(obj is Giocatore))
                return false;

            Giocatore giocatore = obj as Giocatore;
            if (giocatore.Numero == Numero && giocatore.Nome == Nome && giocatore.DataIscrizione == DataIscrizione && giocatore.PunteggioMassimo == PunteggioMassimo)
                return true;
            return false;

        }
        

    }


}
