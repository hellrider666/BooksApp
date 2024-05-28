using BooksApp.Application.Interfaces.Repositories;
using BooksApp.Domain.Entities;
using BooksApp.Persistence.Context.DataBase;
using BooksApp.Persistence.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace BooksApp.Persistence.Repositories
{
    public class GenreRepository : BaseRepository<GenreEntity>, IGenreRepository
    {
        public GenreRepository(IAppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<GenreEntity> GetByGuidAsync(Guid guid, CancellationToken cancellationToken)
        {
            return await GetInternal().FirstOrDefaultAsync(x => x.Guid == guid, cancellationToken);
        }
    }
}
