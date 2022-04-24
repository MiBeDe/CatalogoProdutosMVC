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
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMapper _mapper;

        public PedidoController(IPedidoRepository pedidoRepository, IMapper mapper, IProdutoRepository produtoRepository)
        {
            _pedidoRepository = pedidoRepository;
            _produtoRepository = produtoRepository;
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
    }
}
