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
            LCD.lcdPrint("1:Nulpunktsjustering");
            LCD.lcdGotoXY(0, 2);
            LCD.lcdPrint("2:Start BT maaling");



            while (!Console.KeyAvailable)
            {
                bool a = true;
                bool b = true;
                bool c = true;
                bool d = true;

                if (button1.IsPressed())
                {                                           /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    LCD.lcdClear();
                    LCD.lcdSetBackLight(200, 50, 100);
                    LCD.lcdPrint("Nulpunktsjustering");
                    LCD.lcdGotoXY(0, 1);
                    LCD.lcdPrint("Foelg instruktioner");
                    LCD.lcdGotoXY(0, 2);
                    LCD.lcdPrint("1: Bekraeft");
                    LCD.lcdGotoXY(0, 3);
                    LCD.lcdPrint("2: Tilbage");

                                                    

            

                    while (a)                       
                    {
                        if (button2.IsPressed())
                        {
                            LCD.lcdSetBackLight(50, 200, 50);
                            LCD.lcdClear();
                            LCD.lcdPrint("Blodtryksmaaler");
                            LCD.lcdGotoXY(0, 1);
                            LCD.lcdPrint("1:Nulpunktsjustering");
                            LCD.lcdGotoXY(0, 2);
                            LCD.lcdPrint("2:Start BT maaling");

                            break;
                        }
                        else if (button1.IsPressed())                                           // NULPUNKTJUSTERING
                        {
                            LCD.lcdClear();
                            LCD.lcdPrint("Nulpunktsjustering i gang ");
                            LCD.lcdGotoXY(0, 3);
                            LCD.lcdPrint("2:Tilbage");

                            while (c)
                            {
                                if (button2.IsPressed())
                                {
                                    break;
                                }
                            }
                        }

                    }
                }                                     /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                else if (button2.IsPressed())
                {
                    LCD.lcdSetBackLight(50, 50, 200);
                    LCD.lcdClear();
                    LCD.lcdPrint("Blodtryksmaaler");
                    LCD.lcdGotoXY(0, 1);
                    LCD.lcdPrint("Maling i gang.... ");
                    LCD.lcdGotoXY(0, 2);
                    LCD.lcdPrint("1:Stop maaling");
                    LCD.lcdGotoXY(0, 3);
                    LCD.lcdPrint("2:Tilbage");


                    BlockingCollection<DTO_BPressure> dataQueue = new BlockingCollection<DTO_BPressure>();


                    BPData bpData = new BPData(dataQueue);
                    UDPSender udpSender = new UDPSender(dataQueue);

                    Thread producerThread = new Thread(bpData.Run);
                    Thread consumerThread = new Thread(udpSender.SendData);

                    producerThread.Start();
                    consumerThread.Start();


                    while (b)
                    {
                        if (button1.IsPressed())
                        {
                            LCD.lcdClear();
                            LCD.lcdPrint("Maaling er stoppet!");
                            LCD.lcdGotoXY(0, 1);
                            LCD.lcdPrint("2:Tilbage");

                            bpData.button1 = false;
                          

                            while (d)
                            {
                                if (button2.IsPressed())
                                {
                                    break;
                                }

                            }
                        }
                        else if (button2.IsPressed())
                        {
                            LCD.lcdSetBackLight(50, 200, 50);
                            LCD.lcdClear();
                            LCD.lcdPrint("Blodtryksmaaler");
                            LCD.lcdGotoXY(0, 1);
                            LCD.lcdPrint("1:Nulpunktsjustering");
                            LCD.lcdGotoXY(0, 2);
                            LCD.lcdPrint("2:Start BT maaling");
                            break;


                        }

                    }

                }

            }































            
       





        }
    }
}
