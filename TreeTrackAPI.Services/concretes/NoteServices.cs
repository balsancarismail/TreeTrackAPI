using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeTrackAPI.DataAccessLayer.abstracts;

namespace TreeTrackAPI.Services.concretes
{
    public class NoteServices
    {
        private readonly INoteDal noteDal;

        public NoteServices(INoteDal noteDal)
        {
            this.noteDal = noteDal;
        }
    }
}
