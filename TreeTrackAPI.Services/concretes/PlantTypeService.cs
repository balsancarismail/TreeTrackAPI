using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeTrackAPI.DataAccessLayer.abstracts;

namespace TreeTrackAPI.Services.concretes
{
    public class PlantTypeService
    {
        private readonly IPlantTypeDal plantTypeDal;

        public PlantTypeService(IPlantTypeDal plantTypeDal)
        {
            this.plantTypeDal = plantTypeDal;
        }
    }
}
