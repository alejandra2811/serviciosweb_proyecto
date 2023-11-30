using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ecommerce_videojuegos_GAMING_POINT_.Models
{
    public class ProductoMTNListViewModel
    {
        public List<ProductoMTNViewModel> List { get; set; }

        public ProductoMTNListViewModel()
        {
            List = new List<ProductoMTNViewModel>();
        }
    }

    public class ProductoMTNViewModel
    {
        public int Id {get; set; }
        public string nombreproducto { get; set; }
        public string marca { get; set; }
        public double precio { get; set; }
        public double descuento { get; set; }
        public double preciofinal { get; set; }
        public int stock { get; set; }
        public string descripcion { get; set; }
        public string imagen { get; set; }
    }
}
