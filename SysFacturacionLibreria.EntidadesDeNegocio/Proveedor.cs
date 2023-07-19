using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysFacturacionLibreria.EntidadesDeNegocio
{
    public class Proveedor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdProveedor { get; set; }
        public int? CodProveedor { get; set; }
        [Required]
        [StringLength(15)]
        public string? Nombre { get; set; }
        [Required]
        [StringLength(15, ErrorMessage = "Maximo 15 caracteres")]
        public string? Empresa { get; set; }
        [Required]
        [StringLength(9)]
        public string? Telefono { get; set; }
        [Required]
        [StringLength(60)]
        public string? Descripcion { get; set; }
        [Required]
        [StringLength(100)]
        public string? Direccion { get; set; }
                
        [NotMapped]
        public int Top_Aux { get; set; }


        public ICollection<Producto>? Productos { get; set; }
    }
}
//Notacioness