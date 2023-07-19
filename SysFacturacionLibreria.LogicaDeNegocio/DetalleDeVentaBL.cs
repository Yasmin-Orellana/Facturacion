using Microsoft.EntityFrameworkCore;
using SysFacturacionLibreria.AccesoADatos;
using SysFacturacionLibreria.EntidadesDeNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysFacturacionLibreria.LogicaDeNegocio
{
    public class DetalleDeVentaBL
    {
        public async Task<int> CrearAsync(DetalleDeVenta pDetalleDeVenta)
        {
            return await DetalleDeVentaDAL.CrearAsync(pDetalleDeVenta);
        }
        public async Task<int> ModificarAsync(DetalleDeVenta pDetalleDeVenta)
        {
            return await DetalleDeVentaDAL.ModificarAsync(pDetalleDeVenta);
        }
        public async Task<int> EliminarAsync(DetalleDeVenta pDetalleDeVenta)
        {
            return await DetalleDeVentaDAL.EliminarAsync(pDetalleDeVenta);
        }
        public async Task<DetalleDeVenta> ObtenerPorIdAsync(DetalleDeVenta pDetalleDeVenta)
        {
            return await DetalleDeVentaDAL.ObtenerPorIdDetalleDeVentaAsync(pDetalleDeVenta);
        }
        public async Task<List<DetalleDeVenta>> ObtenerTodosAsync()
        {
            return await DetalleDeVentaDAL.ObtenerTodosAsync();
        }
        public async Task<List<DetalleDeVenta>> BuscarAsync(DetalleDeVenta pDetalleDeVenta)
        {
            return await DetalleDeVentaDAL.BuscarAsync(pDetalleDeVenta);
        }
    }
}
//Terminados