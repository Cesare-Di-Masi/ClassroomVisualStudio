using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwitchAndLamp
{
    public class LightSwitch
    {
        public Lamp LightBulb { get; private set; }

        public LightSwitch(Lamp lightBulb) 
        {
            LightBulb = lightBulb;
        }

        
        public void Click() 
        {
            LightBulb.Click();
        }


    }
}
