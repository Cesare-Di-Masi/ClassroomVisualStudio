namespace VERIFICA_GENNAIO_DIMASI_LIB
{
    public class Distributore
    {
        private Prodotto?[] _scomparti;

        /// <summary>
        /// gli scomparti devono essere modificati solo tramite metodi definiti
        /// proprità di solo get
        /// </summary>
        public Prodotto?[] Scomparti
        {
            get
            {
                return _scomparti;
            }
        }

        public Distributore(Prodotto?[] scomparti)
        {
            _scomparti = scomparti;
        }


        /// <summary>
        /// attraverso il metodo nella classe prodotto possiamo ordinare i prodotti in base al prezzo automaticamente
        /// </summary>
        public void ordinaGliScomparti()
        {
            Array.Sort(_scomparti);
        }


        /// <summary>
        /// dato uno scomparto restituierà il prodotto se lo scomparto è occupato o null se lo scomparto è vuoto 
        /// ho al momento messo null sotto una stringa per uso nel program, i futuro si potrà mettere null come valore
        /// </summary>
        /// <param name="numeroScomparto"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public String? ProdottoInRichiestoScomparto(int numeroScomparto)
        {
            if (numeroScomparto < 1 || numeroScomparto > _scomparti.Length + 1)
                throw new ArgumentOutOfRangeException($"scomparto inesistente. da 1 a + {_scomparti.Length + 1}");

            if (_scomparti[numeroScomparto - 1] == null)
                return "null";

            return _scomparti[numeroScomparto - 1].ToString();
        }


        /// <summary>
        /// va ad aggiungere un prodotto data la posizione dell'array che si vuole occupare
        /// </summary>
        /// <param name="prodotto"></param>
        /// <param name="numeroScomparto"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public void AggiungereProdotto(Prodotto prodotto, int numeroScomparto)
        {
            if (numeroScomparto < 1 || numeroScomparto > _scomparti.Length + 1)
                throw new ArgumentOutOfRangeException($"scomparto inesistente. da 1 a + {_scomparti.Length + 1}");
            if (_scomparti[numeroScomparto - 1] != null)
                throw new ArgumentException($"scomparto già occupato da {_scomparti[numeroScomparto - 1].Nome}");

            _scomparti[numeroScomparto - 1] = prodotto;

        }


        /// <summary>
        /// overload del metodo AggiungereProdotto, in questo caso non è necessario dare la posizione nel distributore 
        /// poichè va ad occupare la prima posizione vuota
        /// </summary>
        /// <param name="prodotto"></param>
        public void AggiungereProdotto(Prodotto prodotto)
        {
            bool inserito = false;
            int contatore = 0;
            while (inserito == false && contatore != _scomparti.Length)
            {
                if (_scomparti[contatore] == null)
                {
                    _scomparti[contatore] = prodotto;
                    inserito = true;
                }
                contatore++;
            }
        }

        
        /// <summary>
        /// restituise il prezzo totale dei prodotti nell'intero distributore
        /// </summary>
        /// <returns></returns>
        public double PrezzoTotaleDeiProdotti()
        {
            double prezzo = 0;

            for (int i = 0; i < _scomparti.Length; i++)
            {
                if (_scomparti[i] != null)
                    prezzo += _scomparti[i].Prezzo;
            }

            return prezzo;
        }



    }
}
