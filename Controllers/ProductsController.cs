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

      
        public async Task<IActionResult> Index(string cat, string sub)
        {
            var produtos = await _produtoRepository.GetProdutos(cat, sub);

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
            produtoDTO.pedido = new PedidoDTO();

            foreach (var item in produtoTamanho)
            {
                switch (item.Trim())
                {
                    case "UN":
                        produtoDTO.checksTamanhos.UN = true;
                        ViewBag.tamanho = "Letra";
                        break;
                    case "PP":
                        produtoDTO.checksTamanhos.PP = true;
                        ViewBag.tamanho = "Letra";
                        break;
                    case "P":
                        produtoDTO.checksTamanhos.P = true;
                        ViewBag.tamanho = "Letra";
                        break;
                    case "M":
                        produtoDTO.checksTamanhos.M = true;
                        ViewBag.tamanho = "Letra";
                        break;
                    case "G":
                        produtoDTO.checksTamanhos.G = true;
                        ViewBag.tamanho = "Letra";
                        break;
                    case "GG":
                        produtoDTO.checksTamanhos.GG = true;
                        ViewBag.tamanho = "Letra";
                        break;
                    case "XG":
                        produtoDTO.checksTamanhos.XG = true;
                        ViewBag.tamanho = "Letra";
                        break;
                    case "XGG":
                        produtoDTO.checksTamanhos.XGG = true;
                        ViewBag.tamanho = "Letra";
                        break;
                    case "EG":
                        produtoDTO.checksTamanhos.EG = true;
                        ViewBag.tamanho = "Letra";
                        break;
                    case "EGG":
                        produtoDTO.checksTamanhos.EGG = true;
                        ViewBag.tamanho = "Letra";
                        break;
                    case "33":
                        produtoDTO.checksTamanhos.Tamanho33 = true;
                        ViewBag.tamanho = "Numero";
                        break;
                    case "34":
                        produtoDTO.checksTamanhos.Tamanho34 = true;
                        ViewBag.tamanho = "Numero";
                        break;
                    case "35":
                        produtoDTO.checksTamanhos.Tamanho35 = true;
                        ViewBag.tamanho = "Numero";
                        break;
                    case "36":
                        produtoDTO.checksTamanhos.Tamanho36 = true;
                        ViewBag.tamanho = "Numero";
                        break;
                    case "37":
                        produtoDTO.checksTamanhos.Tamanho37 = true;
                        ViewBag.tamanho = "Numero";
                        break;
                    case "38":
                        produtoDTO.checksTamanhos.Tamanho38 = true;
                        ViewBag.tamanho = "Numero";
                        break;
                    case "39":
                        produtoDTO.checksTamanhos.Tamanho39 = true;
                        ViewBag.tamanho = "Numero";
                        break;
                    case "40":
                        produtoDTO.checksTamanhos.Tamanho40 = true;
                        ViewBag.tamanho = "Numero";
                        break;
                    case "41":
                        produtoDTO.checksTamanhos.Tamanho41 = true;
                        ViewBag.tamanho = "Numero";
                        break;
                    case "42":
                        produtoDTO.checksTamanhos.Tamanho42 = true;
                        ViewBag.tamanho = "Numero";
                        break;
                    case "43":
                        produtoDTO.checksTamanhos.Tamanho43 = true;
                        ViewBag.tamanho = "Numero";
                        break;
                    case "44":
                        produtoDTO.checksTamanhos.Tamanho44 = true;
                        ViewBag.tamanho = "Numero";
                        break;
                    case "45":
                        produtoDTO.checksTamanhos.Tamanho45 = true;
                        ViewBag.tamanho = "Numero";
                        break;
                    case "46":
                        produtoDTO.checksTamanhos.Tamanho46 = true;
                        ViewBag.tamanho = "Numero";
                        break;
                    case "47":
                        produtoDTO.checksTamanhos.Tamanho47 = true;
                        ViewBag.tamanho = "Numero";
                        break;
                    case "48":
                        produtoDTO.checksTamanhos.Tamanho48 = true;
                        ViewBag.tamanho = "Numero";
                        break;
                    case "49":
                        produtoDTO.checksTamanhos.Tamanho49 = true;
                        ViewBag.tamanho = "Numero";
                        break;
                    case "50":
                        produtoDTO.checksTamanhos.Tamanho50 = true;
                        ViewBag.tamanho = "Numero";
                        break;
                    case "51":
                        produtoDTO.checksTamanhos.Tamanho51 = true;
                        ViewBag.tamanho = "Numero";
                        break;
                    case "52":
                        produtoDTO.checksTamanhos.Tamanho52 = true;
                        ViewBag.tamanho = "Numero";
                        break;
                    case "53":
                        produtoDTO.checksTamanhos.Tamanho53 = true;
                        ViewBag.tamanho = "Numero";
                        break;
                    case "54":
                        produtoDTO.checksTamanhos.Tamanho54 = true;
                        ViewBag.tamanho = "Numero";
                        break;
                    case "55":
                        produtoDTO.checksTamanhos.Tamanho55 = true;
                        ViewBag.tamanho = "Numero";
                        break;
                    case "56":
                        produtoDTO.checksTamanhos.Tamanho56 = true;
                        ViewBag.tamanho = "Numero";
                        break;
                    case "57":
                        produtoDTO.checksTamanhos.Tamanho57 = true;
                        ViewBag.tamanho = "Numero";
                        break;
                    case "58":
                        produtoDTO.checksTamanhos.Tamanho58 = true;
                        ViewBag.tamanho = "Numero";
                        break;
                    case "59":
                        produtoDTO.checksTamanhos.Tamanho59 = true;
                        ViewBag.tamanho = "Numero";
                        break;
                    case "60":
                        produtoDTO.checksTamanhos.Tamanho60 = true;
                        ViewBag.tamanho = "Numero";
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
            #region Verifica Check Tamanho por Letra

            if (produto.checksTamanhos.UN == true)
            {
                if (produto.Tamanho == null)
                {
                    produto.Tamanho += "UN";
                }
                else
                {
                    produto.Tamanho += " - UN";
                }
            }

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

            #region Verifica Check Tamanho por Numero
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

            if (produto.checksTamanhos.Tamanho44 == true)
            {
                if (produto.Tamanho == null)
                {
                    produto.Tamanho += "44";
                }
                else
                {
                    produto.Tamanho += " - 44";
                }
            }

            if (produto.checksTamanhos.Tamanho45 == true)
            {
                if (produto.Tamanho == null)
                {
                    produto.Tamanho += "45";
                }
                else
                {
                    produto.Tamanho += " - 45";
                }
            }

            if (produto.checksTamanhos.Tamanho46 == true)
            {
                if (produto.Tamanho == null)
                {
                    produto.Tamanho += "46";
                }
                else
                {
                    produto.Tamanho += " - 46";
                }
            }

            if (produto.checksTamanhos.Tamanho47 == true)
            {
                if (produto.Tamanho == null)
                {
                    produto.Tamanho += "47";
                }
                else
                {
                    produto.Tamanho += " - 47";
                }
            }

            if (produto.checksTamanhos.Tamanho48 == true)
            {
                if (produto.Tamanho == null)
                {
                    produto.Tamanho += "48";
                }
                else
                {
                    produto.Tamanho += " - 48";
                }
            }

            if (produto.checksTamanhos.Tamanho49 == true)
            {
                if (produto.Tamanho == null)
                {
                    produto.Tamanho += "49";
                }
                else
                {
                    produto.Tamanho += " - 49";
                }
            }

            if (produto.checksTamanhos.Tamanho50 == true)
            {
                if (produto.Tamanho == null)
                {
                    produto.Tamanho += "50";
                }
                else
                {
                    produto.Tamanho += " - 50";
                }
            }

            if (produto.checksTamanhos.Tamanho51 == true)
            {
                if (produto.Tamanho == null)
                {
                    produto.Tamanho += "51";
                }
                else
                {
                    produto.Tamanho += " - 51";
                }
            }

            if (produto.checksTamanhos.Tamanho52 == true)
            {
                if (produto.Tamanho == null)
                {
                    produto.Tamanho += "52";
                }
                else
                {
                    produto.Tamanho += " - 52";
                }
            }

            if (produto.checksTamanhos.Tamanho53 == true)
            {
                if (produto.Tamanho == null)
                {
                    produto.Tamanho += "53";
                }
                else
                {
                    produto.Tamanho += " - 53";
                }
            }

            if (produto.checksTamanhos.Tamanho54 == true)
            {
                if (produto.Tamanho == null)
                {
                    produto.Tamanho += "54";
                }
                else
                {
                    produto.Tamanho += " - 54";
                }
            }

            if (produto.checksTamanhos.Tamanho55 == true)
            {
                if (produto.Tamanho == null)
                {
                    produto.Tamanho += "55";
                }
                else
                {
                    produto.Tamanho += " - 55";
                }
            }

            if (produto.checksTamanhos.Tamanho56 == true)
            {
                if (produto.Tamanho == null)
                {
                    produto.Tamanho += "56";
                }
                else
                {
                    produto.Tamanho += " - 56";
                }
            }

            if (produto.checksTamanhos.Tamanho57 == true)
            {
                if (produto.Tamanho == null)
                {
                    produto.Tamanho += "57";
                }
                else
                {
                    produto.Tamanho += " - 57";
                }
            }

            if (produto.checksTamanhos.Tamanho58 == true)
            {
                if (produto.Tamanho == null)
                {
                    produto.Tamanho += "58";
                }
                else
                {
                    produto.Tamanho += " - 58";
                }
            }

            if (produto.checksTamanhos.Tamanho59 == true)
            {
                if (produto.Tamanho == null)
                {
                    produto.Tamanho += "59";
                }
                else
                {
                    produto.Tamanho += " - 59";
                }
            }

            if (produto.checksTamanhos.Tamanho60 == true)
            {
                if (produto.Tamanho == null)
                {
                    produto.Tamanho += "60";
                }
                else
                {
                    produto.Tamanho += " - 60";
                }
            }
            #endregion


            ProdutoModel produtoModel = _mapper.Map<ProdutoDTO, ProdutoModel>(produto);
            
            await _produtoRepository.CadastrarProduto(produtoModel, Imagem1, Imagem2, Imagem3);
            return RedirectToAction(nameof(Index));
        }
    
    }
}