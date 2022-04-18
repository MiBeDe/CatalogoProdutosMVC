using CatalogoProdutosMVC.Models;

namespace CatalogoProdutosMVC.Repositories.Contracts
{
    public interface IProdutoRepository
    {
        List<ProdutoModel> GetProdutos();
    }
}
