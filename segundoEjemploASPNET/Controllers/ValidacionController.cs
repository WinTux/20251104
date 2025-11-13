using Microsoft.AspNetCore.Mvc;

namespace segundoEjemploASPNET.Controllers
{
    public class ValidacionController : Controller
    {
        public IActionResult Index()
        {
            return View("Index", new ejemplo.validacion.Cuenta());
        }
        [HttpPost]
        public IActionResult Guardar(ejemplo.validacion.Cuenta cuenta)
        {
            if (ModelState.IsValid)
            {
                ViewBag.cuenta = cuenta;
                return View("Resultado", cuenta);
            }
            else
            {
                return View("Index", cuenta);
            }
        }
    }
}
