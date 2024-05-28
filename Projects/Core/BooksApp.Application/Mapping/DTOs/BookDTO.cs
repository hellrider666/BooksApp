namespace BooksApp.Application.Mapping.DTOs
{
    public class BookDTO
    {
        public Guid Guid { get; set; }
        public string Name { get; set; }
        public DateTime PublishingYear { get; set; }
        public List<AuthorDTO>? Authors { get; set; }
        public List<GenreDTO>? Genres { get; set; }
    }
}
