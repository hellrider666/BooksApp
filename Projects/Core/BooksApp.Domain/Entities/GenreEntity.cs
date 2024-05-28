using BooksApp.Domain.Entities.Base;

namespace BooksApp.Domain.Entities
{
    public class GenreEntity : BaseEntity
    {
        public Guid Guid { get; set; }
        public string Name { get; set; }
        public List<BookGenresEntity> Books { get; set; }
    }
}
