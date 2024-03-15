namespace EpInForno.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AggiungiPrezzoTotaleOrdine : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DettaglioOrdineModels", "PrezzoTotaleOrdine", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DettaglioOrdineModels", "PrezzoTotaleOrdine");
        }
    }
}
