using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Let
    {
       
        public int LetId { get; set; }
        [Required]
        [Display(Name ="Datum i vrijeme polaska")]
        public DateTime DatumiVrijeme { get; set; }
        [Display(Name ="Status leta")]
        public int StatusId { get; set; }
        [Display(Name ="Šifra linije")]
        [Required]
        public int LinijaId { get; set; }

        public virtual Linija Linija { get; set; }
        public virtual Status Status { get; set; }
        public virtual ICollection<Zahtjev> Zahtjevi { get; set; }
        public virtual ICollection<Karta> Karte { get; set; }
    }
}