using BooksApp.Application.Interfaces.Repositories;
using BooksApp.Domain.Entities;
using BooksApp.Persistence.Context.DataBase;
using BooksApp.Persistence.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace BooksApp.Persistence.Repositories
{
    public class BookAuthorsRepository : BaseRepository<BookAuthorsEntity>, IBookAuthorsRepository
    {
        public BookAuthorsRepository(IAppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<BookAuthorsEntity> GetByBookAndAuthorAsync(Guid bookGuid, Guid authorGuid, CancellationToken cancellationToken)
        {
            return await GetInternal()
                .FirstOrDefaultAsync(x => x.Author.Guid == authorGuid && x.Book.Guid == bookGuid, cancellationToken);
        }

        public async Task<List<BookEntity>> GetBooksByAuthorAsync(Guid authorGuid, CancellationToken cancellationToken)
        {
            return await GetInternal()
                .Where(x => x.Author.Guid == authorGuid)
                .Select(x => x.Book)
                .ToListAsync(cancellationToken);
        }
    }
}
