using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebProjectCourse.Models;

public class Produto
{
    [Key]
    [Display(Name = "Código")]
    public int Id { get; set; }
    [Required]
    [StringLength(30, MinimumLength = 3, ErrorMessage = "Nome deve ter entre 3 e 30 caracteres.")]
    public string Titulo { get; set; }
    public string Descricao { get; set; }
    [Required]
    public string ISBN { get; set; }
    [Required]
    public string Autor { get; set; }

    [Required]
    [Display(Name = "Lista de preço")]
    [Range(1, 1000)]
    public double ListaPreco { get; set; }

    [Required]
    [Display(Name = "Preço")]
    [Range(1, 1000)]
    public double Preco { get; set; }

    [Required]
    [Display(Name = "Lista de preço para 50+")]
    [Range(1, 1000)]
    public double Preco50 { get; set; }

    [Required]
    [Display(Name = "Lista de preço para 100+")]
    [Range(1, 1000)]
    public double Preco100 { get; set; }

    [Display(Name = "Categoria")]
    public int CategoriaId { get; set; }
    [ForeignKey("CategoriaId")]
    [ValidateNever]
    public Produto Categoria { get; set; }

    [ValidateNever]
    public string UrlImagem { get; set; }
}
