﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeTrackAPI.Domain.abstracts;

namespace TreeTrackAPI.Domain.concretes
{
    public class Garden : BaseEntity
    {
        public string GardenName { get; set; }
        public double? Area { get; set; }
        public List<User> Users { get; set; }
        public List<Location> Locations { get; set; }
        public List<Note> Notes { get; set; }
        public List<Plant> Plants { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int Id { get; set; }
    }
}
