using BooksApp.Application.Interfaces.Repositories;
using BooksApp.Domain.Entities;
using BooksApp.Persistence.Context.DataBase;
using BooksApp.Persistence.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace BooksApp.Persistence.Repositories
{
    public class BookRepository : BaseRepository<BookEntity>, IBookRepository
    {
        public BookRepository(IAppDbContext dbContext) : base(dbContext) { }

        public async Task<List<BookEntity>> GetByFilterAsync
            (string? Name, Guid? authorGuid, CancellationToken cancellationToken, bool sortByName = false, bool sortByPublishingYear = false, bool sortByPublishingYearDESC = false, 
            bool sortByAuthor = false)
        {
            IQueryable<BookEntity> booksQuery = GetInternal()
                .Include(x => x.Authors).ThenInclude(x => x.Author)
                .Include(x => x.Genres).ThenInclude(x => x.Genre)
                .Where(x => x.Genres.Count() != 0 && x.Authors.Count() != 0);

            if (!string.IsNullOrEmpty(Name))
                booksQuery = booksQuery.Where(x => x.Name.ToLower().Contains(Name.ToLower()));

            if (authorGuid != null)
                booksQuery = booksQuery
                    .Where(x => x.Authors
                    .Where(x => x.Author.Guid == authorGuid)
                    .Count() != 0);

            if (sortByName)
                booksQuery = booksQuery
                    .OrderBy(x => x.Name);

            if (sortByPublishingYear)
                if (sortByPublishingYearDESC)
                    booksQuery = booksQuery
                        .OrderByDescending(x => x.PublishingYear);
                else
                    booksQuery = booksQuery
                        .OrderBy(x => x.PublishingYear);

            if (sortByAuthor)
                booksQuery = booksQuery
                    .Select(x => new {
                        Book = x,
                        AuthorLastname = x.Authors.Select(a => a.Author.Lastname).FirstOrDefault()
                    })
                    .OrderBy(x => x.AuthorLastname)
                    .Select(x => x.Book);

            return await booksQuery.ToListAsync(cancellationToken);
        }

        public async Task<BookEntity> GetByGuidAsync(Guid guid, CancellationToken cancellationToken)
        {
            return await GetInternal().FirstOrDefaultAsync(x => x.Guid == guid, cancellationToken);
        }
    }
}
