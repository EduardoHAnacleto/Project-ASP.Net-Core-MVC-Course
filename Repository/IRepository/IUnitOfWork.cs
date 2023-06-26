namespace WebProjectCourse.Repository.IRepository;

public interface IUnitOfWork
{
    ICategoriaRepository Categoria { get; }

    void Save();
}
