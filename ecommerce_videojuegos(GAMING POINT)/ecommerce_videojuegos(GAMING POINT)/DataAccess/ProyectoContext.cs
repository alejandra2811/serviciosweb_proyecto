using ecommerce_videojuegos_GAMING_POINT_.DataAccess.DBEntities;
using Microsoft.EntityFrameworkCore;

namespace ecommerce_videojuegos_GAMING_POINT_.DataAccess
{
    public class ProyectoContext : DbContext
    {
        public DbSet<UsuarioEntity> Usuario { get; set; }
        public DbSet<OrdenEntity> Orden { get; set; }
        public DbSet<ProductoEntity> Producto { get; set; }
        public DbSet<DetalleEntity> OrdenDetalle { get; set; }

        public ProyectoContext(DbContextOptions<ProyectoContext> option) : base(option)
        {
        }
    }
}
