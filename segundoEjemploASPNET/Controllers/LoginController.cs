using Microsoft.AspNetCore.Mvc;

namespace segundoEjemploASPNET.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Autenticacion(string username, string password)
        {
            // Aquí iría la lógica de autenticación real
            if (username != null && password != null && username.Equals("pepe") && password.Equals("123456"))
            {
                // Autenticación exitosa
                HttpContext.Session.SetString("Username", username);
                return View("Exito");
            }
            else
            {
                // Autenticación fallida
                ViewBag.ErrorMessage = "Credenciales inválidas. Inténtalo de nuevo.";
                return View("Index");
            }
        }
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("Username");
            return RedirectToAction("Index");
        }
    }
}
