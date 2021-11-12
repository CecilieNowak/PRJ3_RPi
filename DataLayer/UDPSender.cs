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
        private BPData blod;
        private List<DTO_BPressure> blodtryklist;
        private byte[] jsonUtf8Bytes;

        public UDPSender()
        {
            blod = new BPData();
            blodtryklist = new List<DTO_BPressure> { }; 
            
        }
   
   

        public void SendData()
        {
            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPAddress broadcast = IPAddress.Parse("192.168.1.117");                                              // opsætning af UDPSender protokol
            IPEndPoint ep = new IPEndPoint(broadcast, 12000);
           
            DTO_BPressure blodData1 = new DTO_BPressure(0);

            blodtryklist= blod.GetBPressureData();
          

            while (true)
            {
                
                try
                {
                   foreach (var blodData in blodtryklist)
                   {

                    blodData1 = blodData;
                    JsonSerializerOptions sendValue = new JsonSerializerOptions() { WriteIndented = true }; // De her 3 linjer har den opgave at oversætte vores blodData objekt til Byte, således at SendTo funktion kan forstår den 
                    jsonUtf8Bytes = JsonSerializer.SerializeToUtf8Bytes(blodData1, sendValue);

                   }

                }
                catch (InvalidOperationException)
                {

                 
                }

            }


        }
      

    }
}
