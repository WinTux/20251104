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
        [HttpGet]
        public IActionResult Agregar() {
            return View(new para.ddbb.Producto());
        }
        [HttpPost]
        public IActionResult Agregar(para.ddbb.Producto producto)
        {
            db.Productos.Add(producto);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
