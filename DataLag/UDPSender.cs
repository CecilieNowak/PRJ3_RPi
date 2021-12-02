using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using DTO;
using System.Text.Json;
using System.Collections.Concurrent;
using System.Threading;


namespace DataLag
{
    public class UDPSender
    {
        private const int listenPortCommand = 11000;
        private readonly BlockingCollection<DTO_BPressure> _dataQueue;
        private byte[] jsonUtf8Bytes;
        private NulPunktJusteringVærdi værdi;
        

        public UDPSender(BlockingCollection<DTO_BPressure> dataQueue)
        {
            _dataQueue = dataQueue;
            værdi = new NulPunktJusteringVærdi();
        }

        public void SendData()
        {
            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPAddress broadcast = IPAddress.Parse("192.168.19.44");                                             
            IPEndPoint ep = new IPEndPoint(broadcast, listenPortCommand);
            værdi.AvgNulpunktVærdi();

            while (!_dataQueue.IsCompleted)
            {
                try
                {
                    
                    var container = _dataQueue.Take();
                    container.Værdi = container.Værdi-værdi.NulPunktVærdi;
                   
                    JsonSerializerOptions sendValue = new JsonSerializerOptions() { WriteIndented = true }; // De her 3 linjer har den opgave at oversætte vores blodData objekt til Byte, således at SendTo funktion kan forstår den 
                    jsonUtf8Bytes = JsonSerializer.SerializeToUtf8Bytes(container, sendValue);
                    s.SendTo(jsonUtf8Bytes, ep);
                    Console.WriteLine(container.Værdi); // Her printer den ADC værdier
                }

                catch (InvalidOperationException)
                {

                }
            }
        }
    }
}

