using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.Core.Abstract.Dal;
using TreeTrackAPI.Domain.concretes;

namespace TreeTrackAPI.DataAccessLayer.abstracts
{
    public interface ILocationDal : IRepositoryDal<Location>
    {
    }
}
