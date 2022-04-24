using AutoMapper;
using CatalogoProdutosMVC.DTO;
using CatalogoProdutosMVC.Models;
using CatalogoProdutosMVC.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace CatalogoProdutosMVC.Controllers
{
    public class PedidoController : Controller      
    {
        private readonly IPedidoRepository _pedidoRepository;

        private readonly IMapper _mapper;

        public PedidoController(IPedidoRepository pedidoRepository, IMapper mapper, IProdutoRepository produtoRepository)
        {
            _pedidoRepository = pedidoRepository;
            _mapper = mapper;
        }

        public async Task<IActionResult> Pedidos()
        {
            var pedidos = await _pedidoRepository.GetPedidos();
            return View(pedidos);
        }


        [HttpPost]
        public async Task<IActionResult> RealizarPedido(PedidoDTO pedido)
        {
            PedidoModel pedidoModel = _mapper.Map<PedidoDTO, PedidoModel>(pedido);

        
            await _pedidoRepository.IncluirPedido(pedidoModel);

            return RedirectToAction("Index", "Products");
        }

        [HttpPost]
        public async Task<IActionResult> DeletePedido(PedidoDTO pedido)
        {
            PedidoModel pedidoModel = _mapper.Map<PedidoDTO, PedidoModel>(pedido);
            await _pedidoRepository.DeletePedido(pedidoModel);

            return RedirectToAction(nameof(Pedidos));
        }

        [HttpPost]
        public async Task<IActionResult> SepararPedido (PedidoDTO pedido)
        {
            var pedidoObj = await _pedidoRepository.GetPedidoById(pedido.IdPedido);
            pedidoObj.StatusPedido = 1;

            await _pedidoRepository.AlterarStatusPedido(pedidoObj);

            return RedirectToAction(nameof(Pedidos));
        }

        public async Task<IActionResult> EnviarPedido (PedidoDTO pedido)
        {
            var pedidoObj = await _pedidoRepository.GetPedidoById(pedido.IdPedido);
            pedidoObj.StatusPedido = 2;
            pedidoObj.DataEnvio = DateTime.Now.ToString();

            await _pedidoRepository.AlterarStatusPedido(pedidoObj);

            return RedirectToAction(nameof(Pedidos));
        }

        public async Task<IActionResult> PedidoPago (PedidoDTO pedido)
        {
            var pedidoObj = await _pedidoRepository.GetPedidoById(pedido.IdPedido);
            pedidoObj.StatusPagamento = 1;

            await _pedidoRepository.AlterarStatusPagamento(pedidoObj);

            return RedirectToAction(nameof(Pedidos));
        }
    }
}
