namespace AppDC_Deras.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CorrigeNombreTablaReclamo : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Reclamoes", newName: "Reclamos");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Reclamos", newName: "Reclamoes");
        }
    }
}
