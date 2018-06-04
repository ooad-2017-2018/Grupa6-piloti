namespace WebServis.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Destinacija")]
    public partial class Destinacija
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Destinacija()
        {
            Linija = new HashSet<Linija>();
        }

        public int DestinacijaId { get; set; }

        [Required]
        [StringLength(160)]
        public string Naziv { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Linija> Linija { get; set; }
    }
}
