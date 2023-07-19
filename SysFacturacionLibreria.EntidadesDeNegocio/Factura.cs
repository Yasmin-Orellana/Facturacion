using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysFacturacionLibreria.EntidadesDeNegocio
{
    public class Factura
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdFactura { get; set; }
        public int NFactura { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyy/MM/dd}")]
        public DateTime Fecha { get; set; }
        [Required(ErrorMessage = "NIT es obligatorio")]
        [StringLength(15)]
        public string? NIT { get; set; }
        [Required(ErrorMessage = "Direccion es obligatorio ingresarlo")]
        [StringLength(100)]
        public string? Direccion { get; set; }
        [Required (ErrorMessage ="Telefono es obligatorio ingresarlo")]
        [StringLength(9)]
        public string? Telefono { get; set; }
        [StringLength(50)]
        [RegularExpression(@"^\d+(\.\d{1,2})?$")]
        public string? Correo { get; set; }
        [Required]
        public decimal Total { get; set; }

        [NotMapped]
        public int Top_Aux { get; set; }
        public ICollection<DetalleDeVenta>? DetalleDeVentas { get; set; }
        public ICollection<Cliente>? Clientes { get; set; }
    }
}
