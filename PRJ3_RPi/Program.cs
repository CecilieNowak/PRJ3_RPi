using RaspberryPiCore.ADC;
using RaspberryPiCore.JoySticks;
using RaspberryPiCore.LCD;
using RaspberryPiCore.TWIST;
using System;
using System.Collections.Concurrent;
using System.Threading;
using DTO;
using DataLag;
using System.Threading.Tasks;


namespace PresentationLayer
{
    class Program
    {
        
        static void Main(string[] args)
        {

            while (!Console.KeyAvailable)
            {
                BlockingCollection<DTO_BPressure> dataQueue = new BlockingCollection<DTO_BPressure>();


                BPData1 bpData = new BPData1(dataQueue);
                 
                UDPSender udpSender = new UDPSender(dataQueue);

                Thread producerThread = new Thread(bpData.Run);
                Thread consumerThread = new Thread(udpSender.SendData);

                producerThread.Start();
                consumerThread.Start();

                Console.ReadKey();

            }
            
        
      
        }
    }
}
