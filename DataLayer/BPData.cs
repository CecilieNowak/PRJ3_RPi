using System;
using System.Collections.Generic;
using System.Text;
using RaspberryPiCore.ADC;
using DTO;

namespace DataAccessLayer
{
    public class BPData
    {
        private ADC1015 aDC;
       

        public BPData()
        {
           
        }


        public List<DTO_BPressure> GetBPressureData()
        {
            List<DTO_BPressure> blodtryk = new List<DTO_BPressure> { }; 
            DTO_BPressure BP= new DTO_BPressure(0);

            while (true) // (så længe vi får værdier fra ADC) 
            {
                BP = new DTO_BPressure(aDC.readADC_Differential_0_1());
                blodtryk.Add(BP);
            }
            
          
            return blodtryk;



        }
    }
}
