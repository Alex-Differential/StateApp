using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using StateApp.Models;

namespace StateApp.Models
{
    public class Polit_System
    {
        public Polit_System()
        {
            Countries = new List<Country_World>();
        }

        [Key]
        public int PS_ID { get; set; }
        [Required(ErrorMessage ="Поле не повинно бути порожнім")]
        [Display(Name = "Держустрій")]
        public string PS_Name { get; set; }
        [Display(Name = "Інформація про устрій")]
        public string PS_Info { get; set; }
        public virtual ICollection<Country_World> Countries { get; set; }

    }
}
