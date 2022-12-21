using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeTrackAPI.DataAccessLayer.abstracts;
using TreeTrackAPI.Domain.concretes;

namespace TreeTrackAPI.Services.concretes
{
    public class GardenService
    {
        private readonly IGardenDal gardenDal;

        public GardenService(IGardenDal gardenDal)
        {
            this.gardenDal = gardenDal;
        }

        public async Task<List<Garden>> getAllGardens()
        {
            return await this.gardenDal.GetAllAsync();
        }
    }
}
