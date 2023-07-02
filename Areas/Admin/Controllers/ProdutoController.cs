using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net.Http.Headers;
using WebProjectCourse.Models;
using WebProjectCourse.Models.ViewModel;
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
        ProdutoVM produtoVM = new()
        {
            CategoriaList = _unitOfWork.Categoria
            .GetAll().Select(u => new SelectListItem
            {
                Text = u.Nome,
                Value = u.Id.ToString()
            }),
            Produto = new Produto()
        };
        return View(produtoVM);
    }

    [HttpPost]
    public IActionResult Create(ProdutoVM productVM)
    {
        if (ModelState.IsValid)
        {
            _unitOfWork.Produto.Add(productVM.Produto);
            _unitOfWork.Save();
            TempData["success"] = "Produto criado com sucesso.";
            return RedirectToAction("Index");
        }
        else
        {
            productVM.CategoriaList = _unitOfWork.Categoria
                    .GetAll().Select(u => new SelectListItem
                    {
                        Text = u.Nome,
                        Value = u.Id.ToString()
                    });
            };
            return View(productVM);
        }

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
