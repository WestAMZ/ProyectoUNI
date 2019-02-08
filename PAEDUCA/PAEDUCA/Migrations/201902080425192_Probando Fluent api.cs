namespace PAEDUCA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProbandoFluentapi : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Universidad",
                c => new
                    {
                        IdUniversidad = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 100, unicode: false),
                        Logo = c.Binary(),
                    })
                .PrimaryKey(t => t.IdUniversidad);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Universidad");
        }
    }
}
