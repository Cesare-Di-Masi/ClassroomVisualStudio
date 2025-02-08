using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwitchAndLamp
{
    public class Switch
    {
        public Lamp LightBulb { get; private set; }

        public Switch(Lamp lightBulb) 
        {
            LightBulb = lightBulb;
        }

        
        public void Click() 
        {
            LightBulb.Click();
        }


    }
}
