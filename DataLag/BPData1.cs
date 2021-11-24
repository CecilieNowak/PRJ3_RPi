using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using DTO;
using System.Collections.Concurrent;
using RaspberryPiNetCore.ADC;


 namespace DataLag
{
    public class BPData1
    {

        private ADC1015 aDC; 

        private readonly BlockingCollection<DTO_BPressure> _dataQueue;
        


        public BPData1(BlockingCollection<DTO_BPressure> dataQueue)
        {
            
            _dataQueue = dataQueue;
            aDC = new ADC1015(72, 512);   
        }


        public void Run()
        {

            while (true)
            {

                DTO_BPressure reading = new DTO_BPressure();
                reading.Værdi = Convert.ToDouble(0); //Skal ændres
                _dataQueue.Add(reading);
                Thread.Sleep(10); //tiden mellem hvert DTO_objekt der oprettes

            }


        }






    }
}
