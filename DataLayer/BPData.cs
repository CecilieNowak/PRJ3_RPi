using System;
using System.Collections.Generic;
using System.Text;
using RaspberryPiCore.ADC;
using DTO;
namespace DataLayer
{
    public class BPData
    {
        private ADC1015 aDC;

        public BPData(ADC1015 adc)
        {
            aDC = adc;
        }


        public List<DTO_BPressure> GetBPressureData()
        {
            List<DTO_BPressure> blodtryk = new List<DTO_BPressure> { }; 
            DTO_BPressure BP= new DTO_BPressure(0);



            BP = new DTO_BPressure(aDC.readADC_Differential_0_1());

            blodtryk.Add(BP);




            return blodtryk;
        }
    }
}
