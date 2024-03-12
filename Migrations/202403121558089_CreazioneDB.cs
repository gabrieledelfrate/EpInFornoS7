namespace EpInForno.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreazioneDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DettaglioOrdineModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UtenteModelId = c.Int(nullable: false),
                        ArticoloModelId = c.Int(nullable: false),
                        ArticoloModelNome = c.String(),
                        ArticoloModelFoto = c.String(),
                        ArticoloModelPrezzo = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantita = c.Int(nullable: false),
                        PrezzoTotale = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DataOrdine = c.DateTime(nullable: false),
                        IndirizzoSpedizione = c.String(),
                        Note = c.String(),
                        DettaglioOrdineModel_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DettaglioOrdineModels", t => t.DettaglioOrdineModel_Id)
                .Index(t => t.DettaglioOrdineModel_Id);
            
            CreateTable(
                "dbo.OrdineModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrdineId = c.Int(nullable: false),
                        ArticoloModelId = c.Int(nullable: false),
                        StatoOrdine = c.String(),
                        Quantita = c.Int(nullable: false),
                        DettaglioOrdineDataOrdine = c.DateTime(nullable: false),
                        DettaglioOrdinePrezzoTotale = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ArticoloModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Foto = c.String(),
                        Prezzo = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TempoConsegna = c.Int(nullable: false),
                        Ingredienti = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UtenteModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Cognome = c.String(),
                        Telefono = c.String(),
                        Indirizzo = c.String(),
                        Citta = c.String(),
                        Email = c.String(),
                        PasswordUtente = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DettaglioOrdineModels", "DettaglioOrdineModel_Id", "dbo.DettaglioOrdineModels");
            DropIndex("dbo.DettaglioOrdineModels", new[] { "DettaglioOrdineModel_Id" });
            DropTable("dbo.UtenteModels");
            DropTable("dbo.ArticoloModels");
            DropTable("dbo.OrdineModels");
            DropTable("dbo.DettaglioOrdineModels");
        }
    }
}
