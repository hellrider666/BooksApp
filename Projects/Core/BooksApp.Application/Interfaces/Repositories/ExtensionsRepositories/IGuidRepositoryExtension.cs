using BooksApp.Domain.Entities.Base;

namespace BooksApp.Application.Interfaces.Repositories.ExtensionsRepositories
{
    public interface IGuidRepositoryExtension<T> where T : BaseEntity
    {
        Task<T> GetByGuidAsync(Guid guid, CancellationToken cancellationToken);
    }
}
