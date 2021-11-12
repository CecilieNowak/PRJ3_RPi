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
        private List<DTO_BPressure> blodtryklist;


        public BPData()
        {
            blodtryklist = new List<DTO_BPressure> { };
        }
            


        public List<DTO_BPressure> GetBPressureData()   //blocking cole
        {
            
            DTO_BPressure BP= new DTO_BPressure(0);

            for (;;)     // (så længe vi får værdier fra ADC) 
            {
                BP = new DTO_BPressure(aDC.readADC_SingleEnded(0));
                blodtryklist.Add(BP); //blocking col
            }
            

          
            return blodtryklist;



        }

    }
}
