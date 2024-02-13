using Api.Dtos.Orcamento;
using Api.Models;
using AutoMapper;

namespace Api.Profiles
{
    public class OrcamentoProfile : Profile
    {
        public OrcamentoProfile()
        {
            CreateMap<CreateOrcamentoDto, Orcamento>();
            CreateMap<UpdateOrcamentoDto, Orcamento>();
        }
    }
}