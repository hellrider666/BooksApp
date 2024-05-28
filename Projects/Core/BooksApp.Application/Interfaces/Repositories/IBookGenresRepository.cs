using BooksApp.Application.Interfaces.Repositories.Base;
using BooksApp.Domain.Entities;

namespace BooksApp.Application.Interfaces.Repositories
{
    public interface IBookGenresRepository : IBaseRepository<BookGenresEntity>
    {
        Task<BookGenresEntity> GetByBookAndGenreAsync(Guid bookGuid, Guid genreGuid, CancellationToken cancellationToken);
        Task<List<GenreEntity>> GetGenresByBookAsync(Guid bookGuid, CancellationToken cancellationToken);
    }
}
