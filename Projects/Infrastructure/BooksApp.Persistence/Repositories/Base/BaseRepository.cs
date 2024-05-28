using BooksApp.Application.Interfaces.Repositories.Base;
using BooksApp.Domain.Entities.Base;
using BooksApp.Persistence.Context.DataBase;
using Microsoft.EntityFrameworkCore;

namespace BooksApp.Persistence.Repositories.Base
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly IAppDbContext _dbContext;

        public BaseRepository(IAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Create(T entity)
        {
            _dbContext.GetDbSet<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            _dbContext.GetDbSet<T>().Remove(entity);
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<List<T>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await GetInternal().ToListAsync(cancellationToken);
        }       

        public virtual async Task<T> GetAsync(long Id, CancellationToken cancellationToken)
        {
            return await GetInternal().FirstOrDefaultAsync(x => x.Id == Id, cancellationToken);
        }

        protected IQueryable<T> GetInternal()
        {
            return _dbContext.GetDbSet<T>();
        }
    }
}
