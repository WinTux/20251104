namespace segundoEjemploASPNET.Models
{
    public class Producto
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public string Foto { get; set; }
        public int Cantidad { get; set; }
    }
}
namespace para.formularios {
    public class Producto
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public List<string> Fotos { get; set; }
        public int Cantidad { get; set; }
    }
}
