using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace WebApplication1.Models
{
    public class OOADContext : DbContext
    {
        public OOADContext() : base("DefaultConnection") { }

        public DbSet<Aviokompanija> Aviokompanija { get; set; }
        public DbSet<Dan> Dan { get; set; }
        public DbSet<Destinacija> Destinacija { get; set; }
        public DbSet<Karta> Karta { get; set; }
        public DbSet<Let> Let { get; set; }
        public DbSet<Linija> Linija { get; set; }
        public DbSet<Putnik> Putnik { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Zahtjev> Zahtjev { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}