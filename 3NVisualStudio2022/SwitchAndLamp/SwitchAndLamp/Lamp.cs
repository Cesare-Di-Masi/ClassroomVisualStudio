using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwitchAndLamp
{
    public class Lamp
    {
        
        bool _isOn;
        public bool IsOn 
        {
            get 
            {
                return _isOn;
            }
            set 
            {
                if (_isOn && IsBroken) throw new ArgumentException("lamp cannot be on and broken at the same time");
                _isOn = value;
            }
        }
        public bool IsBroken { get; set; }

        private int _leftClicks;
        public int LeftClicks 
        {
            get 
            {
                return _leftClicks;
            } 
            set
            {
                if(value<0) 
                    throw new ArgumentOutOfRangeException("illegal max life");
                _leftClicks = value;
            }
        }

        public Lamp(bool isOn, bool isbroken):this(isOn, isbroken, 10) 
        {
            
        }

        public Lamp(bool isOn=false, bool isBroken = false, int leftClicks=0) 
        {
            IsOn= isOn; 
            IsBroken= isBroken;
            LeftClicks= leftClicks;
        }

        public void Click()
        {
            LeftClicks--;
            if (LeftClicks == 0)
            {
                IsBroken = true;
                IsOn = false;
            }
            else
                IsOn = !IsOn;
        }   

    }
}
