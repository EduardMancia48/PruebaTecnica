using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace AppDC_Deras.Models
{
    [Table("Reclamos")]
    public class Reclamo
    {
        [Key]
        [Column("idReclamo")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdReclamo { get; set; }

        [Required(ErrorMessage = "El nombre del proveedor es obligatorio")]
        [StringLength(50, ErrorMessage = "El nombre del proveedor no puede exceder 50 caracteres")]
        [Column("nombreProveedor", TypeName = "varchar")]
        [Display(Name = "Nombre del Proveedor")]
        public string NombreProveedor { get; set; }

        [Required(ErrorMessage = "La dirección del proveedor es obligatoria")]
        [StringLength(100, ErrorMessage = "La dirección no puede exceder 100 caracteres")]
        [Column("direccionProveedor", TypeName = "varchar")]
        [Display(Name = "Dirección del Proveedor")]
        public string DireccionProveedor { get; set; }

        [Required(ErrorMessage = "Los nombres del consumidor son obligatorios")]
        [StringLength(50, ErrorMessage = "Los nombres no pueden exceder 50 caracteres")]
        [Column("nombresConsumidor", TypeName = "varchar")]
        [Display(Name = "Nombres del Consumidor")]
        public string NombresConsumidor { get; set; }

        [Required(ErrorMessage = "Los apellidos del consumidor son obligatorios")]
        [StringLength(50, ErrorMessage = "Los apellidos no pueden exceder 50 caracteres")]
        [Column("apellidosConsumidor", TypeName = "varchar")]
        [Display(Name = "Apellidos del Consumidor")]
        public string ApellidosConsumidor { get; set; }

        [Required(ErrorMessage = "El DUI es obligatorio")]
        [StringLength(10, ErrorMessage = "El DUI no puede exceder 10 caracteres")]
        [Column("DUI", TypeName = "varchar")]
        [Display(Name = "DUI")]
        public string DUI { get; set; }


        [Required(ErrorMessage = "El detalle del reclamo es obligatorio")]
        [StringLength(250, ErrorMessage = "El detalle no puede exceder 250 caracteres")]
        [Column("detalleReclamo", TypeName = "varchar")]
        [Display(Name = "Detalle del Reclamo")]
        public string DetalleReclamo { get; set; }



        [Range(0.01, double.MaxValue, ErrorMessage = "El monto debe ser mayor a 0.01")]
        [Column("montoReclamado", TypeName = "decimal")]
        [Display(Name = "Monto Reclamado")]
        public decimal? MontoReclamado { get; set; }
      

        [StringLength(10, ErrorMessage = "El teléfono no puede exceder 10 caracteres")]
        [Column("telefono", TypeName = "varchar")]
        [Display(Name = "Teléfono")]
        public string Telefono { get; set; }


        [Column("fechaIngreso")]
       
        public DateTime FechaIngreso { get; set; }
    }
}