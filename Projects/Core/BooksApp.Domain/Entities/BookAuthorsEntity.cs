using BooksApp.Domain.Entities.Base;

namespace BooksApp.Domain.Entities
{
    public class BookAuthorsEntity : BaseEntity
    {
        public AuthorEntity Author { get; set; }
        public BookEntity Book { get; set; }
    }
}
