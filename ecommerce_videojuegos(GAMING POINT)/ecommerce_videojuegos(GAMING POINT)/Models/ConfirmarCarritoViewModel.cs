using System.Collections.Generic;

namespace ecommerce_videojuegos_GAMING_POINT_.Models
{
    public class ConfirmarCarritoViewModel
    {
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string dni { get; set; }
        public string usuario { get; set; }
        public string contrasena { get; set; }


        public string numerotarjeta { get; set; }
        public string fechaexpiracion { get; set; }
        public string cvv { get; set; }
        public string correo { get; set; }


        public List<ProductoTemporalViewModel> Temporal { get; set; }

        public ConfirmarCarritoViewModel()
        {
            Temporal = new List<ProductoTemporalViewModel>();
        }
    }
}
