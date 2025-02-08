namespace Geometria
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Punto p1 = new Punto(5, 7);
            
            Punto p2 = new Punto(10,7);

            Punto p3 = new Punto(2,6);

            Punto p4 = new Punto(2,10);

            Punto p5 = new Punto(3,3);

            Punto p6 = new Punto(6,3);


            Segmento s1= new Segmento(p1, p2);
            Segmento s2 = new Segmento(p3, p4);
            Segmento s3 = new Segmento(p5, p6);
            s1.CalculateLenght();

            Triangolo t1= new Triangolo(s1,s2,s3);

            Console.WriteLine(s1.CalculateLenght());
            Console.WriteLine(t1.CalculateArea());
            Console.WriteLine(t1.CalculatePerimeter());

        }
    }
}
