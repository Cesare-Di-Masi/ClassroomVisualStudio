using StatistisDiceLib;
using System.Security.Cryptography.X509Certificates;
class Program
{
    static void Main(string[] args)
    {
        

        Console.WriteLine("put the N of games you desire >0");
        int nGames = int.Parse( Console.ReadLine());
        Console.WriteLine("write the n of throws for every game");
        int nLaunchXGame = int.Parse( Console.ReadLine());

        int[] score = new int[nLaunchXGame];
        Player player1 = new Player(score);
        Player player2 = new Player(score);

        Game[] games = new Game[nGames];

        for (int i = 0; i < nGames; i++) 
        {
            games[i] = new Game(player1,player2);
        }

        for(int i =0; i < nGames; i++)
        {
            games[i].Play();
        }

        Console.WriteLine("frequency of what number");
        int wanted = int.Parse(Console.ReadLine());

        int frequence = 0;

        for (int i = 0;i < nGames; i++)
        {
            frequence = games[i].TotFrequence(wanted);
        }

        Console.WriteLine(frequence);

    }

}
