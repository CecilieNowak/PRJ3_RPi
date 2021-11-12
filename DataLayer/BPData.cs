using System;
using System.Collections.Generic;
using System.Text;
using RaspberryPiCore.ADC;
using System.Threading;
using DTO;
using System.Collections.Concurrent;

namespace DataAccessLayer
{
    public class BPData
    {
        private ADC1015 aDC;
        private readonly BlockingCollection<DTO_BPressure> _dataQueue;
        //private List<DTO_BPressure> blodtryklist;


        public BPData(BlockingCollection<DTO_BPressure> dataQueue)
        {
            //blodtryklist = new List<DTO_BPressure> { };
            _dataQueue = dataQueue;
        }


        public void Run()
        {

            while (true) // (så længe vi får værdier fra ADC) 
            {
                DTO_BPressure reading = new DTO_BPressure();
                reading.Værdi = aDC.readADC_Differential_0_1();
                _dataQueue.Add(reading);

                Thread.Sleep(10); //tiden mellem hvert DTO_objekt der oprettes

            }


            



        }

    }
}
