using TreeTrackAPI.Domain.abstracts;

namespace TreeTrackAPI.Domain.concretes
{
    public class PlantType : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Plant> Plants { get; set; }
    }
}
