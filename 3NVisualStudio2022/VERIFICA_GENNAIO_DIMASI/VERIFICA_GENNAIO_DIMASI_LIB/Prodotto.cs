namespace VERIFICA_GENNAIO_DIMASI_LIB
{
    public class Prodotto : IComparable<Prodotto>
    {

        private string _nome;
        private double _prezzo;

        public String Nome
        {
            get
            {
                return _nome;
            }
            private set
            {
                //controllo che il nome sia un valore effettivo e non un campo vuoto (null) o " "
                if (String.IsNullOrEmpty(value))
                    throw new ArgumentNullException("inserire un valore accettabile nel nome");
                _nome = value;
            }

        }

        public double Prezzo
        {

            get
            {
                return _prezzo;
            }
            private set
            {
                //controllo che il prezzo sia maggiore di 0
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("inserire un prezzo maggiore di 0");
                _prezzo = value;
            }

        }



        public Prodotto(string nome, double prezzo)
        {
            Nome = nome;
            Prezzo = prezzo;
        }



        /// <summary>
        /// modifichiamo il nome 
        /// </summary>
        /// <param name="nuovoNome"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void modificaIlNome(string nuovoNome)
        {
            //controllo che il nome non sia ne null ne " "
            if (String.IsNullOrEmpty(nuovoNome) || nuovoNome == Nome)
                throw new ArgumentNullException("inserire un nome accettabile");
            Nome = nuovoNome;
        }

        /// <summary>
        /// modifichiamo il prezzo
        /// </summary>
        /// <param name="nuovoPrezzo"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void modificaPrezzo(double nuovoPrezzo)
        {
            //controllo che il prezzo non sia ne minore di 0 ne uguale (non avrebbe avuto senso richiamare la funzione se non si avesse voluto modificare il prezzo)
            if (nuovoPrezzo < 0 || nuovoPrezzo == Prezzo)
                throw new ArgumentOutOfRangeException("inserire un prezzo accettabile");
            Prezzo += nuovoPrezzo;
        }




        public override string ToString()
        {
            return Nome + " : " + Prezzo;
        }



        /// <summary>
        /// il metodo compare non va a richiedere un valore di tipo oggetto in generale a solamente un oggetto di tipo prodotto in
        /// maniera da poter riordinare i prodotti all'interno di un array in maniera più semplice
        /// </summary>
        /// <param name="prodotto"></param>
        /// <returns></returns>
        public int CompareTo(Prodotto? prodotto)
        {
            
            //se il prodotto è null noi saremo sempre maggiori
            if (prodotto == null)
                return 1;

            if (Prezzo == prodotto.Prezzo)
            {
                return 0;
            }
            else if (Prezzo > prodotto.Prezzo)
            {
                return 1;
            }
            else
            {
                return -1;
            }

        }
    }
}
