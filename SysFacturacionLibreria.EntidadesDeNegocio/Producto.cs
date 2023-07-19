using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysFacturacionLibreria.EntidadesDeNegocio
{
    public class Producto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? IdProducto { get; set; }
        [Required(ErrorMessage = "El codigo es obligatorio")]
        [StringLength(10, ErrorMessage = "Maximo 10 caracteres" )]
        public string? Nombre { get; set; }
        [Required(ErrorMessage = "Nombre es obligatorio")]
        [StringLength(15, ErrorMessage = "Maximo 15 caracteres")]
        public string? Descripcion { get; set; }
        [Required]
        [StringLength(60, ErrorMessage = "Maximo 60 caracteres")]
        //Notacion para 2 decimal

        [RegularExpression(@"^\d+(\.\d{1,2})?$")]
        public decimal? Precio { get; set; }
        [Required(ErrorMessage = "Le ase falta el precio")]
                
        public int? Existencia { get; set; }



        [NotMapped]
        public int Top_Aux { get; set; }

        [ForeignKey("Producto")]
        [Required(ErrorMessage = "Pr es obligatorio")]
        [Display(Name = "Producto")]
      

        public ICollection<Categoria>? IdCategoria { get; set; }
        public ICollection<DetalleDeVenta>? DetalleDeVentas { get; set; }
        public ICollection<Proveedor>? IdProveedor { get; set; }




        
        //terminado


       
     

    }
}
