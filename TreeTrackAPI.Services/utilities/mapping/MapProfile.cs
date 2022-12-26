using AutoMapper;
using TreeTrackAPI.Domain.concretes;
using TreeTrackAPI.Domain.dtos.gardenDtos;
using TreeTrackAPI.Domain.dtos.userDtos;

namespace TreeTrackAPI.Services.utilities.mapping
{
    public class MapProfile : Profile
    {

        public MapProfile()
        {

            CreateMap<User, SaveUserDto>().ReverseMap();
            CreateMap<User, UpdateUserDto>().ReverseMap();
            CreateMap<User, GetUserDto>().ReverseMap();

            CreateMap<Garden, GetGardenDto>().ReverseMap();
            CreateMap<Garden, SaveGardenDto>().ReverseMap();
            CreateMap<Garden, UpdateGardenDto>().ReverseMap();

        }
    }
}
