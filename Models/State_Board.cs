using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using StateApp.Models;

namespace StateApp.Models
{
    public class State_Board
    {
        public State_Board()
        {
            Countries = new List<Country_World>();
            Goverments = new List<Goverment>();
        }
        public int SD_ID { get; set; }
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [Display(Name = "ДержУправління")]
        public string SD_Name { get; set; }
        [Display(Name = "Інформація про управління")]
        public string SD_Info { get; set; }
        public virtual ICollection<Country_World> Countries { get; set; }
        public virtual ICollection<Goverment> Goverments { get; set; }
    }
}
