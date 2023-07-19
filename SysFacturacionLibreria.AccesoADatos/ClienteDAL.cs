using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SysFacturacionLibreria.EntidadesDeNegocio;

namespace SysFacturacionLibreria.AccesoADatos
{
    public class ClienteDAL
    {
        public static async Task<int> CrearAsync(Cliente pCliente)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                bdContexto.Add(pCliente);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> ModificarAsync(Cliente pCliente)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var Cliente = await bdContexto.Cliente.FirstOrDefaultAsync(s => s.IdCliente == pCliente.IdCliente);
                Cliente.Nombre = pCliente.Nombre;
                bdContexto.Update(Cliente);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> EliminarAsync(Cliente pCliente)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var Cliente = await bdContexto.Cliente.FirstOrDefaultAsync(s => s.IdCliente == pCliente.IdCliente);
                bdContexto.Cliente.Remove(Cliente);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<Cliente> ObtenerPorIdAsync(Cliente pCliente)
        {
            var Cliente = new Cliente();
            using (var bdContexto = new BDContexto())
            {
                Cliente = await bdContexto.Cliente.FirstOrDefaultAsync(s => s.IdCliente == pCliente.IdCliente);
            }
            return Cliente;
        }
        public static async Task<List<Cliente>> ObtenerTodosAsync()
        {
            var Clientees = new List<Cliente>();
            using (var bdContexto = new BDContexto())
            {
                Clientees = await bdContexto.Cliente.ToListAsync();
            }
            return Clientees;
        }
        internal static IQueryable<Cliente> QuerySelect(IQueryable<Cliente> pQuery, Cliente pCliente)
        {
            if (pCliente.IdCliente > 0)
                pQuery = pQuery.Where(s => s.IdCliente == pCliente.IdCliente);
            if (!string.IsNullOrWhiteSpace(pCliente.Nombre))
                pQuery = pQuery.Where(s => s.Nombre.Contains(pCliente.Nombre));
            pQuery = pQuery.OrderByDescending(s => s.IdCliente).AsQueryable();
            if (pCliente.Top_Aux > 0)
                pQuery = pQuery.Take(pCliente.Top_Aux).AsQueryable();
            return pQuery;
        }
        public static async Task<List<Cliente>> BuscarAsync(Cliente pCliente)
        {
            var Cliente = new List<Cliente>();
            using (var bdContexto = new BDContexto())
            {
                var select = bdContexto.Cliente.AsQueryable();
                select = QuerySelect(select, pCliente);
                Cliente = await select.ToListAsync();
            }
            return Cliente;
        }

    }
}

//Cambios