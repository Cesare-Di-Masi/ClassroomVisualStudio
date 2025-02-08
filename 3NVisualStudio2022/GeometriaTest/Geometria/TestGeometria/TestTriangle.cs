using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Geometria;

namespace TestGeometria
{
    [TestClass]
    internal class TestTriangle
    {

        [TestMethod]
        public void Triangle_InvalidSidesLenght_ShouldThrow()
        {
            Point point1 = new Point(0,0);
            Point point2 = new Point(1,0);
            Point point3 = new Point(0,6);
         
            Segment segment1 = new Segment(point1, point2);
            Segment segment2 = new Segment(point2, point3);
            Segment segment3 = new Segment(point3, point1);

            Assert.ThrowsException<Exception>((() => { Triangle triangle = new Triangle(segment1, segment2, segment3); }));

        }

        [TestMethod]
        public void Triangle_InvalidSidesPoints_ShouldThrow()
        {
            Point point1 = new Point(0, 0);
            Point point2 = new Point(1, 0);
            Point point3 = new Point(0, 6);

            Segment segment1 = new Segment(point1, point2);
            Segment segment2 = new Segment(point2, point3);
            Segment segment3 = new Segment(point3, point1);

            Assert.ThrowsException<Exception>((() => { Triangle triangle = new Triangle(segment1, segment2, segment3); }));

        }

        [TestMethod]
        public void Perimeter_ValidSides_UpdatePerimeter() 
        {
            Point point1 = new Point(0, 0);
            Point point2 = new Point(1, 0);
            Point point3 = new Point(0, 1);

            Segment segment1 = new Segment(point1, point2);
            Segment segment2 = new Segment(point2, point3);
            Segment segment3 = new Segment(point3, point1);

            Triangle triangle = new Triangle(segment1,segment2, segment3);

            double expected = 3.4;
            double actual=triangle.Perimeter;

            Assert.AreEqual(expected,actual,0.1);
        }

        [TestMethod]
        public void Area_ValidSides_UpdateArea()
        {
            Point point1 = new Point(0, 0);
            Point point2 = new Point(1, 0);
            Point point3 = new Point(0, 1);

            Segment segment1 = new Segment(point1, point2);
            Segment segment2 = new Segment(point2, point3);
            Segment segment3 = new Segment(point3, point1);

            Triangle triangle = new Triangle(segment1, segment2, segment3);

            double expected = 0.5;
            double actual = triangle.Perimeter;

            Assert.AreEqual(expected, actual,0.1);
        }

        [TestMethod]
        public void MoveXCoords_ValidXCoords_UpdatesX()
        {
            Point point1 = new Point(0, 0);
            Point point2 = new Point(1, 0);
            Point point3 = new Point(0, 1);

            Segment segment1 = new Segment(point1, point2);
            Segment segment2 = new Segment(point2, point3);
            Segment segment3 = new Segment(point3, point1);

            Triangle triangle = new Triangle(segment1, segment2, segment3);

            triangle.MoveXCoords(5);

            double expectedPoint1X = 5;
            double expectedPoint2X = 6;
            double expectedPoint3X = 5;

            double actualPoint1X = triangle.Side1.StartPoint.X;
            double actualPoint2X = triangle.Side2.StartPoint.X;
            double actualPoint3X = triangle.Side3.StartPoint.X;

            Assert.Equals(expectedPoint1X, actualPoint1X);
            Assert.Equals(expectedPoint2X, actualPoint2X);
            Assert.Equals(expectedPoint3X, actualPoint3X);
        }

        [TestMethod]
        public void MoveYCoords_ValidYCoords_UpdatesY()
        {
            Point point1 = new Point(0, 0);
            Point point2 = new Point(1, 0);
            Point point3 = new Point(0, 1);

            Segment segment1 = new Segment(point1, point2);
            Segment segment2 = new Segment(point2, point3);
            Segment segment3 = new Segment(point3, point1);

            Triangle triangle = new Triangle(segment1, segment2, segment3);

            triangle.MoveYCoords(5);

            double expectedPoint1Y = 5;
            double expectedPoint2Y = 5;
            double expectedPoint3Y = 6;

            double actualPoint1Y = triangle.Side1.StartPoint.Y;
            double actualPoint2Y = triangle.Side2.StartPoint.Y;
            double actualPoint3Y = triangle.Side3.StartPoint.Y;

            Assert.Equals(expectedPoint1Y, actualPoint1Y);
            Assert.Equals(expectedPoint2Y, actualPoint2Y);
            Assert.Equals(expectedPoint3Y, actualPoint3Y);
        }

        [TestMethod]
        public void MoveXYCoords_ValidXYCoords_UpdatedXY()
        {
            MoveXCoords_ValidXCoords_UpdatesX();
            MoveYCoords_ValidYCoords_UpdatesY();
        }

    }
}
