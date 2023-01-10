using TreeTrackAPI.Domain.helpers;

namespace TreeTrackAPI.Domain.dtos.plantDtos
{
    public class SavePlantDto
    {
        public string Name { get; set; }
        public MyPoint Location { get; set; }
        public int GardenId { get; set; }
        public int PlantTypeId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
