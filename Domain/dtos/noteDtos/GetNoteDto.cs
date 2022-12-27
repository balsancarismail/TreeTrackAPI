namespace TreeTrackAPI.Domain.dtos.noteDtos
{
    public class GetNoteDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public byte[]? Image { get; set; }
        public DateTime Date { get; set; }
    }
}
