using Geometria;
namespace TestGeometria
{
    [TestClass]
    public class TestPoint
    {
        [TestMethod]
        public void MoveXCoord_ValidXCoord_UpdatesX(double x=5)
        {
            Point point = new Point();
            point.MoveXCoord(x);

            double expected = x;
            double actual = point.X;

            Assert.AreEqual(expected, actual, 0.0001);
        }

        [TestMethod]
        public void MoveYCoord_ValidYCoord_UpdatesY(double y=5)
        {
            Point point = new Point();
            point.MoveYCoords(y);

            double expected = y;
            double actual = point.Y;

            Assert.AreEqual(expected, actual, 0.0001);
        }


        [TestMethod]
        public void MoveXYCoord_PositiveXPositiveYValidXYCoord_UpdatesXY()
        {
            MoveXCoord_ValidXCoord_UpdatesX(8);
            MoveYCoord_ValidYCoord_UpdatesY(8);
        }

        [TestMethod]
        public void Equals_SamePointsCoords_ReturnTrue()
        {
            Point point1 = new Point();
            Point point2 = new Point();
            Assert.AreEqual(true, point1.Equals(point2));
        }

        [TestMethod]
        public void Equals_DifferentPointCoords_ReturnFalse()
        {
            Point point1 = new Point();
            Point point2 = new Point(1,1);
            Assert.AreEqual(false, point1.Equals(point2));
        }
    }
}