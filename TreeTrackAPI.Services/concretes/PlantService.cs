using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TreeTrackAPI.DataAccessLayer.abstracts;
using TreeTrackAPI.Domain.concretes;
using TreeTrackAPI.Domain.dtos.gardenDtos;
using TreeTrackAPI.Domain.dtos.noteDtos;
using TreeTrackAPI.Domain.dtos.plantDtos;
using TreeTrackAPI.Services.utilities.formatUtilities;

namespace TreeTrackAPI.Services.concretes
{
    public class PlantService
    {
        private readonly IPlantDal plantDal;
        private readonly GardenService gardenService;
        private readonly IMapper mapper;

        public PlantService(IPlantDal plantDal, IMapper mapper, GardenService gardenService)
        {
            this.plantDal = plantDal;
            this.mapper = mapper;
            this.gardenService = gardenService;
        }

        public async Task<GetPlantDto> savePlant(SavePlantDto savePlantDto, int gardenId)
        {
            var plant = mapper.Map<Plant>(savePlantDto);
            var getGardenDto = gardenService.getGardenById(gardenId);
            var garden = mapper.Map<Garden>(getGardenDto);

            plant.Garden = garden;

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
            var plants = await plantDal.GetAllAsync();
            var getPlantDtos = mapper.Map<List<GetPlantDto>>(plants);

            return getPlantDtos;
        }

        public async Task<GetPlantDto> getPlantById(int id)
        {
            var plant = await plantDal.GetByFilterAsync(g => g.Id == id);

            if (plant == null)
                throw new Exception("Garden not found!");


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
