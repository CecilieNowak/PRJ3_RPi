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
       


        public BPData(BlockingCollection<DTO_BPressure> dataQueue)
        {
            _dataQueue = dataQueue;
            aDC = new ADC1015(72, 512);   
        }


        public void Run()
        {

            aDC.SamplingsRate = 150;
            aDC.ReadADC_Differential_0_1();

            while (true) 
            {

                DTO_BPressure reading = new DTO_BPressure();
                reading.Værdi = aDC.DIFFERENCE_Measurement[0].Take(); //Skal ændres
                _dataQueue.Add(reading);
                Thread.Sleep(10); //tiden mellem hvert DTO_objekt der oprettes

            }


        

        }

    }
}
