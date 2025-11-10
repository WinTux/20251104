namespace segundoEjemploASPNET.Models
{
    public class Cuenta
    {
        public int Id { get; set; }
        public string Usuario { get; set; }
        public string Password { get; set; }
        public string Descripcion { get; set; }
        public bool Disponible { get; set; }
        public string Genero { get; set; } // "M" o "F"
        public List<string> Lenguajes { get; set; } // "Len01", "Len02", "Len03"
        public string Cargo { get; set; } // "Car01", "Car02", "Car03"

    }
}
