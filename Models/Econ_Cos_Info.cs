using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StateApp.Models
{
    public class Econ_Cos_Info
    {
        public int EI_ID { get; set; }
        public virtual Country_World EI_Name { get; set; }
        public virtual Goverment EI_Gov { get; set; }
        public int EI_VVP { get; set; }
        public int EI_Life { get; set; }
        public int EI_Inflation { get; set; }
    }
}
