using Microsoft.AspNetCore.Mvc;
using WebProjectCourse.Data;
using WebProjectCourse.Models;
using WebProjectCourse.Repository.IRepository;

namespace WebProjectCourse.Areas.Admin.Controllers;

[Area("Admin")]
public class CategoriaController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public CategoriaController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public IActionResult Index()
    {
        List<Categoria> objListCategoria = _unitOfWork.Categoria.GetAll().ToList();
        return View(objListCategoria);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Categoria obj)
    {
        if (ModelState.IsValid)
        {
            _unitOfWork.Categoria.Add(obj);
            _unitOfWork.Save();
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
        Categoria? categoriaFromDb = _unitOfWork.Categoria.Get(u => u.Id == id);
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
            _unitOfWork.Categoria.Update(obj);
            _unitOfWork.Save();
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
        Categoria? categoriaFromDb = _unitOfWork.Categoria.Get(u => u.Id == id);
        if (categoriaFromDb == null)
        {
            return NotFound();
        }
        return View(categoriaFromDb);
    }
    [HttpPost, ActionName("Delete")]
    public IActionResult DeletePOST(int? id)
    {
        Categoria obj = _unitOfWork.Categoria.Get(u => u.Id == id);
        if (id == null)
        {
            return NotFound();
        }
        _unitOfWork.Categoria.Remove(obj);
        _unitOfWork.Save();
        TempData["success"] = "Categoria apagada com sucesso.";
        return RedirectToAction("Index");
    }
}
