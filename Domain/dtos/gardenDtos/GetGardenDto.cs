﻿using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeTrackAPI.Domain.concretes;

namespace TreeTrackAPI.Domain.dtos.gardenDtos
{
    public class GetGardenDto
    {
        public string GardenName { get; set; }
        public double? Area { get; set; }
        public Polygon Polygon { get; set; }
        public List<Note> Notes { get; set; }
        public List<Plant> Plants { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int Id { get; set; }
    }
}