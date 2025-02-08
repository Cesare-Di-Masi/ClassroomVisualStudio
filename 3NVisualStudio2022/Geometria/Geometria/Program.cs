namespace Geometria
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Point p1 = new Point(1,7);
            //il costruttore di default non è richiamabile perchè ho definito un costruttore con 2 parametri
            Point p2 = new Point(3,7);

            //non sto chiamando il costruttore di default, ma il mio costruttore utilizzando i parametri di default che ho definito
            Point p3 = new Point(4,8);

            //Punto p3 = new Punto(5); ?? 5 è la x o la y???
            Segment s1 = new Segment(p1,p2);
            Segment s2 = new Segment(p2, p3);
            Segment s3 = new Segment(p3,p1);

            Triangle t = new Triangle(s1, s2, s3);

           

        }

    }
}
