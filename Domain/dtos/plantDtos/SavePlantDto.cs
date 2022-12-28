using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeTrackAPI.Domain.concretes;

namespace TreeTrackAPI.Domain.dtos.plantDtos
{
    public class SavePlantDto
    {
        public string Name { get; set; }
        public Point Point { get; set; }
        public Garden Garden { get; set; }
        public PlantType PlantType { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
