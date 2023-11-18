using System.ComponentModel.DataAnnotations;

namespace ecommerce_videojuegos_GAMING_POINT_.DataAccess.DBEntities.Abstraccions
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public bool Status { get; set; }
    }
}
