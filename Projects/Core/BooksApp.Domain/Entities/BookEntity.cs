using BooksApp.Domain.Entities.Base;

namespace BooksApp.Domain.Entities
{
    public class BookEntity : BaseEntity
    {
        public Guid Guid { get; set; }
        public string Name { get; set; }
        public List<BookAuthorsEntity> Authors { get; set; }
        public DateTime PublishingYear { get; set; }
        public List<BookGenresEntity> Genres {  get; set; }
    }
}
