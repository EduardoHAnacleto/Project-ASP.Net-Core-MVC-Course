using Microsoft.AspNetCore.Mvc;
using WebProjectCourse.Models;
using WebProjectCourse.Repository.IRepository;

namespace WebProjectCourse.Areas.Admin.Controllers;

[Area("Admin")]
public class ProdutoController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public ProdutoController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public IActionResult Index()
    {
        List<Produto> objListProduto = _unitOfWork.Produto.GetAll().ToList();
        return View(objListProduto);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Produto obj)
    {
        if (ModelState.IsValid)
        {
            _unitOfWork.Produto.Add(obj);
            _unitOfWork.Save();
            TempData["success"] = "Produto criado com sucesso.";
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
        Produto? produtoFromDb = _unitOfWork.Produto.Get(u => u.Id == id);
        if (produtoFromDb == null)
        {
            return NotFound();
        }
        return View(produtoFromDb);
    }
    [HttpPost]
    public IActionResult Edit(Produto obj)
    {
        if (ModelState.IsValid)
        {
            _unitOfWork.Produto.Update(obj);
            _unitOfWork.Save();
            TempData["success"] = "Produto alterado com sucesso.";
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
        Produto? produtoFromDb = _unitOfWork.Produto.Get(u => u.Id == id);
        if (produtoFromDb == null)
        {
            return NotFound();
        }
        return View(produtoFromDb);
    }
    [HttpPost, ActionName("Delete")]
    public IActionResult DeletePOST(int? id)
    {
        Produto obj = _unitOfWork.Produto.Get(u => u.Id == id);
        if (id == null)
        {
            return NotFound();
        }
        _unitOfWork.Produto.Remove(obj);
        _unitOfWork.Save();
        TempData["success"] = "Produto apagado com sucesso.";
        return RedirectToAction("Index");
    }
}
