using TicketSystem.Core.Abstract.Dal;
using TreeTrackAPI.Domain.concretes;

namespace TreeTrackAPI.DataAccessLayer.abstracts
{
    public interface IGardenDal : IRepositoryDal<Garden>
    {
        List<Garden> GetAllGardenInfo();
        Task<Garden>? GetAllGardenInfoById(int id);
    }
}
