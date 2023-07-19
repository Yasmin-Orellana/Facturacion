using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SysFacturacionLibreria.EntidadesDeNegocio;
using SysFacturacionLibreria.LogicaDeNegocio;

namespace SysFacturacionLibreria.UI.AppWebAspCore.Controllers
{
    public class ProductoController : Controller
    {
        ProductoBL ProductoBL = new ProductoBL();
        // GET: ProductoController
        public async Task<IActionResult> Index(Producto pProducto = null)
        {
            if (pProducto == null)
                pProducto = new Producto();
            if (pProducto.Top_Aux == 0)
                pProducto.Top_Aux = 10;
            else if (pProducto.Top_Aux == -1)
                pProducto.Top_Aux = 0;
            var Producto = await ProductoBL.BuscarAsync(pProducto);
            ViewBag.Top = pProducto.Top_Aux;
            return View(Producto);
        }

        // GET: CategoriaController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var rol = await ProductoBL.ObtenerPorIdAsync(new Producto { IdProducto = id });
            return View(rol);
        }

        // GET: ProductoController/Create
        public IActionResult Create()
        {
            ViewBag.Error = "";
            return View();
        }

        // POST: ProductoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Producto pProducto)
        {
            try
            {
                int result = await ProductoBL.CrearAsync(pProducto);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(pProducto);
            }
        }

        // GET: ProductoContProductoler/Edit/5
        public async Task<IActionResult> Edit(Producto pProducto)
        {
            var Producto = await ProductoBL.ObtenerPorIdAsync(pProducto);
            ViewBag.Error = "";
            return View(Producto);
        }

        // POST: ProductoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Producto pProducto)
        {
            try
            {
                int result = await ProductoBL.ModificarAsync(pProducto);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(pProducto);
            }
        }

        // GET: ProductoController/Delete/5
        public async Task<IActionResult> Delete(Producto pProducto)
        {
            ViewBag.Error = "";
            var Producto = await ProductoBL.ObtenerPorIdAsync(pProducto);
            return View(Producto);
        }

        // POST: ProductoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, Producto pProducto)
        {
            try
            {
                int result = await ProductoBL.EliminarAsync(pProducto);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(pProducto);
            }
        }
    }
}
