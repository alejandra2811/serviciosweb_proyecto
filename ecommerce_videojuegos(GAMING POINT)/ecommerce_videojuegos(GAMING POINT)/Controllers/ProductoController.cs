using Microsoft.CodeAnalysis.CSharp.Syntax;
using avanceproyidk.DataAccess;
using avanceproyidk.Models;
using avanceproyidk.DataAccess.DBEntities;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace avanceproyidk.Controllers
{
    public class ProductoController : Controller
    {
        private readonly CarritoContext _productosContext;
        public ProductoController(CarritoContext productosContext)
        {
            this._productosContext = productosContext;
        }
        public IActionResult List()
        {
            var listResult = _productosContext.Producto.ToList();

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
            ProductoEntity entity = new ProductoEntity();
            entity.nombreproducto = model.nombreproducto;
            entity.marca = model.marca;
            entity.precio = model.precio;
            entity.descuento =model.descuento;
            entity.preciofinal = model.preciofinal;
            entity.stock = model.stock;
            entity.descripcion = model.descripcion;
            entity.imagen = model.imagen;
            _productosContext.Producto.Add(entity);
            _productosContext.SaveChanges();
            return RedirectToAction("List", "Productos");
        }
        public IActionResult Edit(int Id)
        {
            var findProductos = _productosContext.Producto.Where(a => a.Id == Id).SingleOrDefault();
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
            var findProductos = _productosContext.Producto.SingleOrDefault(a => a.Id == model.Id);
            if (findProductos != null)
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
            var findProductos = _productosContext.Producto.SingleOrDefault(a => a.Id == Id);
            _productosContext.Producto.Remove(findProductos);
            _productosContext.SaveChanges();
            return Json("Se eliminó al productos de manera correcta");
        }
    }
}
