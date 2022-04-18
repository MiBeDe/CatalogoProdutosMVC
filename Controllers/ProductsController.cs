using Microsoft.AspNetCore.Mvc;

namespace CatalogoProdutosMVC.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Cadastro()
        {
            return View();
        }

        public IActionResult Pedidos()
        {
            return View();
        }
    }
}
