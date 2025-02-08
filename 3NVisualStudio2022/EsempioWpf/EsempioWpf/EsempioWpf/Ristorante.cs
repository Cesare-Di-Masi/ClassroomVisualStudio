namespace EsempioWpf
{
    public class Ristorante
    {
        private string _nome;
        private int _nCoperti;
        private int _nTavoli;
        private int?[] _prenotazioni;

        public string Nome
        {
            get { return _nome; }
        }

        public int NTavoli
        {
            get { return _nTavoli; }
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException();
                _nTavoli = value;
            }
        }

        private int _tavoliLiberi, _tavoliOccupati;

        public int TavoliLiberi
        {
            get
            {
                return _tavoliLiberi;
            }
        }

        public int TavoliOccupati
        {
            get
            {
                return _tavoliOccupati;
            }
        }

        public int NCoperti
        {
            get
            {
                return _nCoperti;
            }
        }

        public int?[] Prenotazioni
        {
            get
            {
                return _prenotazioni;
            }
        }

        public Ristorante(string nome, int tavoli)
        {
            _nome = nome;
            _nTavoli = tavoli;
            _tavoliLiberi = tavoli;
            _tavoliOccupati = 0;
            _nCoperti = tavoli * 4;
            _prenotazioni = new int?[NTavoli];
        }

        public void prenotaUnTavolo(int nPosti)
        {
            if (nPosti < 0 || nPosti > 4)
                throw new ArgumentOutOfRangeException("superato il limite di posti per tavolo");

            int i = 0;
            bool prenAvvenuta = false;

            do
            {
                if (_prenotazioni[i] == null)
                {
                    _prenotazioni[i] = nPosti;
                    _tavoliLiberi--;
                    _tavoliOccupati++;
                    _nCoperti = 4*_tavoliLiberi;
                    prenAvvenuta = true;
                }
                i++;
            } while (prenAvvenuta == false);
        }

        public override string ToString()
        {
            return _nome.ToUpper() + " numero massimo tavoli: " + _nTavoli;
        }
    }
}