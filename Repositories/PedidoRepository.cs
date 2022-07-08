using CatalogoProdutosMVC.DTO;
using CatalogoProdutosMVC.Models;
using CatalogoProdutosMVC.Repositories.Contracts;
using Google.Cloud.Firestore;
using Newtonsoft.Json;

namespace CatalogoProdutosMVC.Repositories
{
    public class PedidoRepository : IPedidoRepository
    { 
        private string projetoId;
        FirestoreDb _firestoreDb;

        private readonly IConfiguration configuration;

        public PedidoRepository(IConfiguration iConfig)
        {
            configuration = iConfig;
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", configuration.GetSection("DirectoryConfig").GetSection("Base").Value);
            projetoId = "catalogoprodutoswebmvc";
            _firestoreDb = FirestoreDb.Create(projetoId);
        }

        public async Task<List<PedidoDTO>> GetPedidos()
        {
            Query pedidosQuery = _firestoreDb.Collection("pedidos");
            QuerySnapshot pedidosQuerySnapshot = await pedidosQuery.GetSnapshotAsync();
            List<PedidoDTO> listaPedidos = new List<PedidoDTO>();

            foreach (DocumentSnapshot documentSnapshot in pedidosQuerySnapshot.Documents)
            {
                if (documentSnapshot.Exists)
                {
                    Dictionary<string, object> pedido = documentSnapshot.ToDictionary();
                    string json = JsonConvert.SerializeObject(pedido);

                    PedidoDTO pedidoDTO = JsonConvert.DeserializeObject<PedidoDTO>(json);
                    pedidoDTO.IdPedido = documentSnapshot.Id;

                    //obter imagem produto:
                    var urlRequestGetProdutoById = string.Format("https://localhost:7086/api/Products/{0}", pedidoDTO.IdProduto);
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
                    //var produto = await _produtoRepository.GetProdutoById(pedidoDTO.IdProduto);
                    pedidoDTO.Image = Produto.Image1;

                    listaPedidos.Add(pedidoDTO);
                }
            }

            return listaPedidos;
        }



        public async Task IncluirPedido(PedidoModel pedido)
        {
            CollectionReference collectionReference = _firestoreDb.Collection("pedidos");
            await collectionReference.AddAsync(pedido);
        }

        public async Task DeletePedido(PedidoModel pedido)
        {
            DocumentReference documentReference = _firestoreDb.Collection("pedidos").Document(pedido.IdPedido);
            await documentReference.DeleteAsync();
          
        }

        public async Task AlterarStatusPedido(PedidoModel pedido)
        {
            DocumentReference documentReference = _firestoreDb.Collection("pedidos").Document(pedido.IdPedido);
            await documentReference.SetAsync(pedido, SetOptions.Overwrite);
        }

        public async Task<PedidoModel> GetPedidoById(string idPedido)
        {
            DocumentReference documentReference = _firestoreDb.Collection("pedidos").Document(idPedido);
            DocumentSnapshot documentSnapshot = await documentReference.GetSnapshotAsync();

            if (documentSnapshot.Exists)
            {
                PedidoModel pedidoModel = documentSnapshot.ConvertTo<PedidoModel>();
                pedidoModel.IdPedido = documentSnapshot.Id;

                return pedidoModel;
            }

            return null;
        }

        public async Task AlterarStatusPagamento(PedidoModel pedido)
        {
            DocumentReference documentReference = _firestoreDb.Collection("pedidos").Document(pedido.IdPedido);
            await documentReference.SetAsync(pedido, SetOptions.Overwrite);
        }
    }
}
