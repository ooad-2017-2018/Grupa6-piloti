using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Aviokompanija
    {
        [ScaffoldColumn(false)]
        public int AviokompanijaId { get; set; }

        [MaxLength(160)]
        [Required(ErrorMessage = "Naziv aviokompanije je obavezno polje")]
        public string Naziv { get; set; }

        public virtual ICollection<Linija> Linije { get; set; }
    }
}