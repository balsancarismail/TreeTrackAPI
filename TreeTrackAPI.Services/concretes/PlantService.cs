using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite.Geometries;
using TreeTrackAPI.DataAccessLayer.abstracts;
using TreeTrackAPI.Domain.concretes;
using TreeTrackAPI.Domain.dtos.noteDtos;
using TreeTrackAPI.Domain.dtos.plantDtos;
using TreeTrackAPI.Domain.helpers;
using TreeTrackAPI.Services.utilities.formatUtilities;

namespace TreeTrackAPI.Services.concretes
{
    public class PlantService
    {
        private readonly IPlantDal plantDal;
        private readonly GardenService gardenService;
        private readonly IMapper mapper;
        private readonly PlantTypeService plantTypeService;

        public PlantService(IPlantDal plantDal, IMapper mapper, GardenService gardenService, PlantTypeService plantTypeService)
        {
            this.plantDal = plantDal;
            this.mapper = mapper;
            this.gardenService = gardenService;
            this.plantTypeService = plantTypeService;
        }

        public async Task<GetPlantDto> savePlant(SavePlantDto savePlantDto)
        {
            
            Point point = GeographyHelper.ConvertMyPointToPoint(savePlantDto.Location);

            var getGardenDto = await gardenService.getGardenById(savePlantDto.GardenId);
            // var garden = mapper.Map<Garden>(getGardenDto);
            var garden = new Garden()
            {
                CreatedAt = getGardenDto.CreatedAt,
                Area = getGardenDto.Area,
                GardenName = getGardenDto.GardenName,
                Id = getGardenDto.Id,
                Polygon = GeographyHelper.ConvertListToPolygon(getGardenDto.Polygon),
                UpdatedAt = getGardenDto.UpdatedAt,
                
            };
            if (! garden.Polygon.Contains(point))
            {
                throw new Exception("Plant location is not in garden area");
            }
            var getPlantType = await plantTypeService.getPlantTypeById(savePlantDto.PlantTypeId);
            var plantType = new PlantType()
            {
                Id = getPlantType.Id,
                Name = getPlantType.Name,
                Subtype = getPlantType.Subtype
            };
            var plant = new Plant()
            {
                Name = savePlantDto.Name,
                Location = point,
                PlantTypeId = savePlantDto.PlantTypeId,
                PlantType = plantType,
                GardenId = savePlantDto.GardenId,
                Garden = garden,
                CreatedAt = savePlantDto.CreatedAt,
                UpdatedAt = savePlantDto.UpdatedAt
            };
           
            var savedPlant = await this.plantDal.CreateAsync(plant);
            if (savedPlant == null) { throw new Exception("Plant could not be created"); }

            var getPlant = mapper.Map<GetPlantDto>(savedPlant);
            return getPlant;
        }

        public GetPlantDto updatePlant(UpdatePlantDto updatePlantDto)
        {
            var plant = mapper.Map<Plant>(updatePlantDto);
            var result = plantDal.Update(plant);

            if (result != null)
            {
                var getPlantDto = mapper.Map<GetPlantDto>(result);
                return getPlantDto;
            }

            throw new Exception("Plant could not be updated");
        }

        public async Task<List<GetPlantDto>> getPlants()
        {
            var plants = plantDal.GetAllPlantInfo();
            var getPlantDtos = mapper.Map<List<GetPlantDto>>(plants);
            
            return getPlantDtos;
        }

        public async Task<GetPlantDto> getPlantById(int id)
        {
            var plant = await plantDal.GetAllPlantInfoById(id);

            if (plant == null)
            {
                throw new Exception("Plant not found");
            }

            var getPlantDto = mapper.Map<GetPlantDto>(plant);
            return getPlantDto;
        }

        public GetNoteDto addNote(SaveNoteDto saveNoteDto, int plantId)
        {
            var plant = plantDal.GetAll().Include(p => p.Notes).Where(p => p.Id == plantId).FirstOrDefault();
            var note = mapper.Map<Note>(saveNoteDto);
            if (saveNoteDto.ImageFile != null)
                note.Image = saveNoteDto.ImageFile.convertToByteArray();

            var plantNotes = plant.Notes ?? new List<Note> { note };
            plant.Notes = plantNotes;
            var updatedPlant = plantDal.Update(plant);

            if (updatedPlant == null) throw new Exception("Note could not be added!");

            var getNoteDto = mapper.Map<GetNoteDto>(note);
            return getNoteDto;
        }
    }
}
