using AutoMapper;
using CatalogoProdutosMVC.DTO;
using CatalogoProdutosMVC.Models;
using CatalogoProdutosMVC.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace CatalogoProdutosMVC.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMapper _mapper;

        public ProductsController(IProdutoRepository produtoRepository, IMapper mapper)
        {
            _produtoRepository = produtoRepository;
            _mapper = mapper;
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


        public async Task<IActionResult> Detalhes(string idProd)
        {
            var produto = await _produtoRepository.GetProdutoById(idProd);

            ProdutoDTO produtoDTO = _mapper.Map<ProdutoModel, ProdutoDTO>(produto);

            var produtoTamanho = produto.Tamanho.Split('-');
            produtoDTO.checksTamanhos = new ChecksTamanhosDTO();

            foreach (var item in produtoTamanho)
            {
                switch (item.Trim())
                {
                    case "PP":
                        produtoDTO.checksTamanhos.PP = true;
                        break;
                    case "P":
                        produtoDTO.checksTamanhos.P = true;
                        break;
                    case "M":
                        produtoDTO.checksTamanhos.M = true;
                        break;
                    case "G":
                        produtoDTO.checksTamanhos.G = true;
                        break;
                    case "GG":
                        produtoDTO.checksTamanhos.GG = true;
                        break;
                    case "XG":
                        produtoDTO.checksTamanhos.XG = true;
                        break;
                    case "XGG":
                        produtoDTO.checksTamanhos.XGG = true;
                        break;
                    case "EG":
                        produtoDTO.checksTamanhos.EG = true;
                        break;
                    case "EGG":
                        produtoDTO.checksTamanhos.EGG = true;
                        break;                       
                    default:
                        break;
                }
            }

            return View(produtoDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Cadastro(ProdutoDTO produto, IFormFile Imagem1, IFormFile Imagem2, IFormFile Imagem3)
        {
            #region Verifica Check Tamanho Roupa
            if (produto.checksTamanhos.P == true)
            {
                if (produto.Tamanho == null)
                {
                    produto.Tamanho += "P";
                }
                else
                {
                    produto.Tamanho += " - P";
                }
            }

            if (produto.checksTamanhos.PP == true)
            {
                if (produto.Tamanho == null)
                {
                    produto.Tamanho += "PP";
                }
                else
                {
                    produto.Tamanho += " - PP";
                }
            }

            if (produto.checksTamanhos.M == true)
            {
                if (produto.Tamanho == null)
                {
                    produto.Tamanho += "M";
                }
                else
                {
                    produto.Tamanho += " - M";
                }
            }

            if (produto.checksTamanhos.G == true)
            {
                if (produto.Tamanho == null)
                {
                    produto.Tamanho += "G";
                }
                else
                {
                    produto.Tamanho += " - G";
                }
            }

            if (produto.checksTamanhos.GG == true)
            {
                if (produto.Tamanho == null)
                {
                    produto.Tamanho += "GG";
                }
                else
                {
                    produto.Tamanho += " - GG";
                }
            }

            if (produto.checksTamanhos.XG == true)
            {
                if (produto.Tamanho == null)
                {
                    produto.Tamanho += "XG";
                }
                else
                {
                    produto.Tamanho += " - XG";
                }
            }

            if (produto.checksTamanhos.XGG == true)
            {
                if (produto.Tamanho == null)
                {
                    produto.Tamanho += "XGG";
                }
                else
                {
                    produto.Tamanho += " - XGG";
                }
            }

            if (produto.checksTamanhos.EG == true)
            {
                if (produto.Tamanho == null)
                {
                    produto.Tamanho += "EG";
                }
                else
                {
                    produto.Tamanho += " - EG";
                }
            }

            if (produto.checksTamanhos.EGG == true)
            {
                if (produto.Tamanho == null)
                {
                    produto.Tamanho += "EGG";
                }
                else
                {
                    produto.Tamanho += " - EGG";
                }
            }
            #endregion

            #region Verifica Check Tamanho Calçado
            if (produto.checksTamanhos.Tamanho33 == true)
            {
                if (produto.Tamanho == null)
                {
                    produto.Tamanho += "33";
                }
                else
                {
                    produto.Tamanho += " - 33";
                }
            }

            if (produto.checksTamanhos.Tamanho34 == true)
            {
                if (produto.Tamanho == null)
                {
                    produto.Tamanho += "34";
                }
                else
                {
                    produto.Tamanho += " - 34";
                }
            }

            if (produto.checksTamanhos.Tamanho35 == true)
            {
                if (produto.Tamanho == null)
                {
                    produto.Tamanho += "35";
                }
                else
                {
                    produto.Tamanho += " - 35";
                }
            }

            if (produto.checksTamanhos.Tamanho36 == true)
            {
                if (produto.Tamanho == null)
                {
                    produto.Tamanho += "36";
                }
                else
                {
                    produto.Tamanho += " - 36";
                }
            }

            if (produto.checksTamanhos.Tamanho37 == true)
            {
                if (produto.Tamanho == null)
                {
                    produto.Tamanho += "37";
                }
                else
                {
                    produto.Tamanho += " - 37";
                }
            }

            if (produto.checksTamanhos.Tamanho38 == true)
            {
                if (produto.Tamanho == null)
                {
                    produto.Tamanho += "38";
                }
                else
                {
                    produto.Tamanho += " - 38";
                }
            }

            if (produto.checksTamanhos.Tamanho39 == true)
            {
                if (produto.Tamanho == null)
                {
                    produto.Tamanho += "39";
                }
                else
                {
                    produto.Tamanho += " - 39";
                }
            }

            if (produto.checksTamanhos.Tamanho40 == true)
            {
                if (produto.Tamanho == null)
                {
                    produto.Tamanho += "40";
                }
                else
                {
                    produto.Tamanho += " - 40";
                }
            }

            if (produto.checksTamanhos.Tamanho41 == true)
            {
                if (produto.Tamanho == null)
                {
                    produto.Tamanho += "41";
                }
                else
                {
                    produto.Tamanho += " - 41";
                }
            }

            if (produto.checksTamanhos.Tamanho42 == true)
            {
                if (produto.Tamanho == null)
                {
                    produto.Tamanho += "42";
                }
                else
                {
                    produto.Tamanho += " - 42";
                }
            }

            if (produto.checksTamanhos.Tamanho43 == true)
            {
                if (produto.Tamanho == null)
                {
                    produto.Tamanho += "43";
                }
                else
                {
                    produto.Tamanho += " - 43";
                }
            }
            #endregion


            ProdutoModel produtoModel = _mapper.Map<ProdutoDTO, ProdutoModel>(produto);
            
            await _produtoRepository.CadastrarProduto(produtoModel, Imagem1, Imagem2, Imagem3);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Pedidos()
        {
            return View();
        }
    }
}
