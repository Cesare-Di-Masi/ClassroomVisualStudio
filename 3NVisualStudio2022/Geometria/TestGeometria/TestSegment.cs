using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Geometria;

namespace TestGeometria
{
    [TestClass]
    internal class TestSegment
    {

        [TestMethod]
        public void Segment_InvalidPoints_ShouldThrow()
        {
            Point point1 = new Point();
            Point point2 = new Point();

            Assert.ThrowsException<ArgumentException>(() => { Segment segment = new Segment(point1, point2);});

            }

        [TestMethod]
        public void MoveXCoord_ValidXCoord_UpdatesX()
        {
            Point point1 = new Point();
            Point point2 = new Point(5, 5);
            Segment segment = new Segment(point1, point2);

            segment.MoveXCoord(5);

            double expectedStartPoint = 5;
            double expectedEndPoint = 10;
                
            double actualStartPoint = segment.StartPoint.X;
            double actualEndPoint = segment.EndPoint.X;

            Assert.AreEqual(expectedStartPoint, actualStartPoint);
            Assert.AreEqual(expectedEndPoint, actualEndPoint);
        }

        [TestMethod]
        public void MoveYCoord_ValidYCoord_UpdatesX()
        {
            Point point1 = new Point();
            Point point2 = new Point(5, 5);
            Segment segment = new Segment(point1, point2);

            segment.MoveYCoord(5);

            double expectedStartPoint = 5;
            double expectedEndPoint = 10;

            double actualStartPoint = segment.StartPoint.Y;
            double actualEndPoint = segment.EndPoint.Y;

            Assert.AreEqual(expectedStartPoint, actualStartPoint);
            Assert.AreEqual(expectedEndPoint, actualEndPoint);
        }

        

        [TestMethod]
        public void MoveXYCoord_ValidXYCoord_UpdatesXY()
        {
            MoveXCoord_ValidXCoord_UpdatesX();
            MoveYCoord_ValidYCoord_UpdatesX();
        }


        [TestMethod]
        public void CalculateLenght_ValidXYCoord_IsCorrect()
        {
            Point point1 = new Point();
            Point point2 = new Point(3,4);
            Segment segment = new Segment(point1, point2);

            double expected = 5;
            double actual = segment.CalculateLenght();

            Assert.AreEqual(expected, actual);
        }


    }
}
