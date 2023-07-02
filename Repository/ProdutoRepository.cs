using WebProjectCourse.Data;
using WebProjectCourse.Models;
using WebProjectCourse.Repository.IRepository;

namespace WebProjectCourse.Repository;

public class ProdutoRepository : Repository<Produto>, IProdutoRepository
{
    private AppDbContext _db;

    public ProdutoRepository(AppDbContext db) : base(db)
    {
        _db = db;
    }

    public void Update(Produto obj)
    {
        _db.Produtos.Update(obj);
    }
}
