using AutoMapper;
using TreeTrackAPI.DataAccessLayer.abstracts;
using TreeTrackAPI.Domain.dtos.plantTypeDtos;

namespace TreeTrackAPI.Services.concretes
{
    public class PlantTypeService
    {
        private readonly IPlantTypeDal plantTypeDal;
        private readonly IMapper mapper;

        public PlantTypeService(IPlantTypeDal plantTypeDal, IMapper mapper)
        {
            this.plantTypeDal = plantTypeDal;
            this.mapper = mapper;
        }
        public async Task<GetPlantTypeDto> getPlantTypeById(int id)
        {
            var plantType = await plantTypeDal.GetByIdAsync(id);

            if (plantType == null)
                throw new Exception("Plant type not found!");


            //var getGardenDto = mapper.Map<GetPlantTypeDto>(plantType);
            var getGardenDto = new GetPlantTypeDto()
            {
                Id = plantType.Id,
                Name = plantType.Name,
                Subtype = plantType.Subtype
            };
            return getGardenDto;
        }
    }
}
