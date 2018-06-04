namespace WebServis.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Karta")]
    public partial class Karta
    {
        public int KartaId { get; set; }

        public int LetId { get; set; }

        public int PutnikId { get; set; }

        public virtual Let Let { get; set; }

        public virtual Putnik Putnik { get; set; }
    }
}
