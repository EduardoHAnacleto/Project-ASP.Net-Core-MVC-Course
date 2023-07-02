using WebProjectCourse.Models;

namespace WebProjectCourse.Repository.IRepository;

public interface IProdutoRepository : IRepository<Produto>
{
    void Update(Produto obj);
}
