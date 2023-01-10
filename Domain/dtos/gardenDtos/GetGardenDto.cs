using NetTopologySuite.Geometries;
using TreeTrackAPI.Domain.concretes;
using TreeTrackAPI.Domain.dtos.plantDtos;
using TreeTrackAPI.Domain.dtos.userDtos;
using TreeTrackAPI.Domain.helpers;

namespace TreeTrackAPI.Domain.dtos.gardenDtos
{
    public class GetGardenDto
    {
        public string GardenName { get; set; }
        public double? Area { get; set; }
        public List<MyPoint> Polygon { get; set; }
        public List<Note> Notes { get; set; }
        public List<GetPlantDto> Plants { get; set; }
        public List<GetUserDto> Users { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int Id { get; set; }
    }
}
