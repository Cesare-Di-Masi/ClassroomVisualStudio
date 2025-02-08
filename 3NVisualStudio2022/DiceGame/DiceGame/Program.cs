namespace DiceGame 
{


    internal class Program
    {


        static void Main(string[] args)
        {

            Player p1 = new Player("player1");
            Player p2 = new Player("player2");

            Dice dice = new Dice(6);

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
    }

}