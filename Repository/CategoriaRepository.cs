using System.Linq.Expressions;
using WebProjectCourse.Data;
using WebProjectCourse.Models;
using WebProjectCourse.Repository.IRepository;

namespace WebProjectCourse.Repository;

public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
{
    private AppDbContext _db;

    public CategoriaRepository(AppDbContext db) : base(db)
    {
        _db = db;
    }

    public void Update(Categoria obj)
    {
        _db.Categorias.Update(obj);
    }
}
