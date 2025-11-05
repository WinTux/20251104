using Microsoft.AspNetCore.Mvc;

namespace segundoEjemploASPNET.Controllers
{
    public class EjemploController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
