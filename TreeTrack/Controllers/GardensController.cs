using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet]
        public IActionResult Get()
        {
            Task<List<Domain.concretes.Garden>> gardens = gardenService.getAllGardens();
            gardens.Wait();
            return base.Ok(gardens.Result);
        }
        
    }
}
