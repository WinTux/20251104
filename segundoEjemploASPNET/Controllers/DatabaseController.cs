using Microsoft.AspNetCore.Mvc;
using segundoEjemploASPNET.Herramientas;

namespace segundoEjemploASPNET.Controllers
{
    public class DatabaseController : Controller
    {
        private ProductosContext db;
        public DatabaseController(ProductosContext productosContext) {
            db = productosContext;
        }
        public IActionResult Index()
        {
            ViewBag.productos = db.Productos.ToList();
            return View();
        }
    }
}
