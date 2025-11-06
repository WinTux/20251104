using Microsoft.AspNetCore.Mvc;

namespace segundoEjemploASPNET.Controllers
{
    public class AppSettingsController : Controller
    {
        private IConfiguration configuration;

        public AppSettingsController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public IActionResult Index()
        {
            ViewBag.attr1 = configuration["Atributo1"];
            ViewBag.attr2 = configuration["Atributo2"];
            ViewBag.config = configuration["MisConfiguraciones:Configuracion2"];
            ViewBag.log = configuration["Logging:LogLevel:Microsoft.AspNetCore"];
            return View();
        }
    }
}
