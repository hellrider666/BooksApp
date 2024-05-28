using BooksApp.Application.Interfaces.Repositories;
using BooksApp.Application.Interfaces.Repositories.Base;
using BooksApp.Domain.Entities.Base;
using BooksApp.Persistence.Context.DataBase;
using Microsoft.Extensions.DependencyInjection;

namespace BooksApp.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IAppDbContext _DbContext;
        private readonly IServiceProvider _serviceProvider;
        public UnitOfWork(IAppDbContext context, IServiceProvider serviceProvider)
        {
            _DbContext = context;

            _serviceProvider = serviceProvider;
        }   

        public async Task<TResult> DoWorkAsync<TRepository, TEntity, TResult>(Func<TRepository, Task<TResult>> action)
            where TRepository : class, IBaseRepository<TEntity>
            where TEntity : BaseEntity
        {
            try
            {
                return await action(GetRepository<TRepository>());
            }
            catch
            {
                throw;
            }
        }
              
        public async Task<int> SaveCnahgesAsync(CancellationToken cancellationToken)
        {
            return await _DbContext.SaveChangesAsync(cancellationToken);
        }

        public int SaveChanges()
        {
            return _DbContext.SaveChanges();
        }

        private T GetRepository<T>()
        {
            var repositoryInstance = _serviceProvider.GetService<T>();

            if (repositoryInstance == null)
                throw new Exception($"Service {nameof(repositoryInstance)} is not registered");

            return repositoryInstance;
        }

        private bool disposed = false;

        public virtual async void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    await _DbContext.DisposeContextAsync();
                }

                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
