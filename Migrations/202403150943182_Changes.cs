namespace EpInForno.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Changes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrdineModels", "DettaglioOrdineId", c => c.Int(nullable: false));
            DropColumn("dbo.OrdineModels", "OrdineId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrdineModels", "OrdineId", c => c.Int(nullable: false));
            DropColumn("dbo.OrdineModels", "DettaglioOrdineId");
        }
    }
}
