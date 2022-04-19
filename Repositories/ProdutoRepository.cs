﻿using CatalogoProdutosMVC.Database;
using CatalogoProdutosMVC.Models;
using CatalogoProdutosMVC.Repositories.Contracts;
using Firebase.Auth;
using Firebase.Storage;
using Google.Cloud.Firestore;
using Newtonsoft.Json;

namespace CatalogoProdutosMVC.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        //private readonly CatalogoProdutosDbContext _context;
        //private string diretorio = "E:\\GitHubzin\\CatalogoProdutosMVC\\catalogoprodutoswebmvc-0d38f07c0ccb.json";
        private string diretorio = "Y:\\Github\\CatalogoProdutosProject\\CatalogoProdutos\\catalogoprodutoswebmvc-0d38f07c0ccb.json";
        private string projetoId;
        FirestoreDb _firestoreDb;

        public ProdutoRepository(CatalogoProdutosDbContext context)
        {
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", diretorio);
            projetoId = "catalogoprodutoswebmvc";
            _firestoreDb = FirestoreDb.Create(projetoId);
            //_context = context;
        }

        public async Task CadastrarProduto(ProdutoModel produto, IFormFile Imagem1, IFormFile Imagem2, IFormFile Imagem3)
        {
            List<IFormFile> ImagensStream = new List<IFormFile>();
            ImagensStream.Add(Imagem1);
            ImagensStream.Add(Imagem2);
            ImagensStream.Add(Imagem3);
            var countFor = 0;
            string downloadURL = null;

            //Cadastrar Imagem Firebase Storage
            string email = "belodelf@gmail.com";
            string senha = "projetoProdutos";
            string rota = "catalogoprodutoswebmvc.appspot.com";
            string api_key = "AIzaSyC35d2t3BIu1xpKwTKKJpZ7vWXRQspzayg";

            var auth = new FirebaseAuthProvider(new FirebaseConfig(api_key));
            var a = await auth.SignInWithEmailAndPasswordAsync(email, senha);

            var cancellation = new CancellationTokenSource();
            
            foreach (var item in ImagensStream)
            {
                if (item != null)
                {
                    var nomeArquivo = item.FileName;
                    Stream imagem = item.OpenReadStream();


                    var task = new FirebaseStorage(
                    rota,
                    new FirebaseStorageOptions
                    {
                        AuthTokenAsyncFactory = () => Task.FromResult(a.FirebaseToken),
                        ThrowOnCancel = true
                    })
                    .Child("Fotos_Produtos")
                    .Child(nomeArquivo)
                    .PutAsync(imagem, cancellation.Token);

                    downloadURL = await task;
                }

                switch (countFor)
                {
                    case 0:
                        produto.Image1 = downloadURL;
                        break;
                    case 1:
                        produto.Image2 = downloadURL;
                        break;
                    case 2:
                        produto.Image3 = downloadURL;
                        break;
                    default:
                        break;
                }
            }

            //Salvar demais dados no Firebase Database
            
            CollectionReference collectionReference = _firestoreDb.Collection("produtos");
            await collectionReference.AddAsync(produto);            
        }

        public async Task<List<ProdutoModel>> GetProdutos()
        {
            Query produtosQuery = _firestoreDb.Collection("produtos");
            QuerySnapshot produtosQuerySnapshot = await produtosQuery.GetSnapshotAsync();
            List<ProdutoModel> listaProdutos = new List<ProdutoModel>();

            foreach (DocumentSnapshot documentSnapshot in produtosQuerySnapshot.Documents)
            {
                if (documentSnapshot.Exists)
                {
                    Dictionary<string, object> produto = documentSnapshot.ToDictionary();
                    string json = JsonConvert.SerializeObject(produto);

                    ProdutoModel produtoModel = JsonConvert.DeserializeObject<ProdutoModel>(json);
                    produtoModel.IdProd = documentSnapshot.Id;
                    listaProdutos.Add(produtoModel);
                }
            }

            return listaProdutos;
        }

        //public List<ProdutoModel> GetProdutos()
        //{
        //    var produtos = _context.ProdutosWeb.ToList().OrderBy(x => x.IdProd);

        //    List<ProdutoModel> produtosList = new List<ProdutoModel>();
        //    produtosList = produtos.ToList();

        //    return produtosList;
        //}
    }

}
