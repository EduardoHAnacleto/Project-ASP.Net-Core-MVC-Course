using WebProjectCourse.Data;
using WebProjectCourse.Repository.IRepository;

namespace WebProjectCourse.Repository;

public class UnitOfWork : IUnitOfWork
{
    private AppDbContext _db;
    public ICategoriaRepository Categoria { get; private set; }
    public IProdutoRepository Produto { get; private set; }

    public UnitOfWork(AppDbContext db)
    {
        _db = db;
        Categoria = new CategoriaRepository(_db);
        Produto = new ProdutoRepository(_db);
    }


    public void Save()
    {
        _db.SaveChanges();
    }
}
