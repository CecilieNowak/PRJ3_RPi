using RaspberryPiCore.ADC;
using RaspberryPiCore.JoySticks;
using RaspberryPiCore.LCD;
using RaspberryPiCore.TWIST;
using System;
using DataAccessLayer;
using System.Collections.Concurrent;
using System.Threading;
using DTO;


namespace PresentationLayer
{
    class Program
    {
        
        
        static void Main(string[] args)
        {
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
}
