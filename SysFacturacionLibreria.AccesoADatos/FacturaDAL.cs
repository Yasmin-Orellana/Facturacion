using Microsoft.EntityFrameworkCore;
using SysFacturacionLibreria.EntidadesDeNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysFacturacionLibreria.AccesoADatos
{
    public class FacturaDAL
    {
        public static async Task<int> CrearAsync(Factura pFactura)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                bdContexto.Add(pFactura);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> ModificarAsync(Factura pFactura)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var Factura = await bdContexto.Factura.FirstOrDefaultAsync(s => s.IdFactura == pFactura.IdFactura);
                Factura.NIT = pFactura.NIT;
                bdContexto.Update(Factura);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> EliminarAsync(Factura pFactura)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var Factura = await bdContexto.Factura.FirstOrDefaultAsync(s => s.IdFactura == pFactura.IdFactura);
                bdContexto.Factura.Remove(Factura);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<Factura> ObtenerPorIdAsync(Factura pFactura)
        {
            var Factura = new Factura();
            using (var bdContexto = new BDContexto())
            {
                Factura = await bdContexto.Factura.FirstOrDefaultAsync(s => s.IdFactura == pFactura.IdFactura);
            }
            return Factura;
        }
        public static async Task<List<Factura>> ObtenerTodosAsync()
        {
            var Facturaes = new List<Factura>();
            using (var bdContexto = new BDContexto())
            {
                Facturaes = await bdContexto.Factura.ToListAsync();
            }
            return Facturaes;
        }
        internal static IQueryable<Factura> QuerySelect(IQueryable<Factura> pQuery, Factura pFactura)
        {
            if (pFactura.IdFactura > 0)
                pQuery = pQuery.Where(s => s.IdFactura == pFactura.IdFactura);
            if (!string.IsNullOrWhiteSpace(pFactura.NIT))
                pQuery = pQuery.Where(s => s.NIT.Contains(pFactura.NIT));
            pQuery = pQuery.OrderByDescending(s => s.IdFactura).AsQueryable();
            if (pFactura.Top_Aux > 0)
                pQuery = pQuery.Take(pFactura.Top_Aux).AsQueryable();
            return pQuery;
        }
        public static async Task<List<Factura>> BuscarAsync(Factura pFactura)
        {
            var Factura = new List<Factura>();
            using (var bdContexto = new BDContexto())
            {
                var select = bdContexto.Factura.AsQueryable();
                select = QuerySelect(select, pFactura);
                Factura = await select.ToListAsync();
            }
            return Factura;
        }



    }
}

