﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeTrackAPI.Domain.dtos.noteDtos
{
    public class SaveNoteDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public IFormFile? ImageFile { get; set; }
        public DateTime Date { get; set; }
    }
}
