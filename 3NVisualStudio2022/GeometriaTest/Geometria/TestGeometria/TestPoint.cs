using Geometria;
namespace TestGeometria
{
    [TestClass]
    public class TestPoint
    {
        [TestMethod]
        public void MoveXCoord_ValidXCoord_UpdatesX()
        {
            Point point = new Point();
            point.MoveXCoord(5);

            double expected = 5;
            double actual = point.X;

            Assert.AreEqual(expected, actual, 0.0001);
        }

        [TestMethod]
        public void MoveYCoord_ValidYCoord_UpdatesY()
        {
            Point point = new Point();
            point.MoveYCoords(5);

            double expected = 5;
            double actual = point.Y;

            Assert.AreEqual(expected, actual, 0.0001);
        }


        [TestMethod]
        public void MoveXYCoord_PositiveXPositiveYValidXYCoord_UpdatesXY()
        {
            MoveXCoord_ValidXCoord_UpdatesX();
            MoveYCoord_ValidYCoord_UpdatesY();
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