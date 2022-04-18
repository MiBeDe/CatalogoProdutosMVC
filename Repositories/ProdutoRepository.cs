using CatalogoProdutosMVC.Database;
using CatalogoProdutosMVC.Models;
using CatalogoProdutosMVC.Repositories.Contracts;

namespace CatalogoProdutosMVC.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly CatalogoProdutosDbContext _context;

        public ProdutoRepository(CatalogoProdutosDbContext context)
        {
            _context = context;
        }
        public List<ProdutoModel> GetProdutos()
        {
            var produtos = _context.ProdutosWeb.ToList().OrderBy(x => x.IdProd);

            List<ProdutoModel> produtosList = new List<ProdutoModel>();
            produtosList = produtos.ToList();

            return produtosList;
        }
    }

}
