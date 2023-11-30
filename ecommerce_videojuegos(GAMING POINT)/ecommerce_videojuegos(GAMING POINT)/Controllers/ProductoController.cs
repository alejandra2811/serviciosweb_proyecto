using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Linq;
using System.Threading.Tasks;
namespace ecommerce_videojuegos_GAMING_POINT_.Controllers
{
    public class AlumnosController : Controller
    {
        private readonly AlumnosContext _alumnosContext;
        public AlumnosController(AlumnosContext alumnosContext)
        {
            this._alumnosContext = alumnosContext;
        }
        public IActionResult List()
        {
            var listResult = _alumnosContext.Alumnos.ToList();

            AlumnosListViewModel model = new AlumnosListViewModel();
            model.List = (from a in listResult
                          select new AlumnosViewModel()
                          {
                              ID = a.ID,
                              Nombre = a.Nombre,
                              Apellido = a.Apellido,
                              DNI = a.DNI,
                              FechaNacimiento = a.FechaNacimiento,
                              Correo = a.Correo,
                              Celular = a.Celular,
                              NombreContacto = a.NombreContacto,
                              TelefonoContacto = a.TelefonoContacto,
                              Estado = a.Estado
                          }).ToList();
            return View(model);
        }

        public IActionResult Add()
        {
            AlumnosViewModel model = new AlumnosViewModel();
            return View(model);
        }

        public IActionResult AddSavedAction(AlumnosViewModel model)
        {  
            AlumnosEntity entity = new AlumnosEntity();
            entity.Nombre = model.Nombre;
            entity.Apellido = model.Apellido;
            entity.DNI = model.DNI.HasValue ? model.DNI.Value : 0;
            entity.FechaNacimiento = DateTime.Now;
            entity.Correo = model.Correo;
            entity.Celular = model.Celular.HasValue ? model.Celular.Value : 0;
            entity.NombreContacto = model.NombreContacto;
            entity.TelefonoContacto = model.TelefonoContacto.HasValue ? model.TelefonoContacto.Value : 0;
            entity.Estado = "Activo";
            _alumnosContext.Alumnos.Add(entity);
            _alumnosContext.SaveChanges();
            return RedirectToAction("List", "Alumnos");
        }
        public IActionResult Edit(int ID)
        {
            var findAlumnos = _alumnosContext.Alumnos.Where(a => a.ID == ID).SingleOrDefault();
            var model = new AlumnosViewModel();
            model.ID = findAlumnos.ID;
            model.Nombre = findAlumnos.Nombre;
            model.Apellido = findAlumnos.Apellido;
            model.DNI = findAlumnos.DNI;
            model.FechaNacimiento = findAlumnos.FechaNacimiento;
            model.Correo = findAlumnos.Correo;
            model.Celular = findAlumnos.Celular;
            model.NombreContacto = findAlumnos.NombreContacto;
            model.TelefonoContacto = findAlumnos.TelefonoContacto;
            return View(model);
        }
        [HttpPost]
        public IActionResult EditSaved(AlumnosViewModel model)
        {
            var findAlumnos = _alumnosContext.Alumnos.SingleOrDefault(a => a.ID == model.ID);
            if (findAlumnos != null)
            {
                findAlumnos.Nombre = model.Nombre;
                findAlumnos.Apellido = model.Apellido;
                findAlumnos.DNI = model.DNI.HasValue ? model.DNI.Value : 0;
                findAlumnos.FechaNacimiento = DateTime.Now;
                findAlumnos.Correo = model.Correo;
                findAlumnos.Celular = model.Celular.HasValue ? model.Celular.Value : 0;
                findAlumnos.NombreContacto = model.NombreContacto;
                findAlumnos.TelefonoContacto = model.TelefonoContacto.HasValue ? model.TelefonoContacto.Value : 0;  
                _alumnosContext.SaveChanges();
            }

            return RedirectToAction("List", "Alumnos");
        }
        [HttpGet]
        public JsonResult DeleteAlumnos(int ID)
        {
            var findAlumnos = _alumnosContext.Alumnos.SingleOrDefault(a => a.ID == ID);
            _alumnosContext.Alumnos.Remove(findAlumnos);
            _alumnosContext.SaveChanges();
            return Json("Se eliminó al alumno de manera correcta");
        }
    }
}
