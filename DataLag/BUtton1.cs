using System;
using System.Collections.Generic;
using System.Device.Gpio;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataLag
{
    class BUtton1
    {

        public GpioController Controller { get; set; }
        public bool StartIsPressed { get; set; }

        public BUtton1()
        {

            Controller = new GpioController();
            Controller.OpenPin(17, PinMode.InputPullUp);
            StartIsPressed = true;

        }


        public bool IsPressed()
        {


            if (Controller.Read(17) == PinValue.High)
            {
                StartIsPressed = false;

            }
            else if (Controller.Read(17) == PinValue.Low)
            {
                StartIsPressed = true;
            }

            Thread.Sleep(50);
            return StartIsPressed;




        }

    }
}
