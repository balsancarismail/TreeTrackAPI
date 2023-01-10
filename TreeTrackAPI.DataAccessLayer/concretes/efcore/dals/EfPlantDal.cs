using Microsoft.EntityFrameworkCore;
using TicketSystem.Core.Abstract.Dal;
using TreeTrackAPI.DataAccessLayer.abstracts;
using TreeTrackAPI.Domain.concretes;

namespace TreeTrackAPI.DataAccessLayer.concretes.efcore.dals
{
    public class EfPlantDal : EntityRepositoryBase<Plant, BaseDbContext>, IPlantDal
    {
        private readonly BaseDbContext baseDbContext;
        public EfPlantDal(BaseDbContext baseDbContext)
        {
            this.baseDbContext = baseDbContext;
        }

        public async Task<Plant>? GetAllPlantInfoById(int id)
        {
            
            var plant = await baseDbContext.Plants.Include(p => p.PlantType).Include(p => p.Garden).Include(p => p.Notes)
                .Select(p => new Plant()
                {
                    CreatedAt = p.CreatedAt,
                    GardenId = p.GardenId,
                    Garden = p.Garden,
                    PlantType = p.PlantType,
                    PlantTypeId = p.PlantTypeId,
                    Notes = p.Notes.ToList(),
                    Location = p.Location,
                    Name = p.Name,
                    Id = p.Id,
                    UpdatedAt = p.UpdatedAt,

                }).FirstOrDefaultAsync(p => p.Id == id);

            return plant;
        }

        List<Plant> IPlantDal.GetAllPlantInfo()
        {
            
            var plants = baseDbContext.Plants.Include(p => p.PlantType).Include(p => p.Garden).Include(p => p.Notes)
                .Select(p => new Plant()
                {
                    CreatedAt = p.CreatedAt,
                    GardenId = p.GardenId,
                    Garden = p.Garden,
                    PlantType = p.PlantType,
                    PlantTypeId = p.PlantTypeId,
                    Notes = p.Notes.ToList(),
                    Location = p.Location,
                    Name = p.Name,
                    Id = p.Id,
                    UpdatedAt = p.UpdatedAt,

                }).ToList();
            
            return plants;
        }


    }
}
