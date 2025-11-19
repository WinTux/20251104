using Microsoft.AspNetCore.Mvc;

namespace segundoEjemploASPNET.Controllers
{
    public class AcercaDeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Acerca1()
        {
            return View();
        }
        public IActionResult Acerca2()
        {
            return View();
        }
    }
}
