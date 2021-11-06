using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using RaspberryPiCore.ADC;
using DTO;
using System.Text.Json;

namespace DataLayer
{
    class UDPSender
    {
        private const int listenPortCommand = 12000;
        ADC1015 aDC = new ADC1015();

        public void SendData()
        {
            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPAddress broadcast = IPAddress.Parse("192.168.1.117");
            IPEndPoint ep = new IPEndPoint(broadcast, 12000);

            DTO_BPressure blodData = new DTO_BPressure(0);

            blodData.Systolic = 60;
            blodData.Diastolic = 50;
            blodData.Pulse = 60;


            while (true)
            {

                try
                {
                    byte[] jsonUtf8Bytes;
                    JsonSerializerOptions sendValue = new JsonSerializerOptions() { WriteIndented = true };
                    jsonUtf8Bytes = JsonSerializer.SerializeToUtf8Bytes(blodData, sendValue);

                    s.SendTo(jsonUtf8Bytes, ep);   // SendTo funktion kan kun tage imod BYTE

                    Console.WriteLine("Systolic: " + blodData.Systolic);
                    Console.WriteLine("diastolic: " + blodData.Diastolic);
                    Console.WriteLine("Pulse:" + blodData.Pulse);

                }
                catch (InvalidOperationException)
                {

                    
                }

            }






















        }
       

       





  



    }
}
