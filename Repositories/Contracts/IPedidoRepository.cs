using CatalogoProdutosMVC.DTO;
using CatalogoProdutosMVC.Models;

namespace CatalogoProdutosMVC.Repositories.Contracts
{
    public interface IPedidoRepository
    {
        Task<List<PedidoDTO>> GetPedidos();
        Task<PedidoModel> GetPedidoById(string idPedido);
        Task IncluirPedido(PedidoModel pedido);
        Task DeletePedido(PedidoModel pedido);
        Task AlterarStatusPedido(PedidoModel pedido);
        Task AlterarStatusPagamento(PedidoModel pedido);
    }
}
