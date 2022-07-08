using AutoMapper;
using CatalogoProdutosMVC.DTO;
using CatalogoProdutosMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CatalogoProdutosMVC.Controllers
{
    public class PedidoController : Controller      
    {
        private readonly IMapper _mapper;

        public PedidoController(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<IActionResult> Pedidos()
        {
            List<PedidoDTO> pedidos = new List<PedidoDTO>();

            using (HttpClient httpClient = new HttpClient())
            {
                var urlRequestGetPedidos = string.Format("https://localhost:7086/api/Pedido");

                string url = urlRequestGetPedidos;
                httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
                HttpResponseMessage responseMessage = httpClient.GetAsync(url).Result;

                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                    pedidos = JsonConvert.DeserializeObject<List<PedidoDTO>>(responseData);
                }
            }

            return View(pedidos);
        }


        [HttpPost]
        public async Task<IActionResult> RealizarPedido(PedidoDTO pedido)
        {
            PedidoModel pedidoModel = _mapper.Map<PedidoDTO, PedidoModel>(pedido);

            //Dar baixa na quantidade
            var urlRequestGetProdutoById = string.Format("https://localhost:7086/api/Products/{0}", pedido.IdProduto);
            ProdutoModel Produto = new ProdutoModel();
            using (HttpClient httpClient = new HttpClient())
            {
                string url = urlRequestGetProdutoById;
                httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
                HttpResponseMessage responseMessage = httpClient.GetAsync(url).Result;

                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                    Produto = JsonConvert.DeserializeObject<ProdutoModel>(responseData);
                }
            }

            var qtdRestante = (Produto.Quantidade - pedido.Quantidade);
            Produto.Quantidade = qtdRestante;

            using (HttpClient httpClient = new HttpClient())
            {
                var urlRequestAtualizarProd = string.Format("https://localhost:7086/api/Estoque");

                var jsonInString = JsonConvert.SerializeObject(Produto);

                httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
                var httpResponse = httpClient.PutAsync(urlRequestAtualizarProd, new StringContent(jsonInString, Encoding.UTF8, "application/json")).Result;
            }

            //IncluirPedido
            using (HttpClient httpClient = new HttpClient())
            {
                var urlRequestIncluirPedido = string.Format("https://localhost:7086/api/Pedido");

                var jsonInString = JsonConvert.SerializeObject(pedido);

                httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
                var httpReponse = httpClient.PostAsync(urlRequestIncluirPedido, new StringContent(jsonInString, Encoding.UTF8, "application/json")).Result;
            }

            return RedirectToAction("Index", "Products");
        }

        //[HttpPost]
        public async Task<IActionResult> DeletePedido(PedidoDTO pedido)
        {
            PedidoModel pedidoModel = _mapper.Map<PedidoDTO, PedidoModel>(pedido);

            //Atualizar quantidade
            var urlRequestGetProdutoById = string.Format("https://localhost:7086/api/Products/{0}", pedido.IdProduto);
            ProdutoModel Produto = new ProdutoModel();
            using (HttpClient httpClient = new HttpClient())
            {
                string url = urlRequestGetProdutoById;
                httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
                HttpResponseMessage responseMessage = httpClient.GetAsync(url).Result;

                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                    Produto = JsonConvert.DeserializeObject<ProdutoModel>(responseData);
                }
            }

            var qtdRestante = (Produto.Quantidade + pedido.Quantidade);
            Produto.Quantidade = qtdRestante;

            using (HttpClient httpClient = new HttpClient())
            {
                var urlRequestAtualizarProd = string.Format("https://localhost:7086/api/Estoque");

                var jsonInString = JsonConvert.SerializeObject(Produto);

                httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
                var httpResponse = httpClient.PutAsync(urlRequestAtualizarProd, new StringContent(jsonInString, Encoding.UTF8, "application/json")).Result;
            }
            //-----------------------

            using (HttpClient httpClient = new HttpClient())
            {
                var urlRequestDeletePedido = string.Format("https://localhost:7086/api/Pedido/{0}", pedido.IdPedido);

                string url = urlRequestDeletePedido;
                httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
                HttpResponseMessage responseMessage = httpClient.DeleteAsync(url).Result;

                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Pedidos));
                }
            }

            return null;
        }

        [HttpPost]
        public async Task<IActionResult> SepararPedido (PedidoDTO pedido)
        {
            var urlRequestGetPedidoById = string.Format("https://localhost:7086/api/Pedido/{0}", pedido.IdPedido);
            PedidoModel Pedido = new PedidoModel();
            using (HttpClient httpClient = new HttpClient())
            {
                string url = urlRequestGetPedidoById;
                httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
                HttpResponseMessage responseMessage = httpClient.GetAsync(url).Result;

                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                    Pedido = JsonConvert.DeserializeObject<PedidoModel>(responseData);
                }
            }

            Pedido.StatusPedido = 1;


            using (HttpClient httpClient = new HttpClient())
            {
                var urlRequestAlterarStatusPedido = string.Format("https://localhost:7086/api/Pedido/UpdateStatusPedido");

                var jsonInString = JsonConvert.SerializeObject(Pedido);

                httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
                var httpResponse = httpClient.PutAsync(urlRequestAlterarStatusPedido, new StringContent(jsonInString, Encoding.UTF8, "application/json")).Result;
            }

            return RedirectToAction(nameof(Pedidos));
        }

        public async Task<IActionResult> EnviarPedido (PedidoDTO pedido)
        {

            var urlRequestGetPedidoById = string.Format("https://localhost:7086/api/Pedido/{0}", pedido.IdPedido);
            PedidoModel Pedido = new PedidoModel();
            using (HttpClient httpClient = new HttpClient())
            {
                string url = urlRequestGetPedidoById;
                httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
                HttpResponseMessage responseMessage = httpClient.GetAsync(url).Result;

                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                    Pedido = JsonConvert.DeserializeObject<PedidoModel>(responseData);
                }
            }

            Pedido.StatusPedido = 2;
            Pedido.DataEnvio = DateTime.Now.ToString();

            using (HttpClient httpClient = new HttpClient())
            {
                var urlRequestAlterarStatusPedido = string.Format("https://localhost:7086/api/Pedido/UpdateStatusPedido");

                var jsonInString = JsonConvert.SerializeObject(Pedido);

                httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
                var httpResponse = httpClient.PutAsync(urlRequestAlterarStatusPedido, new StringContent(jsonInString, Encoding.UTF8, "application/json")).Result;
            }

            return RedirectToAction(nameof(Pedidos));
        }

        public async Task<IActionResult> PedidoPago (PedidoDTO pedido)
        {
            var urlRequestGetPedidoById = string.Format("https://localhost:7086/api/Pedido/{0}", pedido.IdPedido);
            PedidoModel Pedido = new PedidoModel();
            using (HttpClient httpClient = new HttpClient())
            {
                string url = urlRequestGetPedidoById;
                httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
                HttpResponseMessage responseMessage = httpClient.GetAsync(url).Result;

                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                    Pedido = JsonConvert.DeserializeObject<PedidoModel>(responseData);
                }
            }

            Pedido.StatusPagamento = 1;

            using (HttpClient httpClient = new HttpClient())
            {
                var urlRequestAlterarStatusPagamento = string.Format("https://localhost:7086/api/Pedido/UpdateStatusPagamento");

                var jsonInString = JsonConvert.SerializeObject(Pedido);

                httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
                var httpResponse = httpClient.PutAsync(urlRequestAlterarStatusPagamento, new StringContent(jsonInString, Encoding.UTF8, "application/json")).Result;
            }

            return RedirectToAction(nameof(Pedidos));
        }
    }
}
