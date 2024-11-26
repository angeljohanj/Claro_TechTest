namespace Claro_TechTest.DTOs.Requests
{
    public class CreateANewBookDTO
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int? PageCount { get; set; }
        public string? Excerpt { get; set; }
        public DateTime? PublishDate { get; set; }
    }
}
