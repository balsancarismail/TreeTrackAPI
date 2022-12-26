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
