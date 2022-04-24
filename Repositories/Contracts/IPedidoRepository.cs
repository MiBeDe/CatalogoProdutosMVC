using CatalogoProdutosMVC.Models;

namespace CatalogoProdutosMVC.Repositories.Contracts
{
    public interface IPedidoRepository
    {
        Task<List<PedidoModel>> GetPedidos();
        Task IncluirPedido(PedidoModel pedido);

    }
}
