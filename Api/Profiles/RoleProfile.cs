using Api.Dtos.Role;
using Api.Models;
using AutoMapper;

namespace Api.Profiles
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<CreateRole, Role>();
        }
    }
}