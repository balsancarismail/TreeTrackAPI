﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeTrackAPI.DataAccessLayer.abstracts;

namespace TreeTrackAPI.Services.concretes
{
    public class LocationService
    {
        private readonly ILocationDal location;

        public LocationService(ILocationDal location)
        {
            this.location = location;
        }
    }
}