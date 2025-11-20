using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
namespace para.sesiones {
    public class Producto {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public string Foto { get; set; }
    }
    public class Item { 
        public Producto Producto { get; set; }
        public int Cantidad { get; set; }
    }
    public class ProductoModel {
        private List<Producto> productos;
        public ProductoModel()
        {
            productos = new List<Producto>()
            {
                new Producto { Id = "1", Nombre = "Atún", Precio = 0.5m, Foto = "atun.jpg" },
                new Producto { Id = "2", Nombre = "Helado 1", Precio = 0.3m, Foto = "helado1.jfif" },
                new Producto { Id = "3", Nombre = "queso", Precio = 0.7m, Foto = "queso.jpg" }
            };
        }
        public List<Producto> GetAllProductos()
        {
            return productos;
        }
        public Producto GetProductoById(string id)
        {
            return productos.FirstOrDefault(p => p.Id.Equals(id));// SELECT * FROM productos WHERE Id = id
        }
    }
}
namespace para.ddbb {
    [Table("Productos")]
    public class Producto
    {
        [Key]
        public string Id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        [Column("Foto")]
        public string Foto { get; set; }
        public int Cantidad { get; set; }
        public bool Activo { get; set; }
    }

}