namespace AppDC_Deras.Migrations
{
    using AppDC_Deras.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AppDC_Deras.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AppDC_Deras.Data.ApplicationDbContext context)
        {
            // Evitar duplicados
            if (!context.Reclamos.Any())
            {
                context.Reclamos.AddRange(new List<Reclamo>
        {
            new Reclamo {
                NombreProveedor = "Supermercado Don Juan",
                DireccionProveedor = "Calle El Progreso #12",
                NombresConsumidor = "Carlos",
                ApellidosConsumidor = "Mejía",
                DUI = "01234567-8",
                DetalleReclamo = "Producto vencido",
                MontoReclamado = 15.75M,
                Telefono = "71234567",
                FechaIngreso = DateTime.Now
            },
            new Reclamo {
                NombreProveedor = "Farmacia La Vida",
                DireccionProveedor = "Av. Central #45",
                NombresConsumidor = "María",
                ApellidosConsumidor = "López",
                DUI = "12345678-9",
                DetalleReclamo = "Medicamento en mal estado",
                MontoReclamado = 22.00M,
                Telefono = "72223344",
                FechaIngreso = DateTime.Now
            },
            new Reclamo {
                NombreProveedor = "Tienda El Buen Precio",
                DireccionProveedor = "Bo. San Pedro #23",
                NombresConsumidor = "Luis",
                ApellidosConsumidor = "González",
                DUI = "23456789-0",
                DetalleReclamo = "Cobro doble en factura",
                MontoReclamado = 10.50M,
                Telefono = "70112233",
                FechaIngreso = DateTime.Now
            },
            new Reclamo {
                NombreProveedor = "Zapatería Central",
                DireccionProveedor = "Col. Escalón #101",
                NombresConsumidor = "Ana",
                ApellidosConsumidor = "Ramírez",
                DUI = "34567890-1",
                DetalleReclamo = "Zapatos defectuosos",
                MontoReclamado = 30.00M,
                Telefono = "75556677",
                FechaIngreso = DateTime.Now
            },
            new Reclamo {
                NombreProveedor = "ElectroHogar",
                DireccionProveedor = "Zona Rosa #5",
                NombresConsumidor = "Pedro",
                ApellidosConsumidor = "Castillo",
                DUI = "45678901-2",
                DetalleReclamo = "Televisor sin garantía",
                MontoReclamado = 250.99M,
                Telefono = "79998877",
                FechaIngreso = DateTime.Now
            }
        });

                context.SaveChanges();
            }
        }

    }
}
