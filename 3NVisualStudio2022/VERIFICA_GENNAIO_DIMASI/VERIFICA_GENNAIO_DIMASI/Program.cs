using VERIFICA_GENNAIO_DIMASI_LIB;
namespace VERIFICA_GENNAIO_DIMASI
{
    internal class Program
    {
        static void Main(string[] args)
        {

            

            Prodotto prodotto1 = new Prodotto("coca cola", 1.50);

            Prodotto prodotto2 = new Prodotto("pepsi", 1.80);

            Prodotto prodott3 = new Prodotto("sprite", 1.70);

            Prodotto?[] prodotti = new Prodotto?[6] { prodotto1,prodotto1, prodotto2, null, null,prodotto2 };

            Distributore distributore = new Distributore(prodotti);

            for (int i = 0; i < distributore.Scomparti.Length; i++)
            {
                if (distributore.Scomparti[i] != null)
                    Console.WriteLine(distributore.Scomparti[i]);
                else
                    Console.WriteLine("null");
            }
            Console.WriteLine(" ");

            Console.WriteLine(distributore.ProdottoInRichiestoScomparto(1));
            Console.WriteLine(distributore.PrezzoTotaleDeiProdotti());

            //provo ad aggiungere un nuovo oggetto senza definire lo slot nel distributore

            Prodotto prodotto4 = new Prodotto("Dottore Pepper", 2);

            Console.WriteLine(" ");

            distributore.AggiungereProdotto(prodotto4);


            for (int i = 0; i < distributore.Scomparti.Length; i++)
            {
                if (distributore.Scomparti[i] != null)
                    Console.WriteLine(distributore.Scomparti[i]);
                else
                    Console.WriteLine("null");
            }
            Console.WriteLine(" ");

            Console.WriteLine(distributore.ProdottoInRichiestoScomparto(6));
            Console.WriteLine(distributore.PrezzoTotaleDeiProdotti());

            //fine codice

        }
    }
}
