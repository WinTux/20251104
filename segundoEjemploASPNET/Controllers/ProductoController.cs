using Microsoft.AspNetCore.Mvc;

namespace segundoEjemploASPNET.Controllers
{
    [Route("productos")] // https://localhost:7135/productos
    public class ProductoController : Controller
    {
        private IWebHostEnvironment webHostEnvironment;

        public ProductoController(IWebHostEnvironment webHostEnvironment) { 
            this.webHostEnvironment = webHostEnvironment;
        }
   
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
        [Route("formulario1")] // https://localhost:7135/productos/formulario1
        public IActionResult Formulario1()
        {
            return View("Formulario1", new Models.Producto());
        }
        [Route("formulario2")]
        public IActionResult Formulario2()
        {
            return View("Formulario2", new para.formularios.Producto());
        }
        [HttpPost]
        [Route("Registrar")] // https://localhost:7135/productos/registrar
        public IActionResult Registrar(Models.Producto producto, IFormFile foto) {
            if (foto == null || foto.Length == 0)
                return Content("ARCHIVO NO SELECCIONADO O INVÁLIDO");
            else {
                var ruta = Path.Combine(webHostEnvironment.WebRootPath, "imagenes", foto.FileName);
                using (var stream = new FileStream(ruta, FileMode.Create)) {
                    foto.CopyTo(stream);
                }
                producto.Foto = foto.FileName;
            }
            ViewBag.producto = producto;
            return View("Registrado");
        }
        [HttpPost]
        [Route("Registrar2")] // https://localhost:7135/productos/registrar
        public IActionResult Registrar2(para.formularios.Producto producto, IFormFile[] fotos)
        {
            if (fotos == null || fotos.Length == 0)
                return Content("ARCHIVO NO SELECCIONADO O INVÁLIDO");
            else
            {
                producto.Fotos = new List<string>();
                foreach (IFormFile foto in fotos) {
                    var ruta = Path.Combine(webHostEnvironment.WebRootPath, "imagenes", foto.FileName);
                    using (var stream = new FileStream(ruta, FileMode.Create))
                    {
                        foto.CopyTo(stream);
                    }
                    producto.Fotos.Add(foto.FileName);
                }
                
            }
            ViewBag.producto = producto;
            return View("Registrado2");
        }
    }
}
