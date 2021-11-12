using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using RaspberryPiCore.ADC;
using DTO;
using System.Text.Json;
using RaspberryPiCore.ADC;
using System.Collections.Concurrent;

namespace DataAccessLayer
{
    public class UDPSender
    {
        private const int listenPortCommand = 12000;
        private BPData blod;

        //        private List<DTO_BPressure> blodtryklist;
        private readonly BlockingCollection<DTO_BPressure> _dataQueue;
        private byte[] jsonUtf8Bytes;

        public UDPSender(BlockingCollection<DTO_BPressure> dataQueue)
        {
            _dataQueue = dataQueue;

            // blod = new BPData();
            //blodtryklist = new List<DTO_BPressure> { };

        }



        public void SendData()
        {
            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPAddress broadcast = IPAddress.Parse("192.168.1.117");                                              // opsætning af UDPSender protokol
            IPEndPoint ep = new IPEndPoint(broadcast, 12000);


            while (!_dataQueue.IsCompleted)
            {
                try
                {

                    var container = _dataQueue.Take();
                    

                    JsonSerializerOptions sendValue = new JsonSerializerOptions() { WriteIndented = true }; // De her 3 linjer har den opgave at oversætte vores blodData objekt til Byte, således at SendTo funktion kan forstår den 
                    jsonUtf8Bytes = JsonSerializer.SerializeToUtf8Bytes(container, sendValue);
                    Console.WriteLine("Data sendt");

                }

                catch (InvalidOperationException)
                {


                }

            }







        }
    }
}

