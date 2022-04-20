﻿namespace CatalogoProdutosMVC.DTO
{
    public class ProdutoDTO
    {
        public string IdProd { get; set; }
        public string Categoria { get; set; }
        public string SubCategoria { get; set; }
        public string NomeProduto { get; set; }
        public string Descricao { get; set; }
        public string Tamanho { get; set; }
        public string Cor { get; set; }
        public double Preco { get; set; }
        public int Quantidade { get; set; }
        public string PathImages { get; set; }
        public string Image1 { get; set; }
        public string Image2 { get; set; }
        public string Image3 { get; set; }


        public ChecksTamanhosDTO checksTamanhos { get; set; }
    }
}