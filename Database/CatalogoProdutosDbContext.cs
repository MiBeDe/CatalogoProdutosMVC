using CatalogoProdutosMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace CatalogoProdutosMVC.Database
{
    public class CatalogoProdutosDbContext : DbContext
    {
        public CatalogoProdutosDbContext(DbContextOptions<CatalogoProdutosDbContext> options) : base(options)
        {
        }

        public DbSet<ProdutoModel> ProdutosWeb { get; set; }
    }
}
