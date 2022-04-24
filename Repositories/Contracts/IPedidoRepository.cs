using CatalogoProdutosMVC.DTO;
using CatalogoProdutosMVC.Models;

namespace CatalogoProdutosMVC.Repositories.Contracts
{
    public interface IPedidoRepository
    {
        Task<List<PedidoDTO>> GetPedidos();
        Task IncluirPedido(PedidoModel pedido);

    }
}
