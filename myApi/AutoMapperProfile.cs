using AutoMapper;
using myApi.Domain.Dtos;
using myApi.Domain.Entities;

namespace myApi
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
        }
    }
}
