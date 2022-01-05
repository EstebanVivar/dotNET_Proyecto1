using Microsoft.AspNetCore.Mvc;
using WebApp.Datos;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly AppDbContext _db;
        public CategoriaController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Categoria> oCategoriaList = _db.Categorias;
            return View(oCategoriaList);
        }

        //GET
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Categoria obj)
        {
            if (obj.Name == obj.displayOrder.ToString())
            {
                ModelState.AddModelError("name", "Los valores de nombre y orden no p8ueden ser los mismos");
            }
            if (ModelState.IsValid)
            {
                _db.Categorias.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Categoria creada exitosamente";
                return RedirectToAction("Index");
            }
            else
            {
                return View(obj);
            }
        }

        //GET
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoriaDB = _db.Categorias.Find(id);

            //var categoriaDBFirst = _db.Categorias.FirstOrDefault(u=>u.id==id);
            //var categoriaDBSingle = _db.Categorias.SingleOrDefault(u => u.id == id);
            if (categoriaDB == null)
            {
                return NotFound();
            }
            return View(categoriaDB);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Categoria obj)
        {
            if (obj.Name == obj.displayOrder.ToString())
            {
                ModelState.AddModelError("name", "Los valores de nombre y orden no p8ueden ser los mismos");
            }
            if (ModelState.IsValid)
            {
                _db.Categorias.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Categoria actualizada exitosamente";
                return RedirectToAction("Index");
            }
            else
            {
                return View(obj);
            }
        }

        //GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoriaDB = _db.Categorias.Find(id);
            if (categoriaDB == null)
            {
                return NotFound();
            }
            return View(categoriaDB);
        }
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.Categorias.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Categorias.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Categoria eliminada exitosamente";
            return RedirectToAction("Index");
        }
    }
}

