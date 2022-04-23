using AutoMapper;
using CatalogoProdutosMVC.DTO;
using CatalogoProdutosMVC.Models;

namespace CatalogoProdutosMVC.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<ProdutoModel, ProdutoDTO>();
            CreateMap<ProdutoModel, ProdutoDTO>().ReverseMap();
            CreateMap<PedidoModel, PedidoDTO>();
            CreateMap<PedidoModel, PedidoDTO>().ReverseMap();
        }

    }
}
