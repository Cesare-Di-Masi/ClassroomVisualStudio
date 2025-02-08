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
                    Console.WriteLine("Insert The X coord");
                    int readX = int.Parse(Console.ReadLine());
                    Console.WriteLine("Insert The Y coord");
                    int readY = int.Parse(Console.ReadLine());
                    bool turn = tris.makeATurn(readX, readY, currentPlayer);
                    moves++;
                    if (turn)
                    {
                        Console.WriteLine($"{(currentPlayer ? "X" : "O")} ha vinto");
                        gameWon = true;
                    }
                    else if(moves==9)
                    {
                        
                        Console.WriteLine("Pareggio");
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


