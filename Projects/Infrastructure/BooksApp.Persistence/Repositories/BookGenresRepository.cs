using BooksApp.Application.Interfaces.Repositories;
using BooksApp.Domain.Entities;
using BooksApp.Persistence.Context.DataBase;
using BooksApp.Persistence.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace BooksApp.Persistence.Repositories
{
    public class BookGenresRepository : BaseRepository<BookGenresEntity>, IBookGenresRepository
    {
        public BookGenresRepository(IAppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<BookGenresEntity> GetByBookAndGenreAsync(Guid bookGuid, Guid genreGuid, CancellationToken cancellationToken)
        {
            return await GetInternal()
                .FirstOrDefaultAsync(x => x.Genre.Guid == genreGuid && x.Book.Guid == bookGuid, cancellationToken);
        }

        public async Task<List<GenreEntity>> GetGenresByBookAsync(Guid bookGuid, CancellationToken cancellationToken)
        {
            return await GetInternal()
                .Where(x => x.Book.Guid == bookGuid)
                .Select(x => x.Genre)
                .ToListAsync(cancellationToken);
        }
    }
}
