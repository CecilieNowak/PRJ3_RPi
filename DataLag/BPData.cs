using System;
using System.Collections.Generic;
using System.Text;
using RaspberryPiNetCore.ADC;
using System.Threading;
using DTO;
using System.Collections.Concurrent;

namespace DataLag
{

    public class BPData
    {

        private ADC1015 aDC;
        private readonly BlockingCollection<DTO_BPressure> _dataQueue;
        public bool button1 { set; get;}
       
        


        public BPData(BlockingCollection<DTO_BPressure> dataQueue)
        {
            _dataQueue = dataQueue;
            aDC = new ADC1015(72, 512);
            button1 = true;
        }



        public void Run()
        {
            aDC.SamplingsRate = 150;
            aDC.ReadADC_Differential_0_1();
            aDC.ReadADC_SingleEnded(2);

            while (button1) 
            {
                DTO_BPressure reading = new DTO_BPressure();
                reading.Værdi = aDC.DIFFERENCE_Measurement[0].Take();
                reading.battery = aDC.SINGLE_Measurement[2].Take();
                _dataQueue.Add(reading);
                //Console.WriteLine(reading.Værdi);

               // Thread.Sleep(1000); //tiden mellem hvert DTO_objekt der oprettes

            }
        }



        public static List<int> rawVærdier()
        {
            ADC1015 aDC = new ADC1015(72, 512);
            
            aDC.SamplingsRate = 150;
            aDC.ReadADC_Differential_0_1();

            List<int> samples = new List<int>();

            

            for (int i = 0; i < 150; i++)
            {

                samples.Add(aDC.DIFFERENCE_Measurement[0].Take());

            }

            return samples;



        }







    }

}
