using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometria
{
    public class Segment
    {
        //composizione --> il segmento è composto da 2 oggetti punto
        public Point StartPoint
        {
            get; private set;
        }

        public Point EndPoint
        {
            get; private set;
        }

        public Segment(Point point1, Point point2)
        {
            if (point1.Equals(point2)) throw new ArgumentException("i punti sono uguali");

            if (point1.X < point2.X)
            {
                StartPoint = point1;
                EndPoint = point2;
            }
            else
            {
                StartPoint = point2;
                EndPoint = point1;
            }
        }


        public double CalculateLenght()
        {
            double lenght;
            double distanceBetweenXs = StartPoint.X - EndPoint.X;
            double distanceBetweenYs = StartPoint.Y - EndPoint.Y;
            lenght = Math.Sqrt(Math.Pow(distanceBetweenXs, 2) + Math.Pow(distanceBetweenYs, 2));
            return lenght;
        }

        public void MoveXCoord(double xToMove)
        {
            StartPoint.MoveXCoord(xToMove); //chiamata al metodo MoveXCoord della classe Punto (perchè lo sto richiamando su un oggetto Punto)
            EndPoint.MoveXCoord(xToMove);
        }

        public void MoveYCoord(double yToMove)
        {
            StartPoint.MoveYCoords(yToMove);
            EndPoint.MoveYCoords(yToMove);
        }

        public void MoveXYCoords(double xToMove, double yToMove)
        {
            MoveXCoord(xToMove);//chiamata al metodo MoveXCoord della classe segmento
            MoveYCoord(yToMove);
        }

    }
}