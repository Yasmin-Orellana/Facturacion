using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysFacturacionLibreria.EntidadesDeNegocio
{
    public class Categoria
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCategoria { get; set; }
        [Required(ErrorMessage = "Rol es obligatorio")]
        [StringLength(30, ErrorMessage = "Maximo 30 caracteres")]

        public string? Nombre { get; set; }
        [Required(ErrorMessage = "Nombre es obligatorio")]
        [StringLength(30, ErrorMessage = "Maximo 30 caracteres")]

        public string? Descripcion { get; set; }
        [Required(ErrorMessage = "Descripcion es obligatorio")]
        [StringLength(60, ErrorMessage = "Maximo 60 caracteres")]
        public string? imagen { get; set; }
        [Required(ErrorMessage = "La imagen es obligatoria")]

        //Lst<> =  desordenada (No Indice)
        //ICollection = Oredenada( Indice)
        [NotMapped]
        public int Top_Aux { get; set; }

        public ICollection<Producto>? Productos { get; set; }

      
    }
}
