using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Linq;
using System.Threading.Tasks;
namespace ecommerce_videojuegos_GAMING_POINT_.Controllers
{
    public class ProductoController : Controller
    {
        private readonly ProductosContext _productosContext;
        public ProductosController(ProductosContext productosContext)
        {
            this._productosContext = productosContext;
        }
        public IActionResult List()
        {
            var listResult = _productosContext.Productos.ToList();

            ProductoMTNListViewModel model = new ProductoMTNListViewModel();
            model.List = (from a in listResult
                          select new ProductoMTNViewModel()
                          {
                              Id = a.Id,
                              nombreproducto = a.nombreproducto,
                              marca = a.marca,
                              precio = a.precio,
                              descuento = a.descuento,
                              preciofinal = a.preciofinal,
                              stock = a.stock,
                              descripcion = a.descripcion,
                              imagen = a.imagen,
                          }).ToList();
            return View(model);
        }

        public IActionResult Add()
        {
            ProductoMTNViewModel model = new ProductoMTNViewModel();
            return View(model);
        }

        public IActionResult AddSavedAction(ProductoMTNViewModel model)
        {  
            ProductosEntity entity = new ProductosEntity();
            entity.nombreproducto = model.nombreproducto;
            entity.marca = model.marca;
            entity.precio = model.precio.HasValue ? model.DNI.Value : 0;
            entity.descuento =model.descuento;
            entity.preciofinal = model.preciofinal;
            entity.stock = model.stock.HasValue ? model.Celular.Value : 0;
            entity.descripcion = model.descripcion;
            entity.imagen = model.imagen.HasValue ? model.TelefonoContacto.Value : 0;
            _productosContext.Productos.Add(entity);
            _productosContext.SaveChanges();
            return RedirectToAction("List", "Productos");
        }
        public IActionResult Edit(int Id)
        {
            var findProductos = _productosContext.Productos.Where(a => a.Id == Id).SingleOrDefault();
            var model = new ProductoMTNViewModel();
            model.Id = findProductos.Id;
            model.nombreproducto = findProductos.nombreproducto;
            model.marca = findProductos.marca;
            model.precio = findProductos.precio;
            model.descuento = findProductos.descuento;
            model.preciofinal = findProductos.preciofinal;
            model.stock = findProductos.stock;
            model.descripcion = findProductos.descripcion;
            model.imagen = findProductos.imagen;
            return View(model);
        }
        [HttpPost]
        public IActionResult EditSaved(ProductoMTNViewModel model)
        {
            var findAlumnos = _productosContext.Productos.SingleOrDefault(a => a.Id == model.Id);
            if (findAlumnos != null)
            {
                findProductos.nombreproducto = model.nombreproducto;
                findProductos.marca = model.marca;
                findProductos.precio = model.precio;
                findProductos.descuento = model.descuento;
                findProductos.preciofinal = model.preciofinal;
                findProductos.stock = model.stock;
                findProductos.descripcion = model.descripcion;
                findProductos.imagen = model.imagen;
                _productosContext.SaveChanges();
            }

            return RedirectToAction("List", "Productos");
        }
        [HttpGet]
        public JsonResult DeleteProductos(int Id)
        {
            var findAlumnos = _productosContext.Productos.SingleOrDefault(a => a.ID == ID);
            _productosContext.Productos.Remove(findProductos);
            _productosContext.SaveChanges();
            return Json("Se eliminó al productos de manera correcta");
        }
    }
}
