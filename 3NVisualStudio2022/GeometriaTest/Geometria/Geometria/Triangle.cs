using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometria
{
    public class Triangle
    {

        //composizione
        public Segment Side1 { get; private set; }
        public Segment Side2 { get; private set; }
        public Segment Side3 { get; private set; }

        public Triangle(Segment side1, Segment side2, Segment side3)
        {
            double _lenghtSide1 = side1.CalculateLenght();
            double _lenghtSide2 = side2.CalculateLenght();
            double _lenghtSide3 = side3.CalculateLenght();
            //la somma di due lati deve essere maggiore del terzo
            if (_lenghtSide1 + _lenghtSide2 <= _lenghtSide3
                || _lenghtSide1 + _lenghtSide3 <= _lenghtSide2
                || _lenghtSide2 + _lenghtSide3 <= _lenghtSide1)
            {
                throw new ArgumentOutOfRangeException("illegal sides");
            }

            if (side1.EndPoint.X != side2.StartPoint.X || side1.EndPoint.Y != side2.StartPoint.Y ||
                side2.EndPoint.X != side3.StartPoint.X || side2.EndPoint.Y != side3.StartPoint.Y ||
                side3.EndPoint.X != side1.StartPoint.X || side3.EndPoint.Y != side1.StartPoint.Y)
            {
                throw new Exception("Segments do not form a closed triangle");
            }


            Side1 = side1;
            Side2 = side2;
            Side3 = side3;


        }

        //campo calcolato, proprietà di sola lettura
        public double Perimeter
        {
            get
            {
                return Side1.CalculateLenght() + Side2.CalculateLenght() + Side3.CalculateLenght();
            }

        }

        
        public double Area
        {
            //applicate la formula
            get 
            {
                double semi = Perimeter / 2;
                return Math.Sqrt(semi*(semi-Side1.CalculateLenght())*(semi-Side2.CalculateLenght())*(semi-Side3.CalculateLenght()));
            }

        }


        public void MoveXCoords(double xToMove)
        {
            Side1.MoveXCoord(xToMove);
            Side2.MoveXCoord(xToMove);
            Side3.MoveXCoord(xToMove);
        }

        public void MoveYCoords(double yToMove)
        {
            Side1.MoveYCoord(yToMove);
            Side2.MoveYCoord(yToMove);
            Side3.MoveYCoord(yToMove);
        }

        public void MoveXYCoords(double xToMove, double yToMove)
        {
            MoveXCoords(xToMove);
            MoveYCoords(yToMove);
        }

    }
}
