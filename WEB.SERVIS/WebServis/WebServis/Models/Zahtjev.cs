namespace WebServis.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Zahtjev")]
    public partial class Zahtjev
    {
        public int ZahtjevId { get; set; }

        public int LetId { get; set; }

        [Required]
        public string Razlog { get; set; }

        public bool Obradjen { get; set; }

        public bool Prihvacen { get; set; }

        public virtual Let Let { get; set; }
    }
}
