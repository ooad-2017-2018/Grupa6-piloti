namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Aviokompanija",
                c => new
                    {
                        AviokompanijaId = c.Int(nullable: false, identity: true),
                        Naziv = c.String(),
                    })
                .PrimaryKey(t => t.AviokompanijaId);
            
            CreateTable(
                "dbo.Linija",
                c => new
                    {
                        LinijaId = c.Int(nullable: false, identity: true),
                        DanId = c.Int(nullable: false),
                        VrijemePolaska = c.DateTime(nullable: false),
                        AviokompanijaId = c.Int(nullable: false),
                        DestinacijaId = c.Int(nullable: false),
                        TrajanjeLeta = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Cijena = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.LinijaId)
                .ForeignKey("dbo.Aviokompanija", t => t.AviokompanijaId, cascadeDelete: true)
                .ForeignKey("dbo.Dan", t => t.DanId, cascadeDelete: true)
                .ForeignKey("dbo.Destinacija", t => t.DestinacijaId, cascadeDelete: true)
                .Index(t => t.DanId)
                .Index(t => t.AviokompanijaId)
                .Index(t => t.DestinacijaId);
            
            CreateTable(
                "dbo.Dan",
                c => new
                    {
                        DanId = c.Int(nullable: false, identity: true),
                        Naziv = c.String(),
                    })
                .PrimaryKey(t => t.DanId);
            
            CreateTable(
                "dbo.Destinacija",
                c => new
                    {
                        DestinacijaId = c.Int(nullable: false, identity: true),
                        Naziv = c.String(),
                    })
                .PrimaryKey(t => t.DestinacijaId);
            
            CreateTable(
                "dbo.Let",
                c => new
                    {
                        LetId = c.Int(nullable: false, identity: true),
                        DatumiVrijeme = c.DateTime(nullable: false),
                        StatusId = c.Int(nullable: false),
                        LinijaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LetId)
                .ForeignKey("dbo.Linija", t => t.LinijaId, cascadeDelete: true)
                .ForeignKey("dbo.Status", t => t.StatusId, cascadeDelete: true)
                .Index(t => t.StatusId)
                .Index(t => t.LinijaId);
            
            CreateTable(
                "dbo.Karta",
                c => new
                    {
                        KartaId = c.Int(nullable: false, identity: true),
                        LetId = c.Int(nullable: false),
                        PutnikId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.KartaId)
                .ForeignKey("dbo.Let", t => t.LetId, cascadeDelete: true)
                .ForeignKey("dbo.Putnik", t => t.PutnikId, cascadeDelete: true)
                .Index(t => t.LetId)
                .Index(t => t.PutnikId);
            
            CreateTable(
                "dbo.Putnik",
                c => new
                    {
                        PutnikId = c.Int(nullable: false, identity: true),
                        Ime = c.String(),
                        Prezime = c.String(),
                        DatumRodjenja = c.DateTime(nullable: false),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.PutnikId);
            
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        StatusId = c.Int(nullable: false, identity: true),
                        Naziv = c.String(),
                    })
                .PrimaryKey(t => t.StatusId);
            
            CreateTable(
                "dbo.Zahtjev",
                c => new
                    {
                        ZahtjevId = c.Int(nullable: false, identity: true),
                        LetId = c.Int(nullable: false),
                        Razlog = c.String(),
                        Obradjen = c.Boolean(nullable: false),
                        Prihvacen = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ZahtjevId)
                .ForeignKey("dbo.Let", t => t.LetId, cascadeDelete: true)
                .Index(t => t.LetId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Zahtjev", "LetId", "dbo.Let");
            DropForeignKey("dbo.Let", "StatusId", "dbo.Status");
            DropForeignKey("dbo.Let", "LinijaId", "dbo.Linija");
            DropForeignKey("dbo.Karta", "PutnikId", "dbo.Putnik");
            DropForeignKey("dbo.Karta", "LetId", "dbo.Let");
            DropForeignKey("dbo.Linija", "DestinacijaId", "dbo.Destinacija");
            DropForeignKey("dbo.Linija", "DanId", "dbo.Dan");
            DropForeignKey("dbo.Linija", "AviokompanijaId", "dbo.Aviokompanija");
            DropIndex("dbo.Zahtjev", new[] { "LetId" });
            DropIndex("dbo.Karta", new[] { "PutnikId" });
            DropIndex("dbo.Karta", new[] { "LetId" });
            DropIndex("dbo.Let", new[] { "LinijaId" });
            DropIndex("dbo.Let", new[] { "StatusId" });
            DropIndex("dbo.Linija", new[] { "DestinacijaId" });
            DropIndex("dbo.Linija", new[] { "AviokompanijaId" });
            DropIndex("dbo.Linija", new[] { "DanId" });
            DropTable("dbo.Zahtjev");
            DropTable("dbo.Status");
            DropTable("dbo.Putnik");
            DropTable("dbo.Karta");
            DropTable("dbo.Let");
            DropTable("dbo.Destinacija");
            DropTable("dbo.Dan");
            DropTable("dbo.Linija");
            DropTable("dbo.Aviokompanija");
        }
    }
}
