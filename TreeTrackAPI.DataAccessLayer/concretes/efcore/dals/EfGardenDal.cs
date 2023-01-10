using Microsoft.EntityFrameworkCore;
using TicketSystem.Core.Abstract.Dal;
using TreeTrackAPI.DataAccessLayer.abstracts;
using TreeTrackAPI.Domain.concretes;

namespace TreeTrackAPI.DataAccessLayer.concretes.efcore.dals
{
    public class EfGardenDal : EntityRepositoryBase<Garden, BaseDbContext>, IGardenDal
    {
        private readonly BaseDbContext baseDbContext;
        public EfGardenDal(BaseDbContext baseDbContext)
        {
            this.baseDbContext = baseDbContext;
        }

        public async Task<Garden>? GetAllGardenInfoById(int id)
        {

            var garden = await baseDbContext.Gardens.Include(p => p.Users).ThenInclude(u => u.User).Include(p => p.Notes).Include(p => p.Plants).ThenInclude(p => p.PlantType)
                .Select(p => new Garden()
                {
                    CreatedAt = p.CreatedAt,
                    Id = p.Id,
                    Plants = p.Plants.ToList(),
                    Notes = p.Notes.ToList(),
                    Polygon = p.Polygon,
                    GardenName = p.GardenName,
                    Users = p.Users.ToList(),
                    Area = p.Area,
                    UpdatedAt = p.UpdatedAt,

                }).FirstOrDefaultAsync(p => p.Id == id);

            return garden;
        }

        List<Garden> IGardenDal.GetAllGardenInfo()
        {

            var gardens = baseDbContext.Gardens.Include(p => p.Users).ThenInclude(u => u.User).Include(p => p.Notes).Include(p => p.Plants).ThenInclude(p => p.PlantType)
                 .Select(p => new Garden()
                 {
                     CreatedAt = p.CreatedAt,
                     Id = p.Id,
                     Plants = p.Plants,
                     Notes = p.Notes.ToList(),
                     Polygon = p.Polygon,
                     GardenName = p.GardenName,
                     Users = p.Users.ToList(),
                     Area = p.Area,
                     UpdatedAt = p.UpdatedAt,

                 }).ToList();

            return gardens;
        }

    }
}
