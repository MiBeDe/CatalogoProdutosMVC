using CatalogoProdutosMVC.Models;
using CatalogoProdutosMVC.Repositories.Contracts;
using Google.Cloud.Firestore;
using Newtonsoft.Json;

namespace CatalogoProdutosMVC.Repositories
{
    public class PedidoRepository : IPedidoRepository
    { 
        //private string diretorio = "E:\\GitHubzin\\CatalogoProdutosMVC\\catalogoprodutoswebmvc-0d38f07c0ccb.json";
        private string diretorio = "Y:\\Github\\CatalogoProdutosProject\\CatalogoProdutos\\catalogoprodutoswebmvc-0d38f07c0ccb.json";
        private string projetoId;
        private IConfiguration configuration;
        FirestoreDb _firestoreDb;

        public PedidoRepository(IConfiguration iConfig)
        {
            configuration = iConfig;
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", configuration.GetSection("DirectoryConfig").GetSection("Base").Value);
            projetoId = "catalogoprodutoswebmvc";
            _firestoreDb = FirestoreDb.Create(projetoId);
            
        }

        public async Task<List<PedidoModel>> GetPedidos()
        {
            Query pedidosQuery = _firestoreDb.Collection("pedidos");
            QuerySnapshot pedidosQuerySnapshot = await pedidosQuery.GetSnapshotAsync();
            List<PedidoModel> listaPedidos = new List<PedidoModel>();

            foreach (DocumentSnapshot documentSnapshot in pedidosQuerySnapshot.Documents)
            {
                if (documentSnapshot.Exists)
                {
                    Dictionary<string, object> pedido = documentSnapshot.ToDictionary();
                    string json = JsonConvert.SerializeObject(pedido);

                    PedidoModel pedidoModel = JsonConvert.DeserializeObject<PedidoModel>(json);
                    pedidoModel.IdPedido = documentSnapshot.Id;
                    listaPedidos.Add(pedidoModel);
                }
            }

            return listaPedidos;
        }

        public async Task IncluirPedido(PedidoModel pedido)
        {
            CollectionReference collectionReference = _firestoreDb.Collection("pedidos");
            await collectionReference.AddAsync(pedido);
        }
    }
}
