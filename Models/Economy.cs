using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StateApp.Models
{
    public class Economy
    {
        public Economy()
        {
            Goverments = new List<Goverment>();
        }
        public int EC_ID { get; set; }
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [Display(Name = "Тип економіки")]
        public string EC_Name { get; set; }
        [Display(Name = "Інформація про економіку")]
        public string EC_Info { get; set; }
        public virtual ICollection<Goverment> Goverments { get; set; }
    }
}
