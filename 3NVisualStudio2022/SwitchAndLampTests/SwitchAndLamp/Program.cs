using System.Diagnostics.Metrics;

namespace SwitchAndLamp;

class Program
{
    static void Main(string[] args)
    {

        int MAXTIMES = 1000;

        bool brokel1 = false;
        bool brokel2 = false;

        
        
        Random rand = new Random();

        int l1MaxLife = rand.Next(MAXTIMES);
        int l2MaxLife = rand.Next(MAXTIMES);

        int counter = 0;

        Lamp l1 = new Lamp();
        Lamp l2 = new Lamp();

        LightSwitch s1 = new LightSwitch(l1);
        LightSwitch s2 = new LightSwitch(l2);

        do
        {
            s1.Click();
            s1.Click();



            if (l1.IsBroken)
                brokel1 = true;
            else if (l2.IsBroken)
                brokel2 = true;


        } while (brokel1 == false || brokel2 == false);

            

        if (brokel1)
            Console.WriteLine("l1 broke first");
        else
            Console.WriteLine("l2 broke first");

    }   
    
}
