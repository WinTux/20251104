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

        [HttpGet]
        public IActionResult Editar(int id)
        {
            var producto = db.Productos.FirstOrDefault(p => p.Id.Equals(id));
            return View(producto);
        }
        [HttpPost]
        public IActionResult Editar(para.ddbb.Producto producto)
        {
            var productoOriginal = db.Productos.FirstOrDefault(p => p.Id.Equals(producto.Id));
            productoOriginal.Nombre = producto.Nombre;
            productoOriginal.Precio = producto.Precio;
            productoOriginal.Activo = producto.Activo;
            productoOriginal.Cantidad = producto.Cantidad;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Eliminar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Eliminar(int id)
        {
            var producto = db.Productos.FirstOrDefault(p => p.Id.Equals(id));
            db.Productos.Remove(producto);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
