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
        public int værdi { get; set; }

        public DTO_BPressure(int værdi)
        {
            this.værdi=værdi;
            
        }
    }
}
