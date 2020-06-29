using AutoMapper;
using ResourceManager.BusinessLogic.Models;
using ResourceManager.EntityFrameworkCore.Models;
using System.Linq;

namespace ResourceManager.BusinessLogic.Mappers
{
    public class DaoToDtoProfile : Profile
    {
        public DaoToDtoProfile()
        {
            CreateMap<User, UserDto>()
                .AfterMap((dto, userDto) => userDto.Roles = dto.Roles.Split(';').ToList());
            CreateMap<UserDto, User>()
                .ForMember(x => x.Roles, opt => opt.MapFrom(src => string.Join(";", src.Roles)));

            CreateMap<Resource, ResourceDto>();
            CreateMap<ResourceDto, Resource>();

            CreateMap<ResourceItem, ResourceItemDto>();
            CreateMap<ResourceItemDto, ResourceItem>();
        }
    }
}
