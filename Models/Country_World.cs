using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StateApp.Models
{
    public class Country_World
    {
        public Country_World()
        {
            Econ_Cos_Infos = new List<Econ_Cos_Info>();
        }
        [Key]
        public int CO_ID { get; set; }
        public string CO_Name { get; set; }
        public string CO_PartWorld { get; set; }
        public int CO_Squere {get; set;}
        public int CO_Population { get; set; }
        public int CO_Polit_SysPS_ID { get; set; }
        public virtual Polit_System CO_Polit_Sys{ get; set; }
        public int CO_State_BoardSD_ID { get; set; }
        public virtual State_Board CO_State_Board { get; set; }
        public virtual ICollection<Econ_Cos_Info> Econ_Cos_Infos { get; set; }
    }
}
