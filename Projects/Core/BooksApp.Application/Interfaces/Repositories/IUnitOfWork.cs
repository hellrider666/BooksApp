using BooksApp.Application.Interfaces.Repositories.Base;
using BooksApp.Domain.Entities.Base;

namespace BooksApp.Application.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        Task<TResult> DoWorkAsync<TRepository, TEntity, TResult>(Func<TRepository, Task<TResult>> action)
            where TRepository : class, IBaseRepository<TEntity>
            where TEntity : BaseEntity;

        Task<int> SaveCnahgesAsync(CancellationToken cancellationToken);
        int SaveChanges();
    }
}
