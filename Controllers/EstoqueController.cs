using AutoMapper;
using CatalogoProdutosMVC.Helpers;
using CatalogoProdutosMVC.Models;
using CatalogoProdutosMVC.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CatalogoProdutosMVC.Controllers
{
    public class EstoqueController : Controller
    {
        private readonly IMapper _mapper;

        public EstoqueController(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<IActionResult> Listar(int pg=1)
        {
            List<ProdutoModel> produtos = new List<ProdutoModel>();

            using (HttpClient httpClient = new HttpClient())
            {
                var urlRequestGetProdutosEstoque = string.Format("https://localhost:7086/api/Estoque");

                string url = urlRequestGetProdutosEstoque;
                httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
                HttpResponseMessage responseMessage = httpClient.GetAsync(url).Result;

                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                    produtos = JsonConvert.DeserializeObject<List<ProdutoModel>>(responseData);
                }
            }

            //var produtos = await _produtoRepository.GetProdutos(null, null);

            const int pageSize = 8;
            if (pg < 1)
                pg = 1;

            int recsCount = produtos.Count();

            var pager = new Pager(recsCount, pg, pageSize);
            int recSkip = (pg - 1) * pageSize;

            var data = produtos.Skip(recSkip).Take(pager.PageSize).ToList();

            this.ViewBag.Pager = pager;


            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> AlterarQuantidade(ProdutoModel produto)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var urlRequestAtualizarProd = string.Format("https://localhost:7086/api/Estoque");

                var jsonInString = JsonConvert.SerializeObject(produto);

                httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
                var httpResponse = httpClient.PutAsync(urlRequestAtualizarProd, new StringContent(jsonInString, Encoding.UTF8, "application/json")).Result;
            }

            return RedirectToRoute("Estoque");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteProduto(string idProduto)
        {
            if (idProduto != null)
            {
                var urlRequestDeleteProduto = string.Format("https://localhost:7086/api/Estoque/{0}", idProduto);

                using (HttpClient httpClient = new HttpClient())
                {
                    string url = urlRequestDeleteProduto;
                    httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
                    HttpResponseMessage responseMessage = httpClient.DeleteAsync(url).Result;

                    if (responseMessage.IsSuccessStatusCode)
                    {
                        return RedirectToRoute("Estoque");
                    }
                }
            }

            return null;

        }
    }
}
