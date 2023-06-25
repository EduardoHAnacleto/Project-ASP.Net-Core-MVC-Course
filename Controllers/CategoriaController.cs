using Microsoft.AspNetCore.Mvc;
using WebProjectCourse.Data;
using WebProjectCourse.Models;

namespace WebProjectCourse.Controllers;

public class CategoriaController : Controller
{
    private readonly AppDbContext _db;
    public CategoriaController(AppDbContext db)
    {
        _db = db;
    }
    public IActionResult Index()
    {
        List<Categoria> objListCategoria = _db.Categorias.ToList();
        return View(objListCategoria);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Categoria obj)
    {
        if(ModelState.IsValid)
        {
            _db.Categorias.Add(obj);
            _db.SaveChanges();
            TempData["success"] = "Categoria criada com sucesso.";
            return RedirectToAction("Index");
        }
        return View();
    }

    public IActionResult Edit(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }
        Categoria? categoriaFromDb = _db.Categorias.Find(id);
        if (categoriaFromDb == null)
        {
            return NotFound();
        }
        return View(categoriaFromDb);
    }
    [HttpPost]
    public IActionResult Edit(Categoria obj)
    {
        if (ModelState.IsValid)
        {
            _db.Categorias.Update(obj);
            _db.SaveChanges();
            TempData["success"] = "Categoria alterada com sucesso.";
            return RedirectToAction("Index");
        }
        return View();
    }

    public IActionResult Delete(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }
        Categoria? categoriaFromDb = _db.Categorias.Find(id);
        if (categoriaFromDb == null)
        {
            return NotFound();
        }
        return View(categoriaFromDb);
    }
    [HttpPost, ActionName("Delete")]
    public IActionResult DeletePOST(int? id)
    {
        Categoria obj = _db.Categorias.Find(id);
        if (id == null)
        {
            return NotFound();
        }
        _db.Categorias.Remove(obj);
        _db.SaveChanges();
        TempData["success"] = "Categoria apagada com sucesso.";
        return RedirectToAction("Index");
    }
}
