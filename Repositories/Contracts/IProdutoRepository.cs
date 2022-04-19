using CatalogoProdutosMVC.Models;

namespace CatalogoProdutosMVC.Repositories.Contracts
{
    public interface IProdutoRepository
    {
        Task<List<ProdutoModel>> GetProdutos(string categoria, string subCategoria);
        Task CadastrarProduto(ProdutoModel produto, IFormFile Imagem1, IFormFile Imagem2, IFormFile Imagem3); 
    }
}
