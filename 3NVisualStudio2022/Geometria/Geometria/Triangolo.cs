using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Geometria
{
    internal class Triangolo
    {

        private double _perimeter;
        private double _area;
       

        public Segmento Side1 {  get; set; }
        public Segmento Side2 { get; set; }
        public Segmento Side3 { get; set; }

        public Triangolo(Segmento side1, Segmento side2, Segmento side3)
        {
            _perimeter = 0;
            _area = 0;
            Side1 = side1;
            Side2 = side2;
            Side3 = side3;
            double _lenghtSide1 = Side1.CalculateLenght();
            double _lenghtSide2 = Side2.CalculateLenght();
            double _lenghtSide3 = Side3.CalculateLenght();
            
            if (_lenghtSide1+_lenghtSide2<=_lenghtSide3||_lenghtSide1+_lenghtSide3<=_lenghtSide2||_lenghtSide2+_lenghtSide3<=_lenghtSide1)
            {
                throw new ArgumentOutOfRangeException("illegal sides");
            }                       
           
        }

        public double Perimeter
        {
            get { return _perimeter; }
            private set { _perimeter = value; }
        }

        public double Area
        {   
            get { return _area; }
            private set { _area = value; }
        }

        public double CalculatePerimeter()
        {
            Perimeter= Side1.CalculateLenght()+Side2.CalculateLenght()+Side3.CalculateLenght();
            return Perimeter;
        }

        public double CalculateHeight() 
        {
            double semiPerimeter= Perimeter/2;
            double height = Math.Sqrt(semiPerimeter * (semiPerimeter - Side1.CalculateLenght()) * (semiPerimeter - Side2.CalculateLenght()) * (semiPerimeter - Side3.CalculateLenght()));
            return height;
        }

        public double CalculateArea()
        {
            Area= Side1.CalculateLenght()*CalculateHeight()/2;
            return Area;
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
