using Microsoft.AspNetCore.Http;

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
