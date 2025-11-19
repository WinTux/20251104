using Microsoft.AspNetCore.Mvc;
using para.sesiones;
using segundoEjemploASPNET.Herramientas;

namespace segundoEjemploASPNET.Controllers
{
    public class CarritoController : Controller
    {
        public IActionResult Index()
        {
            var carrito = ConversorSesiones.ConvertirDesdeJson<List<Item>>(HttpContext.Session, "carrito");
            ViewBag.Carrito = carrito ?? new List<Item>();
            ViewBag.Total = carrito != null ? carrito.Sum(i => i.Producto.Precio * i.Cantidad) : 0m;
            return View();
        }
        [Route("Agregar/{id}")]
        public IActionResult Agregar(string id) {
            ProductoModel productoModel = new ProductoModel();
            // Verificar si la variable de sesión "carrito" existe
            if (ConversorSesiones.ConvertirDesdeJson<List<Item>>(HttpContext.Session, "carrito") == null)
            {
                // Crear la variable de sesión "carrito" como una lista vacía
                List<Item> carrito = new List<Item>();
                // Agregar el producto al carrito
                carrito.Add(new Item { Producto = productoModel.GetProductoById(id), Cantidad = 1 });
                // Guardar el carrito en la sesión
                ConversorSesiones.ConvertirAJson(HttpContext.Session, "carrito", carrito);
            }
            else {
                // El carrito ya existe en la sesión
                var carrito = ConversorSesiones.ConvertirDesdeJson<List<Item>>(HttpContext.Session, "carrito");
                int indice = existe(id);
                if (indice != -1) {
                    // Sí existe el producto en el carrito, aumentar la cantidad
                    carrito[indice].Cantidad++;
                }
                else { 
                    // No existe el producto en el carrito, agregarlo
                    carrito.Add(new Item { Producto = productoModel.GetProductoById(id), Cantidad = 1 });
                }
                // Guardar el carrito actualizado en la sesión
                ConversorSesiones.ConvertirAJson(HttpContext.Session, "carrito", carrito);
            }
            return RedirectToAction("Index");
        }
        [Route("Eliminar/{id}")]
        public IActionResult Eliminar(string id) {
            var carrito = ConversorSesiones.ConvertirDesdeJson<List<Item>>(HttpContext.Session, "carrito");
            int indice = existe(id);
            carrito.RemoveAt(indice);
            ConversorSesiones.ConvertirAJson(HttpContext.Session, "carrito", carrito);
            return RedirectToAction("Index");
        }

        private int existe(string id)
        {
            var carrito = ConversorSesiones.ConvertirDesdeJson<List<Item>>(HttpContext.Session, "carrito");
            for (int i = 0; i < carrito.Count; i++)
                if (carrito[i].Producto.Id.Equals(id))
                    return i;
            return -1;
        }
    }
}
