﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StateApp.Models
{
    public class Econ_Cos_Info
    {
        [Key]
        public int EI_ID { get; set; }
        public int EI_Name { get; set; }
        public virtual Country_World Country_World { get; set; }
        public int EI_Gov { get; set; }
        public virtual Goverment Goverment { get; set; }
        public int EI_VVP { get; set; }
        public int EI_Life { get; set; }
        public int EI_Inflation { get; set; }
    }
}
