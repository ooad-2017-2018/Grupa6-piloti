using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Status
    {
        [ScaffoldColumn(false)]
        public int StatusId { get; set; }
        [Required(ErrorMessage = "Polje naziva statusa je obavezno")]
        [Display(Name ="Status")]
        public string Naziv { get; set; }

        public virtual ICollection<Let> Letovi { get; set; }
    }
}