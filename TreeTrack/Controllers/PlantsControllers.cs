using Microsoft.AspNetCore.Mvc;
using TreeTrackAPI.Domain.dtos.gardenDtos;
using TreeTrackAPI.Domain.dtos.noteDtos;
using TreeTrackAPI.Domain.dtos.plantDtos;
using TreeTrackAPI.Services.concretes;

namespace TreeTrackAPI.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlantsControllers : ControllerBase
    {
        private readonly PlantService plantService;

        public PlantsControllers(PlantService plantService)
        {
            this.plantService = plantService;
        }

        [HttpGet("/get-all-plants")]
        public IActionResult GetAll()
        {
            Task<List<GetPlantDto>> plants = plantService.getPlants();
            plants.Wait();
            return base.Ok(plants.Result);
        }

        [HttpPost("/save-plant/{garden-plantId}")]
        public async Task<IActionResult> save(SavePlantDto dto, int gardenId)
        {

            var response = await plantService.savePlant(dto, gardenId);
            return base.Ok(response);
        }

        [HttpGet("/get-plant/{plant-plantId}")]
        public async Task<IActionResult> GetByPlantId(int plantId)
        {
            var response = await plantService.getPlantById(plantId);
            return base.Ok(response);
        }

        [HttpPut]
        public IActionResult updatePlant(UpdatePlantDto updatePlantDto)
        {
            var response = plantService.updatePlant(updatePlantDto);
            return base.Ok(response);
        }

        [HttpPost("/save-note/{plant-plantId}")]
        public IActionResult saveNote(SaveNoteDto saveNoteDto, int plantId)
        {
            var response = plantService.addNote(saveNoteDto, plantId);
            return base.Ok(response);
        }
    }
}
