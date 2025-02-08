using System.Security.Cryptography.X509Certificates;
using VERIFICA_NOVEMBRE_DIMASI;

class Program
{

    static void Main(string[] args)
    {


        Session s1 = new Session(2, 12, 34, false);
        Session s2 = new Session(5, 12, 34, true);
        Session s3 = new Session(4, 48, 54, true);
        Session s4 = new Session(1, 56, 51, false);
       

        Athlete a1 = new Athlete(53324, "John", s2, s1);
        Athlete a2 = new Athlete(13124, "Arnold", s3, s4);

        if (a1.getBestIntensiveSessionMinutes() > a2.getBestIntensiveSessionMinutes())
        {
            Console.WriteLine("The winner is John");
        }
        else if (a1.getBestIntensiveSessionMinutes() < a2.getBestIntensiveSessionMinutes())
        {
            Console.WriteLine("The winner is Arnold");
        }
        else
        {
            //nel caso le sessioni abbiano lo stesso tempo si riscontrerà un pareggio
            Console.WriteLine("tie");
        }

        if(a1.getBestStandardSessionMinutes() < a2.getBestStandardSessionMinutes())
        {
            Console.WriteLine("true");
        }
        else
        {
            Console.WriteLine("false");
        }

        if(a1.BestIntensive.Equals(a2.BestIntensive) && a1.BestIntensive.Equals(a2.BestIntensive))
        {
            Console.WriteLine("true");
        }else
        {

        Console.WriteLine("false"); 
        }
    
    
    }



}

