using Microsoft.AspNetCore.Mvc.Rendering;

namespace segundoEjemploASPNET.Models
{
    public class CuentaViewModel
    {
        public Cuenta Cuenta { get; set; }
        public List<Lenguaje> Lenguajes { get; set; }
        public SelectList Cargos { get; set; }
    }
}
