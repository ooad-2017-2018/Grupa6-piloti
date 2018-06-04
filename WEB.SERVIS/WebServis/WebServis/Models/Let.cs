namespace WebServis.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Let")]
    public partial class Let
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Let()
        {
            Karta = new HashSet<Karta>();
            Zahtjev = new HashSet<Zahtjev>();
        }

        public int LetId { get; set; }

        public DateTime DatumiVrijeme { get; set; }

        public int StatusId { get; set; }

        public int LinijaId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Karta> Karta { get; set; }

        public virtual Linija Linija { get; set; }

        public virtual Status Status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Zahtjev> Zahtjev { get; set; }
    }
}
