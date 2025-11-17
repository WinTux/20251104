using Microsoft.AspNetCore.Mvc;
using segundoEjemploASPNET.Herramientas;
using segundoEjemploASPNET.Models;

namespace segundoEjemploASPNET.Controllers
{
    public class SesionesController : Controller
    {
        public IActionResult Index()
        {
            HttpContext.Session.SetString("saludo", "Hola desde sesión");
            HttpContext.Session.SetInt32("numero", 12345);
            Producto producto = new Producto()
            {
                Id = "Prod01",
                Nombre = "Queso",
                Precio = 18.5M,
                Foto = "queso.jpg",
                Cantidad = 2
            };
            ConversorSesiones.ConvertirAJson(HttpContext.Session, "producto", producto);
            // Lista de productos
            List<Producto> productos = new List<Producto>()
            {
                new Producto()
                {
                    Id = "Prod01",
                    Nombre = "Queso",
                    Precio = 18.5M,
                    Foto = "queso.jpg",
                    Cantidad = 2
                },
                new Producto()
                {
                    Id = "Prod02",
                    Nombre = "Sardina",
                    Precio = 25.0M,
                    Foto = "sardina.png",
                    Cantidad = 1
                },
                new Producto()
                {
                    Id = "Prod03",
                    Nombre = "Atún",
                    Precio = 12.0M,
                    Foto = "atun.jpg",
                    Cantidad = 3
                }
            };
            ConversorSesiones.ConvertirAJson(HttpContext.Session, "productos", productos);
            return View();
        }
    }
}
