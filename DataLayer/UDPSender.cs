using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using RaspberryPiCore.ADC;
using DTO;
using System.Text.Json;
using RaspberryPiCore.ADC;

namespace DataAccessLayer
{
    class UDPSender
    {
        private const int listenPortCommand = 12000;
       


        public void SendData()
        {
            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPAddress broadcast = IPAddress.Parse("192.168.1.117");                                              // opsætning af UDPSender protokol
            IPEndPoint ep = new IPEndPoint(broadcast, 12000);

            DTO_BPressure blodData = new DTO_BPressure(0);

          

            while (true)
            {

                try
                {
                    byte[] jsonUtf8Bytes;
                    JsonSerializerOptions sendValue = new JsonSerializerOptions() { WriteIndented = true }; // De her 3 linjer har den opgave at oversætte vores blodData objekt til Byte, således at SendTo funktion kan forstår den 
                    jsonUtf8Bytes = JsonSerializer.SerializeToUtf8Bytes(blodData, sendValue);
                    
                   
                }
                catch (InvalidOperationException)
                {

                 
                }

            }


        }
      

    }
}
