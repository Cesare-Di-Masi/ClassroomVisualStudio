using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometria
{
    internal class Segmento
    {
        public Punto StartPoint
        {
            get { return StartPoint; }
            set { StartPoint = value; }
        }

        public Punto EndPoint
        {
            get { return EndPoint; }
            set { EndPoint = value; }
        }

        public Segmento(Punto startPoint, Punto endPoint)
        {
            StartPoint = startPoint;
            EndPoint = endPoint;
        }


        public double CalculateLenght()
        {
            double lenght;
            double distanceBetweenXs = Math.Abs(StartPoint.X - EndPoint.X);
            double distanceBetweenYs = Math.Abs(StartPoint.Y - EndPoint.Y);
            lenght= Math.Sqrt(Math.Pow(distanceBetweenXs,2)+ Math.Pow(distanceBetweenYs,2));
            return lenght;
        }

        public void MoveXCoord(double xToMove)
        {
            StartPoint.MoveXCoord(xToMove);
            EndPoint.MoveXCoord(xToMove);
        }

        public void MoveYCoord(double yToMove)
        {
            StartPoint.MoveYCoords(yToMove);
            EndPoint.MoveYCoords(yToMove);
        }

        public void MoveXYCoords(double xToMove, double yToMove)
        {
            MoveXCoord(xToMove);
            MoveYCoord(yToMove);
        }
    }
}
