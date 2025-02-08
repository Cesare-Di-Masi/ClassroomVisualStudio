using Ramino;
class Program
{
    static void Main(string[] args)
    {

        Torneo torneo = new Torneo(2, 2);
        torneo.aggiungiPunteggio(1, 1, 50);
        torneo.aggiungiPunteggio(1, 2, 60);
        torneo.aggiungiPunteggio(2, 1, 70);
        torneo.aggiungiPunteggio(2, 2, 30);

        string[] vincitori = torneo.vincitore();

        for (int i = 0; i < vincitori.Length; i++)
        {
            if (vincitori[i]!=null)
                Console.WriteLine(vincitori[i]);
        }

        Console.WriteLine(torneo.RicercaPartitaPerPunteggio(1,60));
    }
}