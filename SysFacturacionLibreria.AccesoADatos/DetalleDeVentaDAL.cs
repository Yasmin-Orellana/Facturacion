using Microsoft.EntityFrameworkCore;
using SysFacturacionLibreria.EntidadesDeNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysFacturacionLibreria.AccesoADatos
{
    public class DetalleDeVentaDAL
    {
        public static async Task<int> CrearAsync(DetalleDeVenta pDetalleDeVenta)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                bdContexto.Add(pDetalleDeVenta);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> ModificarAsync(DetalleDeVenta pDetalleDeVenta)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var DetalleDeVenta = await bdContexto.DetalleDeVenta.FirstOrDefaultAsync(s => s.IdDetalleDeVenta == pDetalleDeVenta.IdDetalleDeVenta);
                DetalleDeVenta.IdDetalleDeVenta = pDetalleDeVenta.IdDetalleDeVenta;
                bdContexto.Update(DetalleDeVenta);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> EliminarAsync(DetalleDeVenta pDetalleDeVenta)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var DetalleDeVenta = await bdContexto.DetalleDeVenta.FirstOrDefaultAsync(s => s.IdDetalleDeVenta == pDetalleDeVenta.IdDetalleDeVenta);
                bdContexto.DetalleDeVenta.Remove(DetalleDeVenta);
                result = await bdContexto.SaveChangesAsync();
            }



            return result;
        }
        public static async Task<DetalleDeVenta> ObtenerPorIdDetalleDeVentaAsync(DetalleDeVenta pDetalleDeVenta)
        {
            var DetalleDeVenta = new DetalleDeVenta();
            using (var bdContexto = new BDContexto())
            {
                DetalleDeVenta = await bdContexto.DetalleDeVenta.FirstOrDefaultAsync(s => s.IdDetalleDeVenta == pDetalleDeVenta.IdDetalleDeVenta);
            }
            return DetalleDeVenta;
        }
        public static async Task<List<DetalleDeVenta>> ObtenerTodosAsync()
        {
            var DetalleDeVentaes = new List<DetalleDeVenta>();
            using (var bdContexto = new BDContexto())
            {
                DetalleDeVentaes = await bdContexto.DetalleDeVenta.ToListAsync();
            }
            return DetalleDeVentaes;
        }
        internal static IQueryable<DetalleDeVenta> QuerySelect(IQueryable<DetalleDeVenta> pQuery, DetalleDeVenta pDetalleDeVenta)
        {
            if (pDetalleDeVenta.IdDetalleDeVenta > 0)
                pQuery = pQuery.Where(s => s.IdDetalleDeVenta == pDetalleDeVenta.IdDetalleDeVenta);
            if (!string.IsNullOrWhiteSpace(pDetalleDeVenta.Descripcion))
                pQuery = pQuery.Where(s => s.Descripcion.Contains(pDetalleDeVenta.Descripcion));
            pQuery = pQuery.OrderByDescending(s => s.IdDetalleDeVenta).AsQueryable();
            if (pDetalleDeVenta.Top_Aux > 0)
                pQuery = pQuery.Take(pDetalleDeVenta.Top_Aux).AsQueryable();
            return pQuery;
        }
        public static async Task<List<DetalleDeVenta>> BuscarAsync(DetalleDeVenta pDetalleDeVenta)
        {
            var DetalleDeVenta = new List<DetalleDeVenta>();
            using (var bdContexto = new BDContexto())
            {
                var select = bdContexto.DetalleDeVenta.AsQueryable();
                select = QuerySelect(select, pDetalleDeVenta);
                DetalleDeVenta = await select.ToListAsync();
            }
            return DetalleDeVenta;
        }
    }
}
//Terminados
