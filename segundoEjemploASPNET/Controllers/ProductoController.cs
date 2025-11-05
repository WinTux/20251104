using Microsoft.AspNetCore.Mvc;

namespace segundoEjemploASPNET.Controllers
{
    [Route("productos")] // https://localhost:7135/productos
    public class ProductoController : Controller
    {
        [Route("")] // https://localhost:7135/productos
        [Route("index")] // https://localhost:7135/productos/index
        public IActionResult Index()
        {
            var prod01 = new Models.Producto
            {
                Id = "P001",
                Nombre = "Atun VanCamp's",
                Precio = 19.99m,
                Foto = "atun.jpg",
                Cantidad = 50
            };
            ViewBag.prod = prod01;

            return View();
        }
        [Route("lista")] // https://localhost:7135/productos/lista
        public IActionResult Productos()
        {
            var productos = new List<Models.Producto>
            {
                new Models.Producto
                {
                    Id = "P001",
                    Nombre = "Atun VanCamp's",
                    Precio = 19.99m,
                    Foto = "atun.jpg",
                    Cantidad = 50
                },
                new Models.Producto
                {
                    Id = "P002",
                    Nombre = "Helado casatta",
                    Precio = 15.49m,
                    Foto = "helado1.jfif",
                    Cantidad = 30
                },
                new Models.Producto
                {
                    Id = "P003",
                    Nombre = "Limonada casera",
                    Precio = 12.75m,
                    Foto = "limonada2.jpg",
                    Cantidad = 20
                }
            };
            ViewBag.productos = productos;
            // Obtener el total mediante linq
            ViewBag.total = productos.Sum(p => p.Precio * p.Cantidad);
            return View();
        }
    }
}
