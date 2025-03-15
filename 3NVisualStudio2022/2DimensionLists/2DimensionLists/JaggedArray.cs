using System;
using System.Linq;

class Athlete
{
    private string firstName;
    private string lastName;
    private int[][] results;

    public Athlete(string firstName, string lastName, int numberOfDisciplines)
    {
        this.firstName = firstName;
        this.lastName = lastName;
        results = new int[numberOfDisciplines][];
        for (int i = 0; i < numberOfDisciplines; i++)
            results[i] = new int[0]; // Initialize as empty array
    }

    public void AddResult(int discipline, int result)
    {
        if (discipline < 1 || discipline > results.Length)
        {
            Console.WriteLine("Invalid discipline.");
            return;
        }

        int index = discipline - 1;
        Array.Resize(ref results[index], results[index].Length + 1);
        results[index][results[index].Length - 1] = result;
    }

    public int BestResultInDiscipline(int discipline)
    {
        if (discipline < 1 || discipline > results.Length || results[discipline - 1].Length == 0)
            return -1; // Indicates no results available

        return results[discipline - 1].Max();
    }

    public int BestOverallResult()
    {
        return results.SelectMany(r => r).DefaultIfEmpty(-1).Max();
    }

    public int TotalResults()
    {
        return results.Sum(r => r.Length);
    }

    public double[] AverageResultsPerDiscipline()
    {
        return results.Select(r => r.Length > 0 ? r.Average() : 0).ToArray();
    }

    public void PrintResults()
    {
        Console.WriteLine($"Athlete: {firstName} {lastName}");
        for (int i = 0; i < results.Length; i++)
        {
            Console.Write($"Discipline {i + 1}: ");
            if (results[i].Length == 0)
                Console.WriteLine("No results yet");
            else
                Console.WriteLine(string.Join(", ", results[i]));
        }
    }
}


