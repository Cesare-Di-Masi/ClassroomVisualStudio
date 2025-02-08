namespace CoffeMachine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Machine myMachine --> definisco myMachine come oggetto di tipo Machine
            //myMachine = new Machine(70); --> istanzio un oggetto di tipo Machine richiamanod il costruttore con un parametro intero
            Machine myMachine = new Machine(70);

            //int price = myMachine.PriceInCent;
            //definisco un dato di tipo intero price ed al suo interno
            //salvo il valore restiuito dal get della proprietà PriceInCent
            int price = myMachine.PriceInCent;

            //Console.WriteLine --> è un metodo che mi permette di scrivere output in console
            Console.WriteLine($"il caffe costa {price} centesimi");

            //simulo l'inserimento di 1 euro
            myMachine.AddInsertedCent(100);

            bool coffe = myMachine.MakeCoffe();
            Console.WriteLine(coffe); //visualizza true

            coffe = myMachine.MakeCoffe();
            Console.WriteLine(coffe);//visualizza false perchè non bastano i soldi
            
        }
    }
}
