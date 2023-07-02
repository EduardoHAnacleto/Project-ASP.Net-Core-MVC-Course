using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebProjectCourse.Models.ViewModel;

public class ProdutoVM
{
    public Produto Produto { get; set; }
    [ValidateNever]
    public IEnumerable<SelectListItem> CategoriaList { get; set; }
}
