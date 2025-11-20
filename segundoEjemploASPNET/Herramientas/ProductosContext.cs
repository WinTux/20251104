using Microsoft.EntityFrameworkCore;

namespace segundoEjemploASPNET.Herramientas
{
    public class ProductosContext : DbContext
    {
        public DbSet<para.ddbb.Producto> Productos { get; set; }
        public ProductosContext(DbContextOptions<ProductosContext> options) : base(options)
        {

        }

        
    }
}
