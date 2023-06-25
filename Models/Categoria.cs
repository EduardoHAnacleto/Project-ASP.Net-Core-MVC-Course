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
        [StringLength(30, MinimumLength = 3)]
        public string Nome { get; set; }
        [Display(Name = "Ordem de display")]
        public int OrdemDisplay { get; set; }
    }
}
