using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Device.Gpio;
using System.Threading;


namespace PresentationLayer
{
    class Button2
    {


        public GpioController Controller { get; set; }
        public bool StartIsPressed { get; set; }

        public Button2()
        {

            Controller = new GpioController();
            Controller.OpenPin(22, PinMode.InputPullUp);
            StartIsPressed = true;

        }



        public bool IsPressed()
        {


            if (Controller.Read(22) == PinValue.High)
            {
                StartIsPressed = false;


            }
            else if (Controller.Read(22) == PinValue.Low)
            {
                StartIsPressed = true;

            }

            Thread.Sleep(50);

            return StartIsPressed;

        }


    }
}
