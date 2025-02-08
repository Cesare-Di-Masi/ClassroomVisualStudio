using SwitchAndLamp;
namespace SwitchAndLampTest
{
    [TestClass]
    public class LampTest
    {
        [TestMethod]
        public void Lamp_WithValidIsOn_UpdateIsOn_True() 
        {
            Lamp lamp = new Lamp(true);
            bool expected = true;
            bool actual = lamp.IsOn;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Lamp_WithValidIsOn_UpdateIsOn_False()
        {
            Lamp lamp = new Lamp(false);
            bool expected = false;
            bool actual = lamp.IsOn;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Lamp_WithValidIsBroken_UpdateIsBroken_False()
        {
            Lamp lamp = new Lamp(true, false);
            bool expected = false;
            bool actual = lamp.IsBroken;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Lamp_WithValidIsBroken_UpdateIsBroken_true()
        {
            Lamp lamp = new Lamp(false, true);
            bool expected = true;
            bool actual = lamp.IsBroken;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Lamp_WithInvalidState_ShouldThrow() 
        {
            Assert.ThrowsException<ArgumentException>(() => { Lamp lamp = new Lamp(true, true,1); });

        }

        [TestMethod]
        public void Lamp_WithInvalidLeftClicks_ShouldThrow()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => { Lamp lamp = new Lamp(true, false, -1); });
        }

        [TestMethod]
        public void Click_WithValidState_UpdateLeftClicks()
        {
            Lamp lamp = new Lamp();
            lamp.Click();
            int expected = 9;
            int actual = lamp.LeftClicks;
            Assert.AreEqual(expected, actual);
        }

    }
}