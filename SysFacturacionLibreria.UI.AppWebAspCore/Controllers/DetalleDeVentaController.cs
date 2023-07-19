using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SysFacturacionLibreria.LogicaDeNegocio;
using SysFacturacionLibreria.EntidadesDeNegocio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;
using SysFacturacionLibreria.AccesoADatos;


namespace SysFacturacionLibreria.UI.AppWebAspCore.Controllers
{
   // [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    public class DetalleDeVentaController : Controller
    {

        DetalleDeVentaBL DetalleDeVentaBL = new DetalleDeVentaBL();
        // GET: DetalleDeVentaController
        public async Task<IActionResult> Index (DetalleDeVenta pDetalleDeVenta = null)
        {
            if (pDetalleDeVenta == null)
                pDetalleDeVenta = new DetalleDeVenta();
            if (pDetalleDeVenta.Top_Aux == 0)
                pDetalleDeVenta.Top_Aux = 10;
            else if (pDetalleDeVenta.Top_Aux == -1)
                pDetalleDeVenta.Top_Aux = 0;
            var DetalleDeVenta = await DetalleDeVentaBL.BuscarAsync(pDetalleDeVenta);
            ViewBag.Top = pDetalleDeVenta.Top_Aux;
            return View(DetalleDeVenta);
        }

        // GET: DetalleDeVentaController/Details/5
        public async Task<IActionResult> Details(int IdDetalleDeVenta)
        {
            var detalleDeVenta = await DetalleDeVentaBL.ObtenerPorIdAsync(new DetalleDeVenta { IdDetalleDeVenta = IdDetalleDeVenta });
            return View(detalleDeVenta);
        }

        // GET: DetalleDeVentaController/Create
        public IActionResult Create()
        {
            ViewBag.Error = "";
            return View();
        }

        // POST: DetalleDeVentaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DetalleDeVenta pDetalleDeVenta)
        {
            try
            {
                int result = await DetalleDeVentaBL.CrearAsync(pDetalleDeVenta);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(pDetalleDeVenta);
            }
        }

        // GET: DetalleDeVentaController/Edit/5
        public async Task<IActionResult> Edit(DetalleDeVenta pDetalleDeVenta)
        {
            var DetalleDeVenta = await DetalleDeVentaBL.ObtenerPorIdAsync(pDetalleDeVenta);
            ViewBag.Error = "";
            return View(DetalleDeVenta);
        }

        // POST: DetalleDeVentaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, DetalleDeVenta pDetalleDeVenta)
        {
            try
            {
                int result = await DetalleDeVentaBL.ModificarAsync(pDetalleDeVenta);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(pDetalleDeVenta);
            }
        }

        // GET: DetalleDeVentaController/Delete/5
        public async Task<IActionResult> Delete(DetalleDeVenta pDetalleDeVenta)
        {
            ViewBag.Error = "";
            var DetalleDeVenta = await DetalleDeVentaBL.ObtenerPorIdAsync(pDetalleDeVenta);
            return View(DetalleDeVenta);
        }

        // POST: DetalleDeVentaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, DetalleDeVenta pDetalleDeVenta)
        {
            try
            {
                int result = await DetalleDeVentaBL.EliminarAsync(pDetalleDeVenta);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(pDetalleDeVenta);
            }

        }//terminado

    }
}
