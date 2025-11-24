using Microsoft.AspNetCore.Mvc;

namespace segundoEjemploASPNET.Controllers
{
    public class QRController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult GenerarQR(string qrText)
        {
            ViewBag.QRText = qrText;
            return View("Index");
        }
    }
}
