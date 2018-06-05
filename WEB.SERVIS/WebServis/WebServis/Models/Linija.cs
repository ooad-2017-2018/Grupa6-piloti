namespace WebServis.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Linija")]
    public partial class Linija
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Linija()
        {
            Let = new HashSet<Let>();
        }

        public int LinijaId { get; set; }

        public int DanId { get; set; }

        [Required]
        public string VrijemePolaska { get; set; }

        public int AviokompanijaId { get; set; }

        public int DestinacijaId { get; set; }

        public decimal TrajanjeLeta { get; set; }

        public decimal Cijena { get; set; }

        public virtual Aviokompanija Aviokompanija { get; set; }

        public virtual Dan Dan { get; set; }

        public virtual Destinacija Destinacija { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Let> Let { get; set; }
    }
}
