using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Zahtjev
    {
        [ScaffoldColumn(false)]
        public int ZahtjevId { get; set; }
        [Required(ErrorMessage = "Polje leta je obavezno")]
        [Display(Name = "Šifra leta")]
        public int LetId { get; set; }
        [Required(ErrorMessage = "Polje razlog je obavezno")]
        [Display(Name = "Razlog odgađanja")]
        public string Razlog { get; set; }
        public bool Obradjen { get; set; }
        public bool Prihvacen { get; set; }

        public virtual Let Let { get; set; }
        
    }
}