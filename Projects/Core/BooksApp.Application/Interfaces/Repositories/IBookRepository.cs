using BooksApp.Application.Interfaces.Repositories.Base;
using BooksApp.Application.Interfaces.Repositories.ExtensionsRepositories;
using BooksApp.Domain.Entities;

namespace BooksApp.Application.Interfaces.Repositories
{
    public interface IBookRepository : IBaseRepository<BookEntity>, IGuidRepositoryExtension<BookEntity>
    {
        Task<List<BookEntity>> GetByFilterAsync(string? Name, Guid? authorGuid, CancellationToken cancellationToken, bool sortByName = false, bool sortByPublishingYear = false, 
            bool sortByPublishingYearDESC = false, bool sortByAuthor = false);
    }
}
