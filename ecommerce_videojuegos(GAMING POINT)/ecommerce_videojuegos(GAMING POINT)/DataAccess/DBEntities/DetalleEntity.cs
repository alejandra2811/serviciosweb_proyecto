using ecommerce_videojuegos_GAMING_POINT_.DataAccess.DBEntities.Abstraccions;
using System.ComponentModel.DataAnnotations.Schema;

namespace ecommerce_videojuegos_GAMING_POINT_.DataAccess.DBEntities
{
    [Table("DetalleOrden")]
    public class DetalleEntity : BaseEntity
    {
        public double preciofinal { get; set; }
        public virtual ProductoEntity Producto { get; set; }
        public virtual OrdenEntity Orden { get; set; }
    }
}
