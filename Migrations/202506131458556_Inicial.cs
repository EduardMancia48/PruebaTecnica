namespace AppDC_Deras.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Reclamoes",
                c => new
                    {
                        idReclamo = c.Int(nullable: false, identity: true),
                        nombreProveedor = c.String(nullable: false, maxLength: 50, unicode: false),
                        direccionProveedor = c.String(nullable: false, maxLength: 100, unicode: false),
                        nombresConsumidor = c.String(nullable: false, maxLength: 50, unicode: false),
                        apellidosConsumidor = c.String(nullable: false, maxLength: 50, unicode: false),
                        DUI = c.String(nullable: false, maxLength: 10, unicode: false),
                        detalleReclamo = c.String(nullable: false, maxLength: 250, unicode: false),
                        montoReclamado = c.Decimal(precision: 18, scale: 2),
                        telefono = c.String(maxLength: 10, unicode: false),
                        fechaIngreso = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.idReclamo)
                .Index(t => t.DUI, unique: true);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Reclamoes", new[] { "DUI" });
            DropTable("dbo.Reclamoes");
        }
    }
}
