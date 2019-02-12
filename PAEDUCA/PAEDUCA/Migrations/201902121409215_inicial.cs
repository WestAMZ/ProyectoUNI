namespace PAEDUCA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Recinto",
                c => new
                    {
                        IdRecinto = c.Int(nullable: false, identity: true),
                        IdUniversidad = c.Int(nullable: false),
                        NombreRecinto = c.String(nullable: false, maxLength: 200),
                        Siglas = c.String(),
                    })
                .PrimaryKey(t => t.IdRecinto)
                .ForeignKey("dbo.Universidad", t => t.IdUniversidad, cascadeDelete: true)
                .Index(t => t.IdUniversidad);
            
            CreateTable(
                "dbo.Universidad",
                c => new
                    {
                        IdUniversidad = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 200, unicode: false),
                        Siglas = c.String(),
                        Eslogan = c.String(),
                        Logo = c.Binary(),
                    })
                .PrimaryKey(t => t.IdUniversidad);
            
            CreateTable(
                "dbo.Sede_Facultad",
                c => new
                    {
                        IdSede_Facultad = c.Int(nullable: false, identity: true),
                        NombreSede_Facultad = c.String(nullable: false, maxLength: 200),
                        Tipo = c.String(maxLength: 30),
                        Web = c.String(maxLength: 200),
                        IdRecinto = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdSede_Facultad)
                .ForeignKey("dbo.Recinto", t => t.IdRecinto, cascadeDelete: true)
                .Index(t => t.IdRecinto);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sede_Facultad", "IdRecinto", "dbo.Recinto");
            DropForeignKey("dbo.Recinto", "IdUniversidad", "dbo.Universidad");
            DropIndex("dbo.Sede_Facultad", new[] { "IdRecinto" });
            DropIndex("dbo.Recinto", new[] { "IdUniversidad" });
            DropTable("dbo.Sede_Facultad");
            DropTable("dbo.Universidad");
            DropTable("dbo.Recinto");
        }
    }
}
