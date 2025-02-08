using CoreLibrary;
namespace DemoProgettoCompleto
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("************** GIOCO INDOVINA IL NUMERO **************");
            Console.WriteLine("Hai 10 tentativi per indovinare un numero compreso tra 1 e 999");
            Game game = new Game(10);

            while(game.Status == GameStatus.IN_PROGRESS)
            {
                try
                {
                    Console.WriteLine($"Hai {game.RemainingAttempts} tentativi a disposizione.");
                    Console.WriteLine("Inserisci il tuo tentativo");
                    int attempts = int.Parse(Console.ReadLine());
                    game.Attempts(attempts);
                } catch(Exception ex) 
                { 
                    Console.WriteLine(ex.Message); 
                }
            }

            if(game.Status == GameStatus.LOSE)
            {
                Console.WriteLine("Mi spiace hai Perso!");
            }
            else
            {
                Console.WriteLine("Complimenti hai vinto!!!");
            }
        }
    }
}
