using Azure.Core.GeoJson;
using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeTrackAPI.Domain.abstracts;

namespace TreeTrackAPI.Domain.concretes
{
    public class Plant : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Point Point { get; set; }
        public Garden Garden { get; set; }
        public PlantType PlantType { get; set; }
        public List<Note> Notes { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
