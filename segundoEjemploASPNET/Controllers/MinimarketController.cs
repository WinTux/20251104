using Microsoft.AspNetCore.Mvc;

namespace segundoEjemploASPNET.Controllers
{
    public class MinimarketController : Controller
    {
        public IActionResult Index()
        {
            var productoModel = new para.sesiones.ProductoModel();
            ViewBag.Productos = productoModel.GetAllProductos();
            return View();
        }
    }
}
