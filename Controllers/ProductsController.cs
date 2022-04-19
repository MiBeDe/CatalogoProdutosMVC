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
            string categoria = HttpContext.Request.Query["categoria"].ToString();
            string subCategoria = HttpContext.Request.Query["subcategoria"].ToString();
            
            var produtos = await _produtoRepository.GetProdutos(categoria, subCategoria);

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
