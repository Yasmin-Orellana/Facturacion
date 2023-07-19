using Microsoft.AspNetCore.Mvc;
using SysFacturacionLibreria.LogicaDeNegocio;
using SysFacturacionLibreria.EntidadesDeNegocio;
using System;
using System.Threading.Tasks;

namespace SysFacturacionLibreria.UI.AppWebAspCore.Controllers
{
    public class FacturaController : Controller
    {
        private readonly FacturaBL facturaBL;

        public FacturaController()
        {
            facturaBL = new FacturaBL();
        }

        // GET: Factura
        public async Task<IActionResult> Index(Factura pFactura = null)
        {
            if (pFactura == null)
                pFactura = new Factura();
            if (pFactura.Top_Aux == 0)
                pFactura.Top_Aux = 10;
            else if (pFactura.Top_Aux == -1)
                pFactura.Top_Aux = 0;
            var Factura = await facturaBL.BuscarAsync(pFactura);
            ViewBag.Top = pFactura.Top_Aux;
            return View(Factura);
        }

        // GET: Factura/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var factura = await facturaBL.ObtenerPorIdAsync(new Factura { IdFactura = id });
            return View(factura);
        }

        // GET: Factura/Create
        public IActionResult Create()
        {
            ViewBag.Error = "";
            return View();
        }

        // POST: Factura/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Factura pFactura)
        {
            try
            {
                int result = await facturaBL.CrearAsync(pFactura);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(pFactura);
            }
        }

        // GET: Factura/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var factura = await facturaBL.ObtenerPorIdAsync(new Factura { IdFactura = id });
            ViewBag.Error = "";
            return View(factura);
        }

        // POST: Factura/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Factura pFactura)
        {
            try
            {
                int result = await facturaBL.ModificarAsync(pFactura);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(pFactura);
            }
        }

        // GET: Factura/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            ViewBag.Error = "";
            var factura = await facturaBL.ObtenerPorIdAsync(new Factura { IdFactura = id });
            return View(factura);
        }

        // POST: Factura/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                await facturaBL.EliminarAsync(new Factura { IdFactura = id });
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(new Factura { IdFactura = id });
            }
        }
    }
}
