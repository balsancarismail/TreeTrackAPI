using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
