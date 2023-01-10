using AutoMapper;
using TreeTrackAPI.Domain.concretes;
using TreeTrackAPI.Domain.dtos.gardenDtos;
using TreeTrackAPI.Domain.dtos.plantDtos;
using TreeTrackAPI.Domain.dtos.plantTypeDtos;
using TreeTrackAPI.Domain.dtos.userDtos;
using TreeTrackAPI.Domain.helpers;

namespace TreeTrackAPI.Services.utilities.mapping
{
    public class MapProfile : Profile
    {

        public MapProfile()
        {

            CreateMap<User, SaveUserDto>().ReverseMap();
            CreateMap<User, UpdateUserDto>().ReverseMap();
            CreateMap<User, GetUserDto>().ReverseMap();

            CreateMap<Garden, GetGardenDto>().ForMember(dest => dest.Polygon, 
                                                        opt => opt.MapFrom(src => GeographyHelper.ConvertPolygonToList(src.Polygon)))
                                              .AfterMap((src, dest) =>
                                              {
                                                  if(src.Users != null)
                                                  {
                                                      dest.Users = src.Users.Select(u => new GetUserDto()
                                                      {
                                                          Id = u.User.Id,
                                                          Email = u.User.Email,
                                                          Name = u.User.Name,
                                                          LastName = u.User.LastName
                                                      }).ToList();
                                                  }
                                                  else
                                                  {
                                                      dest.Users = new List<GetUserDto>();
                                                  }
                                              })
                                             .ReverseMap();
            
            CreateMap<SaveGardenDto, Garden>().ForMember(dest => dest.Polygon,
                                                        opt => opt.MapFrom(src => GeographyHelper.ConvertListToPolygon(src.Polygon)))
                                             .ReverseMap();
            CreateMap<Garden, UpdateGardenDto>().ReverseMap();

            CreateMap<SaveGardenDto, GetGardenDto>().ReverseMap();

            CreateMap<Plant, SavePlantDto>().ForMember(dest => dest.Location,
                                                      opt => opt.MapFrom(src => GeographyHelper.ConvertPointToMyPoint(src.Location)))
                                            .ReverseMap();
            CreateMap<Plant, UpdatePlantDto>().ReverseMap();
            CreateMap<Plant, GetPlantDto>().ForMember(dest => dest.Location,
                                                      opt => opt.MapFrom(src => GeographyHelper.ConvertPointToMyPoint(src.Location)))
                                           .ReverseMap();

            CreateMap<PlantType, GetPlantTypeDto>().ReverseMap();
            CreateMap<UserGarden, GetUserDto>().ReverseMap();

        }
    }
}
