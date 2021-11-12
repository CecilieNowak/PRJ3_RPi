using RaspberryPiCore.ADC;
using RaspberryPiCore.JoySticks;
using RaspberryPiCore.LCD;
using RaspberryPiCore.TWIST;
using System;
using DataAccessLayer;



namespace PresentationLayer
{
    class Program
    {
        static void Main(string[] args)
        {

            BPData DATA = new BPData();

            while (true)
            {
                Console.WriteLine(DATA.GetBPressureData());
                Console.WriteLine("");

            }
           
            


        }
    }
}
