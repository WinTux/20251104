using Microsoft.AspNetCore.Mvc;

namespace segundoEjemploASPNET.Controllers
{
    public class EjemploController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Saludo()
        {
            ViewBag.nombre = "Pepe Perales";
            ViewBag.edad = 30;
            ViewBag.casado = true;
            ViewBag.estatura = 1.75;
            ViewBag.fechaNacimiento = new DateTime(1993, 5, 15);
            return View();
        }
    }
}
