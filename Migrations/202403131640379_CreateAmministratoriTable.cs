namespace EpInForno.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateAmministratoriTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AmministratoreModels",
                c => new
                    {
                        IdAmministratore = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        Cognome = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.IdAmministratore);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AmministratoreModels");
        }
    }
}
