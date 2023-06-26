using System.Linq.Expressions;
using WebProjectCourse.Models;

namespace WebProjectCourse.Repository.IRepository;

public interface ICategoriaRepository : IRepository<Categoria>
{
    void Update(Categoria obj);
}
