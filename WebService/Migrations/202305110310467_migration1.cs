namespace WebService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Alumnoes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        GrupoID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Grupoes", t => t.GrupoID, cascadeDelete: true)
                .Index(t => t.GrupoID);
            
            CreateTable(
                "dbo.Grupoes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Alumnoes", "GrupoID", "dbo.Grupoes");
            DropIndex("dbo.Alumnoes", new[] { "GrupoID" });
            DropTable("dbo.Grupoes");
            DropTable("dbo.Alumnoes");
        }
    }
}
