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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DetalleEntity>()
                .HasOne(n => n.Orden)
                .WithOne(e => e.OrdenDetalle)
                .HasForeignKey(n => n.IdOrden);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductoEntity>()
                .HasOne(n => n.OrdenDetalle)
                .WithMany(e => e.Producto)
                .HasForeignKey(n => n.IdOrdenDetalle);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrdenEntity>()
                .HasOne(n => n.Usuario)
                .WithMany(e => e.Orden)
                .HasForeignKey(n => n.IdUsuario);
        }
    }
}
