using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Linija
    {

        [ScaffoldColumn(false)]
        public int LinijaId { get; set; }
        [Required]
        [Display(Name ="Dan polazaka")]
        public int DanId { get; set; }
        [Required]
        [Display(Name = "Vrijeme polazaka")]
        public string VrijemePolaska { get; set; }
        [Required]
        [Display(Name = "Aviokompanija koja obavlja letove")]
        public int AviokompanijaId { get; set; }
        [Required]
        [Display(Name = "Destinacija")]
        public int DestinacijaId { get; set; }
        [Required]    
        public decimal TrajanjeLeta { get; set; }
        [Required]       
        public decimal Cijena { get; set; }

        

        public virtual Dan Dan { get; set; }
        public virtual Destinacija Destinacija { get; set; }
        public virtual Aviokompanija Aviokompanija { get; set; }
        public virtual ICollection<Let> Letovi { get; set; }

    }
}