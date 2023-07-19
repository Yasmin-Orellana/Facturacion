using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysFacturacionLibreria.EntidadesDeNegocio
{
    public class DetalleDeVenta
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdDetalleDeVenta { get; set; }
       
        public int NVenta { get; set; }
        [RegularExpression(@"^\d+(\.\d{1,2})?$")]
        public decimal? Cantidad { get; set; }
        
        [StringLength(60)]
        [Required]
        public string? Descripcion { get; set; }
        
        [RegularExpression(@"^\d+(\.\d{1,2})?$")]
        public decimal? Precio { get; set; }
        
        [DisplayFormat(DataFormatString = "{0:yyy/MM/dd}")]
        public DateTime? Fecha { get; set; }
        
        [RegularExpression(@"^\d+(\.\d{1,2})?$")]
        public decimal? Total { get; set; }
       

        
       
        [NotMapped]
        public int Top_Aux { get; set; }

        

        public ICollection<Factura>? Factura  { get; set; }
        public ICollection<Producto>? Producto { get; set; }






    }
}


//Terminados