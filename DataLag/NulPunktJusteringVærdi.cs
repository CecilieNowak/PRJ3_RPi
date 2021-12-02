using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLag
{
    public class NulPunktJusteringVærdi
    {


        public int NulPunktVærdi { get; set; }


        public void AvgNulpunktVærdi()
        {

            NulPunktVærdi = Convert.ToInt32(BPData.rawVærdier().Average());

        }



    }
}
