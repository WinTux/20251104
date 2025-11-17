using Microsoft.AspNetCore.Mvc;

namespace segundoEjemploASPNET.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
