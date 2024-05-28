using BooksApp.Application.Interfaces.Repositories.Base;
using BooksApp.Domain.Entities;

namespace BooksApp.Application.Interfaces.Repositories
{
    public interface IBookAuthorsRepository : IBaseRepository<BookAuthorsEntity>
    {
        Task<BookAuthorsEntity> GetByBookAndAuthorAsync(Guid bookGuid, Guid authorGuid, CancellationToken cancellationToken);
        Task<List<BookEntity>> GetBooksByAuthorAsync(Guid authorGuid, CancellationToken cancellationToken);
    }
}
