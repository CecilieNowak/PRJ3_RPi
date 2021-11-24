﻿using System;
using System.Collections.Generic;
using System.Text;
using RaspberryPiNetCore.ADC;
using System.Threading;
using DTO;
using System.Collections.Concurrent;

namespace DataAccessLayer
{





    public class BPData
    {

        private ADC
        private readonly BlockingCollection<DTO_BPressure> _dataQueue;
        //private List<DTO_BPressure> blodtryklist;


        public BPData(BlockingCollection<DTO_BPressure> dataQueue)
        {
            //blodtryklist = new List<DTO_BPressure> { };
            _dataQueue = dataQueue;
           // aDC = new ADC1015(72, 512);   
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
