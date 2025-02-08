using StruttureDati;
using System.Diagnostics;

namespace ConsoleStruttureDati
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Creazione di un array di 1.000 di interi compresi tra 1e 100000");
            IntArray valoriMille = new IntArray(1000, 0, 100000);
           
            Console.WriteLine("Creazione di un array di 1.000.000 di interi compresi tra 1e 100000");
            IntArray valoriMilione = new IntArray(1000000, 0, 1000000);

            Console.WriteLine("Creazione di un array di 1.000.000.000 di interi compresi tra 1e 100000");
            IntArray valoriMiliardo = new IntArray(1000000, 0, 1000000000);

            Console.WriteLine("------------SEARCH---------------");

            //tiemr per calcolo dei tempi di esecuzione
            Stopwatch watch;
            long elapsedMs;
            Console.WriteLine("ricerca del valore 100 su array da 1000 elementi...");
            //inizio del timer per calcolare il tempo di esecuzione del metodo
            watch = Stopwatch.StartNew();
            int? index1 = valoriMille.Search(100);            
            //stop del timer
            watch.Stop();
            //calcolo del tempo di esecuzione in secondi
            elapsedMs = watch.ElapsedMilliseconds;
            
            Console.WriteLine($"il valore 100 su array da 1000 elementi si trova all'indice {index1}");
            Console.WriteLine($"tempo di esecuzione {elapsedMs} millisecondi");

            Console.WriteLine("---------------------------");

            Console.WriteLine("ricerca del valore 100 su array da 1000000 di elementi...");
            watch = Stopwatch.StartNew();
            int? index2 = valoriMilione.Search(100);
            watch.Stop();
            //calcolo del tempo di esecuzione in secondi
            elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine($"il valore 100 su array da 1000000 elementi si trova all'indice {index2}");
            Console.WriteLine($"tempo di esecuzione {elapsedMs} millisecondi");

            Console.WriteLine("---------------------------");

            Console.WriteLine("ricerca del valore 100 su array da 1000000000 di elementi...");
            watch = Stopwatch.StartNew();
            int? index3 = valoriMiliardo.Search(100);
            watch.Stop();
            //calcolo del tempo di esecuzione in secondi
            elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine($"il valore 100 su array da 1000000000 elementi si trova all'indice {index3}");
            Console.WriteLine($"tempo di esecuzione {elapsedMs} millisecondi");


            Console.WriteLine("------------SORT---------------");
            
            Console.WriteLine("ordinamento array da 1000 elementi con Selection Sort");
            watch = Stopwatch.StartNew();
            valoriMille.SelectionSort();
            watch.Stop();
            //calcolo del tempo di esecuzione in secondi
            elapsedMs = watch.ElapsedMilliseconds;           
            Console.WriteLine($"tempo di esecuzione {elapsedMs} millisecondi");

            Console.WriteLine("---------------------------");
            Console.WriteLine("ordinamento array da 1000000 elementi con Selection Sort");
            watch = Stopwatch.StartNew();
            valoriMilione.SelectionSort();
            watch.Stop();
            //calcolo del tempo di esecuzione in secondi
            elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine($"tempo di esecuzione {elapsedMs} millisecondi");

            Console.WriteLine("---------------------------");
            Console.WriteLine("ordinamento array da 1000000000 elementi con Selection Sort");
            watch = Stopwatch.StartNew();
            valoriMiliardo.SelectionSort();
            watch.Stop();
            //calcolo del tempo di esecuzione in secondi
            elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine($"tempo di esecuzione {elapsedMs} millisecondi");

            Console.WriteLine("---------------------------");

        }
    }
}
