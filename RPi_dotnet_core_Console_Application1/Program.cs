using DTO;
using RaspberryPiNetCore.ADC;
using RaspberryPiNetCore.JoySticks;
using RaspberryPiNetCore.LCD;
using RaspberryPiNetCore.TWIST;
using System;
using System.Collections.Concurrent;
using System.Threading;
using DataLag;

namespace PresentationLayer
{
    class Program
    {
        static void Main(string[] args)
        {
            while (!Console.KeyAvailable)
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
}
