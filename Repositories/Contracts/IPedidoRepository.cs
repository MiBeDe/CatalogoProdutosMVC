using CatalogoProdutosMVC.Models;

namespace CatalogoProdutosMVC.Repositories.Contracts
{
    public interface IPedidoRepository
    {
        Task IncluirPedido(PedidoModel pedido);

    }
}
