using Microsoft.EntityFrameworkCore;
using TicketSystem.Core.Abstract.Dal;
using TreeTrackAPI.Domain.concretes;
using TreeTrackAPI.Domain.dtos.plantDtos;

namespace TreeTrackAPI.DataAccessLayer.abstracts
{
    public interface IPlantDal : IRepositoryDal<Plant>
    {
        List<Plant> GetAllPlantInfo();
        Task<Plant>? GetAllPlantInfoById(int id);
        
    }
}
