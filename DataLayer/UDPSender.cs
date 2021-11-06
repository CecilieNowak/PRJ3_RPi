using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using RaspberryPiCore.ADC;
using DTO;
using System.Text.Json;

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

            blodData.Systolic = 60;
            blodData.Diastolic = 50;                  // Værdier som skal sendes vha vores UDP sender                                  
            blodData.Pulse = 60;


            while (true)
            {

                try
                {
                    byte[] jsonUtf8Bytes;
                    JsonSerializerOptions sendValue = new JsonSerializerOptions() { WriteIndented = true }; // De her 3 linjer har den opgave at oversætte vores blodData objekt til Byte, således at SendTo funktion kan forstår den  
                    jsonUtf8Bytes = JsonSerializer.SerializeToUtf8Bytes(blodData, sendValue);

                    s.SendTo(jsonUtf8Bytes, ep);   // SendTo funktion kan kun tage imod BYTE, SendTo opgave er at start med at aktivere senderen og at start med at sende data

                    Console.WriteLine("Systolic: " + blodData.Systolic);      // Her er vores Data som skal sendes 
                    Console.WriteLine("diastolic: " + blodData.Diastolic);    // Her er vores Data som skal sendes
                    Console.WriteLine("Pulse:" + blodData.Pulse);             //Her er vores Data som skal sendes 

                }
                catch (InvalidOperationException)
                {

                    
                }

            }






















        }
       

       





  



    }
}
