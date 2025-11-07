using Microsoft.AspNetCore.Mvc;

namespace segundoEjemploASPNET.Controllers
{
    // Agregando route que rescata el nombre del controlador
    [Route("{controller}")]
    public class QueryStringsController : Controller
    {
        [Route("")] // Ruta vacía para la acción Index
        [Route("Index")] // Ruta explícita para la acción Index
        public IActionResult Index()
        {
            return View();
        }
        [Route("ejemplo1")] // Ruta para la acción ejemplo1
        public IActionResult ejemplo1([FromQuery(Name = "id")] string parametro)
        {
            ViewBag.param = parametro;
            return View("resultado");
        }
        [Route("ejemplo2")] // Ruta para la acción ejemplo2
        public IActionResult ejemplo2([FromQuery(Name = "num1")] int n1, [FromQuery(Name = "num2")] int n2, [FromQuery(Name = "num3")] int n3)
        {
            ViewBag.numero1 = n1;
            ViewBag.numero2 = n2;
            ViewBag.numero3 = n3;
            return View("resultado");
        }
    }
}
