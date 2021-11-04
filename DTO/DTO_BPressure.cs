using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_BPressure
    {
        public int systolic { get; set; }
        public int diastolic { get; set; }

        public DTO_BPressure(int systolic, int diastolic)
        {
            this.systolic = systolic;
            this.diastolic = diastolic;
        }
    }
}
