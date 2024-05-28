using BooksApp.Domain.Entities.Base;

namespace BooksApp.Domain.Entities
{
    public class AuthorEntity : BaseEntity
    {
        public virtual Guid Guid { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string? Surname { get; set; }
        public List<BookAuthorsEntity> Books { get; set; }
    }
}
