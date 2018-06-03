using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Putnik
    {
        [ScaffoldColumn(false)]
        public int PutnikId { get; set; }
        [Required (ErrorMessage = "Polje ime je obavezno")]
        public string Ime { get; set; }
        [Required(ErrorMessage = "Polje prezime je obavezno")]
        public string Prezime { get; set; }
        [Required(ErrorMessage = "Polje datum rodjenja je obavezno")]
        public DateTime DatumRodjenja { get; set; }
        [Required(ErrorMessage = "Polje Email je obavezno")]
        public string Email { get; set; }

        public virtual ICollection<Karta> Karte { get; set; }
    }
}