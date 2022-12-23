using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeTrackAPI.Domain.abstracts;

namespace TreeTrackAPI.Domain.concretes
{
    public class Note : BaseEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public DateTime Date { get; set; }
    }
}
