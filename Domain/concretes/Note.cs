using TreeTrackAPI.Domain.abstracts;

namespace TreeTrackAPI.Domain.concretes
{
    public class Note : BaseEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public byte[]? Image { get; set; }
        public DateTime CreatedAt { get; set; }
        public int ? PlantId { get; set; }
        public Plant ? Plant { get; set; }
        public int ? GardenId { get; set; }
        public Garden ? Garden { get; set; }
    }
}
