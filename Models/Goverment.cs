using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StateApp.Models
{
    public class Goverment
    {
        public Goverment()
        {
            Econ_Cos_Infos = new List<Econ_Cos_Info>();
        }
        [Key]
        public int GV_ID { get; set; }
        public string GV_Name { get; set; }
        public int GV_State_Board { get; set; }
        public virtual State_Board State_Board { get; set; }
        public int  GV_Economy { get; set; }
        public virtual Economy Economy { get; set; }
        public virtual ICollection<Econ_Cos_Info> Econ_Cos_Infos { get; set; }
    }
}
