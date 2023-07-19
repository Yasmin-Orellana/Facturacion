using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SysFacturacionLibreria.EntidadesDeNegocio;
using SysFacturacionLibreria.LogicaDeNegocio;

namespace SysFacturacionLibreria.UI.AppWebAspCore.Controllers
{
    public class ClienteController : Controller
    {
        ClienteBL ClienteBL = new ClienteBL();
        // GET: ClienteController
        public async Task<IActionResult> Index(Cliente pCliente = null)
        {
            if (pCliente == null)
                pCliente = new Cliente();
            if (pCliente.Top_Aux == 0)
                pCliente.Top_Aux = 10;
            else if (pCliente.Top_Aux == -1)
                pCliente.Top_Aux = 0;
            var Cliente = await ClienteBL.BuscarAsync(pCliente);
            ViewBag.Top = pCliente.Top_Aux;
            return View(Cliente);
        }

        // GET: ClienteController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var rol = await ClienteBL.ObtenerPorIdAsync(new Cliente { IdCliente = id });
            return View(rol);
        }

        // GET: CategoriaController/Create
        public IActionResult Create()
        {
            ViewBag.Error = "";
            return View();
        }


        // POST: ClienteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Cliente pCliente)
        {
            try
            {
                int result = await ClienteBL.CrearAsync(pCliente);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(pCliente);
            }
        }

        // GET: ClienteController/Edit/5
        public async Task<IActionResult> Edit(Cliente pCliente)
        {
            var Cliente = await ClienteBL.ObtenerPorIdAsync(pCliente);
            ViewBag.Error = "";
            return View(Cliente);
        }

        // POST: ClienteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Cliente pCliente)
        {
            try
            {
                int result = await ClienteBL.ModificarAsync(pCliente);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(pCliente);
            }
        }

        // GET: ClienteController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            ViewBag.Error = "";
            var cliente = await ClienteBL.ObtenerPorIdAsync(new Cliente { IdCliente = id });
            return View(cliente);
        }

        // POST: ClienteController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var cliente = await ClienteBL.ObtenerPorIdAsync(new Cliente { IdCliente = id });
                int result = await ClienteBL.EliminarAsync(cliente);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }
    }
}


