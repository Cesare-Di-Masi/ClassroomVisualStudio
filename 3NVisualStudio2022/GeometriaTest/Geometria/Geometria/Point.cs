using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Geometria
{
    public class Point
    {
        //proprietà per x e y
        public double X { get; private set; }
        public double Y { get; private set; }

        //il costruttore si aspetta 2 parametri double, se non viene definito un valore per il parametro viene asseganto 0
        //valore di default x=0
        public Point(double x = 0, double y = 0)
        {
            X = x;
            Y = y;
        }

        public void MoveXCoord(double xToMove)
        {
            X += xToMove;
        }

        public void MoveYCoords(double yToMove)
        {
            Y += yToMove;
        }

        public void MoveXYCoords(double xToMove, double yToMove)
        {
            MoveXCoord(xToMove);
            MoveYCoords(yToMove);

        }

        //sovrascriviamo il comportamento del metodo Equals
        //quando verrà richiamato Equals su un oggetto di tipo Point verrà eseguito questo comportamento 
        //polimorfismo dinamico (la chiamata è la stessa, il comportamento è diverso a seconda dell'oggetto su cui viene richiamato)

        //se ho la chiamata point1.Equals(point2) quando sono dentro al metodo obj è point2
        //mentre l'oggettos u cui richiamo il metodo è point1 quindi se faccio riferimento ad una proprietà 
        //mi riferisco ad una prorpietà di point1
        //qui if(X == punto.X && Y == punto.Y) return true;
        //X è la x di point1
        //punto.X è la x di point2
        public override bool Equals(object? obj)
        {
            //verficio se quello che mi arriva null
            if (obj == null) return false;
            //verifico che il dato che mi arriva sia di tipo Punto
            if (obj is Point == false) return false;

            //se il dato che mi arriva è di tipo punto verifico che gli stati siano uguali (siano uguali le coordinate)
            Point punto = obj as Point; //trasformo obj in un oggetto di tipo Punto
            if (X == punto.X && Y == punto.Y) return true;
            return false;
        }

    }
}
