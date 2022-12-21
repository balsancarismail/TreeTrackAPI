using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeTrackAPI.Domain.abstracts;

namespace TreeTrackAPI.Domain.concretes
{
    public class Location : BaseEntity
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public Garden Garden { get; set; }
    }
}
