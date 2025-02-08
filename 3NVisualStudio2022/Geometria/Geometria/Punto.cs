using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometria
{
    internal class Punto
    {
        //proprietà per x e y
        public double X { get;  set; }
        public double Y { get;  set; }

        //il costruttore si aspetta 2 parametri double, se non viene definito un valore per il parametro viene asseganto 0
        //valore di default x=0
        public Punto(double x = 0, double y = 0)
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
    }
}
