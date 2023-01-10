using NetTopologySuite.Geometries;
using TreeTrackAPI.Domain.abstracts;

namespace TreeTrackAPI.Domain.concretes
{
    public class Plant : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Point Location { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Garden Garden { get; set; }
        public int GardenId { get; set; }
        public int PlantTypeId { get; set; }
        public PlantType PlantType { get; set; }
        public List<Note> Notes { get; set; }
    }
}
