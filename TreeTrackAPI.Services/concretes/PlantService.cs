using TreeTrackAPI.DataAccessLayer.abstracts;

namespace TreeTrackAPI.Services.concretes
{
    public class PlantService
    {
        private readonly IPlantDal plant;

        public PlantService(IPlantDal plant)
        {
            this.plant = plant;
        }
    }
}
