using AutoMapper;
using Identity.Core.DTOs;
using Identity.Models.Models;

namespace Identity.Core.Services
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserFormDTO, User>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<Avatar, AvatarDTO>().ReverseMap();
            CreateMap<Avatar, AvatarFormDTO>().ReverseMap();
        }
    }
}
