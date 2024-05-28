using BooksApp.Domain.Entities.Base;

namespace BooksApp.Domain.Entities
{
    public class BookGenresEntity : BaseEntity
    {
        public BookEntity Book { get; set; }
        public GenreEntity Genre { get; set; }
    }
}
