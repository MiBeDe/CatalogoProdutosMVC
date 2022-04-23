using CatalogoProdutosMVC.Models;
using CatalogoProdutosMVC.Repositories.Contracts;
using Google.Cloud.Firestore;

namespace CatalogoProdutosMVC.Repositories
{
    public class PedidoRepository : IPedidoRepository
    { 
        //private string diretorio = "E:\\GitHubzin\\CatalogoProdutosMVC\\catalogoprodutoswebmvc-0d38f07c0ccb.json";
        private string diretorio = "Y:\\Github\\CatalogoProdutosProject\\CatalogoProdutos\\catalogoprodutoswebmvc-0d38f07c0ccb.json";
        private string projetoId;
        FirestoreDb _firestoreDb;

        public PedidoRepository()
        {
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", diretorio);
            projetoId = "catalogoprodutoswebmvc";
            _firestoreDb = FirestoreDb.Create(projetoId);
        }

        public async Task IncluirPedido(PedidoModel pedido)
        {
            CollectionReference collectionReference = _firestoreDb.Collection("pedidos");
            await collectionReference.AddAsync(pedido);
        }
    }
}
