using System.ComponentModel.DataAnnotations;

namespace CatalogoProdutosMVC.Models
{
    public class ProdutoModel
    {
        [Key]
        public int IdProd { get; set; }
        public int IdCategoria { get; set; }
        public string NomeProduto { get; set; }
        public string Descricao { get; set; }
        public double Preco { get; set; }
        public int Quantidade { get; set; }
        public string PathImages { get; set; }
        public string GitCu { get; set; }

        public string GitRola { get; set; }
    }
}
