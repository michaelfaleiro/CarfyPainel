using Api.Dtos.Produto;
using Api.Models;
using AutoMapper;

namespace Api.Profiles
{
    public class ProdutoProfile : Profile
    {
        public ProdutoProfile()
        {
            CreateMap<CreateProdutoDto, Produto>();
        }
    }
}