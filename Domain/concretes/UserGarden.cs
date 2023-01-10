using TreeTrackAPI.Domain.abstracts;

namespace TreeTrackAPI.Domain.concretes
{
    public class UserGarden: BaseEntity
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int GardenId { get; set; }
        public Garden Garden { get; set; }
        public int Id { get; set; }
    }
}
