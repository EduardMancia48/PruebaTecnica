using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using AppDC_Deras.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppDC_Deras.Data
{
    public class ApplicationDbContext : DbContext
    {
        // Usa la cadena de conexión llamada "DefaultConnection" en Web.config
        public ApplicationDbContext() : base("DefaultConnection")
        {
            // Crea la base de datos si no existe
            Database.SetInitializer(new CreateDatabaseIfNotExists<ApplicationDbContext>());
        }

        // Agrega los DbSet de modelos
        public DbSet<Reclamo> Reclamos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        

            // Configuración específica para el modelo Reclamo
            modelBuilder.Entity<Reclamo>()
                .Property(r => r.FechaIngreso)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed)
                .HasColumnType("datetime");

            modelBuilder.Entity<Reclamo>()
                .HasIndex(r => r.DUI)
                .IsUnique()
                .HasName("IX_DUI");

            base.OnModelCreating(modelBuilder);
        }

        // Método estático para crear instancias fácilmente
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
