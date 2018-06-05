using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Karta
    {
        [ScaffoldColumn(false)]

        public int KartaId { get; set; }
        [Required (ErrorMessage ="Polje šifre leta je obavezno")]
        [Display(Name ="Šifra leta")]
        public int LetId { get; set; }
        [Required(ErrorMessage = "Polje šifre putnika je obavezno")]
        [Display(Name = "Šifra putnika")]
        public int PutnikId { get; set; }

        public virtual Let Let { get; set; }
        public virtual Putnik Putnik { get; set; }
    }
}