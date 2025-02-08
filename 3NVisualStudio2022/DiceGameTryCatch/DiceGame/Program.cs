namespace DiceGame 
{


    internal class Program
    {


        static void Main(string[] args)
        {
            try
            {
                bool error;
                Player p1 = new Player("");
                Player p2=new Player("");
                Dice dice = new Dice();
                //blocco di input con controlli
                do {
                    error = false;
                    try
                    {
                        Console.WriteLine("inserire in nome del primo giocatore");
                        string nome = Console.ReadLine();
                        p1 = new Player(nome);

                        Console.WriteLine("inserire in nome del secondo giocatore");
                        nome = Console.ReadLine();
                        p2 = new Player(nome);

                        Console.WriteLine("inserire in tipo di dado (numero di facce)");
                        int facce = int.Parse(Console.ReadLine());
                        dice = new Dice(facce);
                    } catch (Exception e) {
                        error = true;
                    }
                }while(error);

            //se sono qui vuol dire che ho superato i controlli sopra
            
                Game game = new Game(p1, p2, 11, 15, 100);

                Player? winner = game.SimulateGame(dice);

                if (winner != null)
                {
                    Console.WriteLine(winner);
                }
                else
                {
                    Console.WriteLine("tie");
                }
            }
            catch (Exception ex)
            {
                //gestione dell'errore (in questo caso un output)
                Console.WriteLine(ex.ToString());
            }

        }
    }

}