using Microsoft.EntityFrameworkCore;
using WebProjectCourse.Models;

namespace WebProjectCourse.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }

    public DbSet<Categoria> Categorias { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categoria>().HasData(
            new Categoria { Id = 1, Nome = "Ação", OrdemDisplay = 1},
            new Categoria { Id = 2, Nome = "SciFi", OrdemDisplay = 2 },
            new Categoria { Id = 3, Nome = "História", OrdemDisplay = 3 }
            );
    }
}
