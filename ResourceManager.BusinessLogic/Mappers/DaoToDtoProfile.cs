using AutoMapper;
using ResourceManager.BusinessLogic.Models;
using ResourceManager.EntityFrameworkCore.Models;

namespace ResourceManager.BusinessLogic.Mappers
{
    public class DaoToDtoProfile : Profile
    {
        public DaoToDtoProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
        }
    }
}
