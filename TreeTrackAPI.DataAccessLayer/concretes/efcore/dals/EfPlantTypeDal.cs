using TicketSystem.Core.Abstract.Dal;
using TreeTrackAPI.DataAccessLayer.abstracts;
using TreeTrackAPI.Domain.concretes;

namespace TreeTrackAPI.DataAccessLayer.concretes.efcore.dals
{
    public class EfPlantTypeDal : EntityRepositoryBase<PlantType, BaseDbContext>, IPlantTypeDal
    {
    }
}
