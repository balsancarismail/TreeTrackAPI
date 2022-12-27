using Microsoft.AspNetCore.Mvc;
using TreeTrackAPI.Domain.dtos.gardenDtos;
using TreeTrackAPI.Domain.dtos.noteDtos;
using TreeTrackAPI.Services.concretes;

namespace TreeTrackAPI.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GardensController : ControllerBase
    {
        private readonly GardenService gardenService;
        public GardensController(GardenService gardenService)
        {
            this.gardenService = gardenService;
        }

        [HttpGet("/get-all")]
        public IActionResult GetAll()
        {
            Task<List<GetGardenDto>> gardens = gardenService.getGardens();
            gardens.Wait();
            return base.Ok(gardens.Result);
        }

        [HttpPost("/save-garden/{user-id}")]
        public async Task<IActionResult> save(SaveGardenDto dto, int userId)
        {

            var response = await gardenService.saveGarden(dto, userId);
            return base.Ok(response);
        }

        [HttpGet("/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await gardenService.getGardenById(id);
            return base.Ok(response);
        }

        [HttpPut]
        public IActionResult updateGarden(UpdateGardenDto updateGardenDto)
        {
            var response = gardenService.updateGarden(updateGardenDto);
            return base.Ok(response);
        }

        [HttpPost("/save-note/{garden-id}")]
        public IActionResult saveNote(SaveNoteDto saveNoteDto, int gardenId)
        {
            var response = gardenService.addNote(saveNoteDto, gardenId);
            return base.Ok(response);
        }
    }
}
