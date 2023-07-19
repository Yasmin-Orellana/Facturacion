using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SysFacturacionLibreria.EntidadesDeNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace SysFacturacionLibreria.AccesoADatos
{
    public class BDContexto : DbContext
    {
        public DbSet<Rol> Rol { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Proveedor> Proveedor { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<DetalleDeVenta> DetalleDeVenta { get; set; }
        public DbSet<Factura> Factura { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // optionsBuilder.UseSqlServer(@"workstation id=SysLibreria.mssql.somee.com;packet size=4096;user id=Montoya0422_SQLLogin_1;pwd=hildopuwkr;data source=SysLibreria.mssql.somee.com;persist security info=False;initial catalog=SysLibreria;Encrypt=False;TrustServerCertificate=False");
            optionsBuilder.UseSqlServer(@"workstation id = SysLibreria.mssql.somee.com; packet size = 4096; user id = Montoya0422_SQLLogin_1; pwd = hildopuwkr; data source = SysLibreria.mssql.somee.com; persist security info = False; initial catalog = SysLibreria; Encrypt = False; TrustServerCertificate = False");
        }

        //BD contexto termidado s

        //fff
    
    }
}

