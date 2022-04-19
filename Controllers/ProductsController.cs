using CatalogoProdutosMVC.Models;
using CatalogoProdutosMVC.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace CatalogoProdutosMVC.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProductsController(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<IActionResult> Index()
        {
            var produtos = await _produtoRepository.GetProdutos();

            return View(produtos);
        }

        public IActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Cadastro(ProdutoModel produto, IFormFile Imagem1, IFormFile Imagem2, IFormFile Imagem3)
        {
            await _produtoRepository.CadastrarProduto(produto, Imagem1, Imagem2, Imagem3);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Pedidos()
        {
            return View();
        }
    }
}
