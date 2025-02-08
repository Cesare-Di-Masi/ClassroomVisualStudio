using TrisLib;
namespace TrisProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TrisTable tris = new TrisTable();
            bool gameWon = false;
            int moves = 0;
            bool currentPlayer = true;
            while (!gameWon && moves < 9)
            {
                try
                {
                    Console.WriteLine(tris);
                    Console.WriteLine($"It's {(currentPlayer ? "X" : "O")} turn ");
                    Console.WriteLine("Inserire la coordinata della riga");
                    int readX = int.Parse(Console.ReadLine());
                    Console.WriteLine("Insere la coordinata della colonna ");
                    int readY = int.Parse(Console.ReadLine());
                    bool turn = tris.makeATurn(readX, readY, currentPlayer);
                    if (turn)
                    {
                        Console.WriteLine($"{(currentPlayer ? "X" : "O")} ha vinto");
                        gameWon = true;
                    }
                    else
                    {
                        Console.WriteLine("non ha vinto nessuno");
                    }
                    currentPlayer = !currentPlayer;
                }
                catch (Exception e) 
                {
                    Console.WriteLine("riprova, hai sbagliato qualcosa");
                }
                
                
            }
        }
    }
}


/*
 parcheggio cursori 
 
  


 * */
