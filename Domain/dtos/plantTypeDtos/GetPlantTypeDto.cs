using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeTrackAPI.Domain.concretes;

namespace TreeTrackAPI.Domain.dtos.plantTypeDtos
{
    public class GetPlantTypeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Subtype { get; set; }
    }
}
