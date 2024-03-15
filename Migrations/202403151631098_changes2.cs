namespace EpInForno.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changes2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DettaglioOrdineModels", "DettaglioOrdineModel_Id", "dbo.DettaglioOrdineModels");
            DropIndex("dbo.DettaglioOrdineModels", new[] { "DettaglioOrdineModel_Id" });
            DropPrimaryKey("dbo.DettaglioOrdineModels");
            AddColumn("dbo.DettaglioOrdineModels", "DettaglioOrdineId", c => c.Int(nullable: false));
            AlterColumn("dbo.DettaglioOrdineModels", "Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.DettaglioOrdineModels", "DettaglioOrdineModel_Id", c => c.String(maxLength: 128));
            AddPrimaryKey("dbo.DettaglioOrdineModels", "Id");
            CreateIndex("dbo.DettaglioOrdineModels", "DettaglioOrdineModel_Id");
            AddForeignKey("dbo.DettaglioOrdineModels", "DettaglioOrdineModel_Id", "dbo.DettaglioOrdineModels", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DettaglioOrdineModels", "DettaglioOrdineModel_Id", "dbo.DettaglioOrdineModels");
            DropIndex("dbo.DettaglioOrdineModels", new[] { "DettaglioOrdineModel_Id" });
            DropPrimaryKey("dbo.DettaglioOrdineModels");
            AlterColumn("dbo.DettaglioOrdineModels", "DettaglioOrdineModel_Id", c => c.Int());
            AlterColumn("dbo.DettaglioOrdineModels", "Id", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.DettaglioOrdineModels", "DettaglioOrdineId");
            AddPrimaryKey("dbo.DettaglioOrdineModels", "Id");
            CreateIndex("dbo.DettaglioOrdineModels", "DettaglioOrdineModel_Id");
            AddForeignKey("dbo.DettaglioOrdineModels", "DettaglioOrdineModel_Id", "dbo.DettaglioOrdineModels", "Id");
        }
    }
}
