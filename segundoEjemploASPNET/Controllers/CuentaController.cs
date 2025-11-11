using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using segundoEjemploASPNET.Models;

namespace segundoEjemploASPNET.Controllers
{
    public class CuentaController : Controller
    {
        public IActionResult Index()
        {
            var cuentaViewModel = new CuentaViewModel();
            cuentaViewModel.Cuenta = new Cuenta
            {
                Id = 123,
                Disponible = true,
                Genero = "F",
            };
            cuentaViewModel.Lenguajes = new List<Lenguaje>
            {
                new Lenguaje { Id = "Len01", Nombre = "C#", estaMarcado = true },
                new Lenguaje { Id = "Len02", Nombre = "Java", estaMarcado = false },
                new Lenguaje { Id = "Len03", Nombre = "Python", estaMarcado = true },
                new Lenguaje { Id = "Len04", Nombre = "COBOL", estaMarcado = false }
            };
            var listaCargos = new List<Cargo>
            {
                new Cargo { Id = "Car01", Nombre = "Administrador de sistemas" },
                new Cargo { Id = "Car02", Nombre = "Desarrollador core" },
                new Cargo { Id = "Car03", Nombre = "Analista de operaciones" }
            };
            cuentaViewModel.Cargos = new SelectList(listaCargos, "Id", "Nombre");
            return View("Index",cuentaViewModel);
        }
        [HttpPost]
        public IActionResult Registrar(CuentaViewModel cuentaViewModel, List<Lenguaje> lenguajes) {
            cuentaViewModel.Cuenta.Lenguajes = lenguajes.Where(l => l.estaMarcado).Select(l => l.Id).ToList();
            /*cuentaViewModel.Cuenta.Lenguajes = new List<string>();
            foreach (var lenguaje in lenguajes)
            {
                if (lenguaje.estaMarcado)
                {
                    cuentaViewModel.Cuenta.Lenguajes.Add(lenguaje.Id);
                }
            }*/
            ViewBag.Cuenta = cuentaViewModel.Cuenta;
            return View("Registrado");
        }
    }
}
