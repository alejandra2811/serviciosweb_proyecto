using ecommerce_videojuegos_GAMING_POINT_.DataAccess.DBEntities.Abstraccions;
using System.ComponentModel.DataAnnotations.Schema;

namespace ecommerce_videojuegos_GAMING_POINT_.DataAccess.DBEntities
{
    [Table("Usuario")]
    public class UsuarioEntity : BaseEntity
    {
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string dni { get; set; }
        public string usuario { get; set; }
        public string contrasena { get; set; }
    }
}
