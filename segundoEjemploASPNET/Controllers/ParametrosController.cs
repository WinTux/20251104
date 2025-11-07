using Microsoft.AspNetCore.Mvc;

namespace segundoEjemploASPNET.Controllers
{
    [Route("Parametros")]
    public class ParametrosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [Route("Ejemplo2/{nom}")]
        public IActionResult Ejemplo2(string nom){
            ViewBag.nombre = nom;
            return View("Example2");
        }
        [Route("Ejemplo3/{id1}/{id2}")]
        public IActionResult Ejemplo3(int id1, int id2)
        {
            ViewBag.id1 = id1;
            ViewBag.id2 = id2;
            return View("Example3");
        }

        [Route("Ejemplo4/{param1}-{param2}/usuario/{param3}")]
        public IActionResult Ejemplo4(string param1, string param2, string param3)
        {
            ViewBag.id1 = param1;
            ViewBag.id2 = param2;
            ViewBag.id3 = param3;
            return View("Example4");
        }
    }
}
