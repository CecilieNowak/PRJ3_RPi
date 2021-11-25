using DTO;
using RaspberryPiNetCore.ADC;
using RaspberryPiNetCore.JoySticks;
using RaspberryPiNetCore.LCD;
using RaspberryPiNetCore.TWIST;
using System;
using System.Collections.Concurrent;
using System.Threading;
using DataLag;
using System.Device.Gpio;

namespace PresentationLayer
{
    class Program
    {
        static void Main(string[] args)
        {

            SerLCD LCD = new SerLCD();


            Button1 button1 = new Button1();
            Button2 button2 = new Button2();

            LCD.lcdClear();
            LCD.lcdSetBackLight(50, 200, 50);
            LCD.lcdPrint("Blodtryksmaaler");
            LCD.lcdGotoXY(0, 1);
            LCD.lcdPrint("1:Start BT maaling");
            LCD.lcdGotoXY(0, 2);
            LCD.lcdPrint("2:Stop måling");

            if (button1.IsPressed()==true)
            {

                while (!Console.KeyAvailable)
                {
                    LCD.lcdGotoXY(0, 3);
                    LCD.lcdPrint("MaaLING I GANG NU ....");


                    BlockingCollection<DTO_BPressure> dataQueue = new BlockingCollection<DTO_BPressure>();


                    BPData bpData = new BPData(dataQueue);
                    UDPSender udpSender = new UDPSender(dataQueue);

                    Thread producerThread = new Thread(bpData.Run);
                    Thread consumerThread = new Thread(udpSender.SendData);

                    producerThread.Start();
                    consumerThread.Start();

                    Console.ReadKey();

                }

            }
            else if (button2.IsPressed()==true)
            {
                LCD.lcdClear();
                LCD.lcdPrint("Måling er stoppet");

            }

         
        }
    }
}
