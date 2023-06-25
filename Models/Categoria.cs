using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebProjectCourse.Models
{
    public class Categoria
    {
        [Key]
        [Display(Name = "Código")]
        public int Id { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 3, ErrorMessage ="Nome deve ter entre 3 e 30 caracteres.")]
        public string Nome { get; set; }
        [Display(Name = "Ordem de display")]
        [Range(1,100,ErrorMessage ="Ordem de display deve ser entre 1 e 100.")]
        public int OrdemDisplay { get; set; }
    }
}
