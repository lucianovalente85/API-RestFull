using Microsoft.EntityFrameworkCore;
using Supermercado.API.Domain.Models;

namespace Supermercado.API.Persistence.Contexts
{
  public class AppDbContext : DbContext
  {
        public AppDbContext(AppDbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Categoria> Categorias { get; set; }
        public Dbset<Produto> Produtos { get; set; }

        protected override void OnModelCreating (ModelBuilder builder)
        {
          base.OnModelCreating(builder);

          builder.Entity<Categoria> ().ToTable ("Categorias");
          builder.Entity<Categoria> ().Haskey (p => p.Id);
          builder.Entity<Categoria> ().Property (p => p.Id).IsRequired ().ValueGeneratedOnAdd ();
          builder.Entity<Categoria> ().Property (p => p.Nome).IsRequired ().HasMaxLength(30);
          builder.Entity<Categoria> ().HasMany (p => p.Produtos).WithOne(p => p.Categoria).HasForeignKey(p => p.CategoriaId);

          builder.Entity<Categoria>().HasDate(
            new Categoria{Id = 100, Nome = "Frutas e Vegetais"},
            new Categoria{Id = 101, Nome = "Lacticínios"}
          );

          builder.Entity<Produto>().ToTable("Produtos");
          builder.Entity<Produto>().Haskey(p => p.Id);
          builder.Entity<Produto>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
          builder.Entity<Produto>().Property(p => p.Nome).IsRequired().HasMaxLength(50);
          builder.Entity<Produto>().Property(p => p.QuantidadePacote).IsRequired();
          builder.Entity<Produto>().Property(p => p.UnidadeMedida).IsRequired();

        }
        
  }
}