using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwitchAndLamp;
namespace SwitchAndLampTest
{
    [TestClass]
    public class SwitchTest
    {

        [TestMethod]
        public void Click_WithValidState_UpdateLeftClicks()
        {          
            Lamp lamp = new Lamp();
            LightSwitch s = new LightSwitch(lamp);
            s.Click();
            int expected = 9;
            int actual = lamp.LeftClicks;
            Assert.AreEqual(expected, actual);
        }

    }
}
