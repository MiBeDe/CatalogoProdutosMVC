namespace CatalogoProdutosMVC.Repositories.Contracts
{
    public interface IEstoqueRepository
    {
        Task AlterarQuantidade(string idProduto, int quantidade);
    }
}
