namespace EpInForno.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class finalchanges2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DettaglioOrdineModels", "DettaglioOrdineId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DettaglioOrdineModels", "DettaglioOrdineId");
        }
    }
}
