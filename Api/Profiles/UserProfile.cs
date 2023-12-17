using Api.Dtos.User;
using Api.Models;
using AutoMapper;

namespace Api.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<CreateUserDto, User>();
            CreateMap<LoginDto, User>();
        }
    }
}