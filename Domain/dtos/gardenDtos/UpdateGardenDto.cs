using NetTopologySuite.Geometries;
using TreeTrackAPI.Domain.concretes;

namespace TreeTrackAPI.Domain.dtos.gardenDtos
{
    public class UpdateGardenDto
    {
        public string GardenName { get; set; }
        public double? Area { get; set; }
        public List<User> Users { get; set; }
        public Polygon Polygon { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int Id { get; set; }
    }
}
