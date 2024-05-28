using BooksApp.Application.Interfaces.Repositories;
using BooksApp.Application.Interfaces.Repositories.ExtensionsRepositories;
using BooksApp.Domain.Entities;
using BooksApp.Persistence.Context.DataBase;
using BooksApp.Persistence.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace BooksApp.Persistence.Repositories
{
    public class AuthorRepository : BaseRepository<AuthorEntity>, IAuthorRepository
    {
        public AuthorRepository(IAppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<AuthorEntity> GetByGuidAsync(Guid guid, CancellationToken cancellationToken)
        {
            return await GetInternal().FirstOrDefaultAsync(x => x.Guid == guid, cancellationToken);
        }
    }
}
