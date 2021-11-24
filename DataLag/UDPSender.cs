using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Text.Json;
using System.Collections.Concurrent;
using System.Net;
using System.Net.Sockets;

namespace DataLag
{
    public class UDPSender
    {

        private const int listenPortCommand = 12000;
        private BPData1 blod;

        //        private List<DTO_BPressure> blodtryklist;
        private readonly BlockingCollection<DTO_BPressure> _dataQueue;
        private byte[] jsonUtf8Bytes;

        public UDPSender(BlockingCollection<DTO_BPressure> dataQueue)
        {
            _dataQueue = dataQueue;

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
                    Console.WriteLine(container.Værdi); // Her printer den ADC værdier

                }

                catch (InvalidOperationException)
                {


                }

            }







        }































    }
}
