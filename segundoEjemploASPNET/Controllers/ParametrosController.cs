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
        [Route("Ejemplo2/{id1}/{id2}")]
        public IActionResult Ejemplo3(int id1, int id2)
        {
            ViewBag.id1 = id1;
            ViewBag.id2 = id2;
            return View("Example3");
        }
    }
}
