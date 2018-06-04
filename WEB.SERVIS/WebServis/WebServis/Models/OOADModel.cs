namespace WebServis.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class OOADModel : DbContext
    {
        public OOADModel()
            : base("name=OOADModel")
        {
        }

        public virtual DbSet<Aviokompanija> Aviokompanija { get; set; }
        public virtual DbSet<Dan> Dan { get; set; }
        public virtual DbSet<Destinacija> Destinacija { get; set; }
        public virtual DbSet<Karta> Karta { get; set; }
        public virtual DbSet<Let> Let { get; set; }
        public virtual DbSet<Linija> Linija { get; set; }
        public virtual DbSet<Putnik> Putnik { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<Zahtjev> Zahtjev { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
