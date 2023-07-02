namespace WebProjectCourse.Repository.IRepository;

public interface IUnitOfWork
{
    ICategoriaRepository Categoria { get; }
    IProdutoRepository Produto { get; }

    void Save();
}
