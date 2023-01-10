using TreeTrackAPI.Domain.concretes;
using TreeTrackAPI.Domain.dtos.gardenDtos;
using TreeTrackAPI.Domain.dtos.plantTypeDtos;
using TreeTrackAPI.Domain.helpers;

namespace TreeTrackAPI.Domain.dtos.plantDtos
{
    public class GetPlantDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public MyPoint Location { get; set; }
        public GetGardenDto Garden { get; set; }
        public GetPlantTypeDto PlantType { get; set; }
        public List<Note> Notes { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
