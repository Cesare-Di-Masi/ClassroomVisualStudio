using GuessTheNumberLib;

internal class Program
{
    private static void Main(string[] args)
    {
        bool error = false;
        bool replay = false;
        int nAttempts = 0;
        int maxNumber = 0;
        Result result = Result.InProgress;

        Console.WriteLine("GUESS THE NUMBER");

        do
        {
            replay = false;
            do
            {
                try
                {
                    error = false;
                    Console.WriteLine("write the number of attempts you would like to have");
                    nAttempts = int.Parse(Console.ReadLine());
                    if (nAttempts < 0)
                        throw new Exception();
                }
                catch (Exception E)
                {
                    Console.WriteLine("something went wrong, attempts must be more than 0 :|");
                    error = true;
                }
            } while (error == true);

            do
            {
                try
                {
                    error = false;
                    Console.WriteLine("write the max number to guess");
                    maxNumber = int.Parse(Console.ReadLine());
                    if (maxNumber < 2)
                        throw new Exception();
                }
                catch (Exception E)
                {
                    Console.WriteLine("something went wrong, the maxNumber must be at least 2 :|");
                    error = true;
                }
            } while (error == true);

            GameManager game = new GameManager(nAttempts, maxNumber);

            int tryNumber = 0;

            do
            {
                do
                {
                    try
                    {
                        error = false;
                        Console.WriteLine($"you have {game.RemainingAttempts} attempts left");
                        Console.WriteLine($"guess a number betwwen 1 and {maxNumber}");

                        tryNumber = int.Parse(Console.ReadLine());

                        if (tryNumber < 0 || tryNumber > maxNumber)
                            throw new Exception();
                    }
                    catch (Exception e)
                    {
                        error = true;
                        Console.WriteLine($"something went wrong. Remember to write betwwen 1 and {maxNumber}");
                    }
                } while (error == true);

                result = game.TryToGuess(tryNumber);

                if (result == Result.InProgress)
                {
                    Console.WriteLine("wrong number");
                }
            } while (result == Result.InProgress);

            if (result == Result.Win)
            {
                Console.WriteLine("You have won :)");
            }
            else
            {
                Console.WriteLine("You have lost :(");
            }

            Console.WriteLine("would you like to play again? (yes/no)");
            string answer = Console.ReadLine();

            if (answer == "yes") ;
            replay = true;
            else
                Console.WriteLine("BYE");
        } while (replay = true);
    }
}