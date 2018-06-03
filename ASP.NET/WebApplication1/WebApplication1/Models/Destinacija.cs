using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Destinacija
    {
        [ScaffoldColumn(false)]
        public int DestinacijaId { get; set; }
        [MaxLength(160)]
        [Required(ErrorMessage = "Naziv destinacije je obavezno polje")]
        public string Naziv { get; set; }

        public virtual ICollection<Linija> Linije { get; set; }
    }
}