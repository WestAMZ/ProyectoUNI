namespace PAEDUCA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migracion1 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Recintoes", newName: "Recinto");
            RenameTable(name: "dbo.Universidads", newName: "Universidad");
            MoveTable(name: "dbo.Recinto", newSchema: "ESQUEMA2");
            MoveTable(name: "dbo.Universidad", newSchema: "ESQUEMA2");
        }
        
        public override void Down()
        {
            MoveTable(name: "ESQUEMA2.Universidad", newSchema: "dbo");
            MoveTable(name: "ESQUEMA2.Recinto", newSchema: "dbo");
            RenameTable(name: "dbo.Universidad", newName: "Universidads");
            RenameTable(name: "dbo.Recinto", newName: "Recintoes");
        }
    }
}
