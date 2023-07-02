using Microsoft.EntityFrameworkCore;
using WebProjectCourse.Models;

namespace WebProjectCourse.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }

    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Produto> Produtos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categoria>()
            .HasData(
            new Categoria { Id = 1, Nome = "Ação", OrdemDisplay = 1},
            new Categoria { Id = 2, Nome = "SciFi", OrdemDisplay = 2 },
            new Categoria { Id = 3, Nome = "História", OrdemDisplay = 3 }
            );

        modelBuilder.Entity<Produto>()
            .HasData(
            new Produto { 
                Id = 1,
                Titulo = "The Continental",
                Autor = "John Wick",
                Descricao = "Dont hurt the dog",
                ISBN = "ABC1234567",
                ListaPreco = 40,
                Preco = 30,
                Preco50 = 25,
                Preco100 = 20,
                CategoriaId = 1,
                UrlImagem = ""
            },

            new Produto { 
                Id = 2,
                Titulo = "Star Wars Tale",
                Autor = "Anakin Skywalker",
                Descricao = "The dark force awakens",
                ISBN = "ATT8798789",
                ListaPreco = 20,
                Preco = 15,
                Preco50 = 10,
                Preco100 = 8,
                CategoriaId = 2,
                UrlImagem = ""
            },

            new Produto {
                Id = 3,
                Titulo = "Segunda Guerra Mundial",
                Autor = "Soldado Ryan",
                Descricao = "Pistola contra um tanque",
                ISBN = "XZY46846",
                ListaPreco = 45,
                Preco = 30,
                Preco50 = 28,
                Preco100 = 24,
                CategoriaId = 3,
                UrlImagem = ""
            },

            new Produto { 
                Id = 4,
                Titulo = "Imperio Romano",
                Autor = "Maximus Decimus Meridius",
                Descricao = "Eu terei minha vingança",
                ISBN = "AEC656454",
                ListaPreco = 50,
                Preco = 30,
                Preco50 = 25,
                Preco100 = 20,
                CategoriaId = 1,
                UrlImagem = ""
            },

            new Produto
            {
                Id = 5,
                Titulo = "WarHammer 40000",
                Autor = "Miriam Smith",
                Descricao = "Viva ao imperador",
                ISBN = "WH40000",
                ListaPreco = 60,
                Preco = 40,
                Preco50 = 35,
                Preco100 = 30,
                CategoriaId = 2,
                UrlImagem = ""
            }

            );

        modelBuilder.Entity<Produto>()
            .HasOne(e => e.Categoria)
            .WithMany()
            .OnDelete(DeleteBehavior.Restrict);
            
    }
}
