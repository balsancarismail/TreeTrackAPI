using TreeTrackAPI.Domain.helpers;

namespace TreeTrackAPI.Domain.dtos.gardenDtos
{
    public class SaveGardenDto
    {
        public string GardenName { get; set; }
        public double? Area { get; set; }
        public List<int> UserIds { get; set; }
        public List<MyPoint> Polygon { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
