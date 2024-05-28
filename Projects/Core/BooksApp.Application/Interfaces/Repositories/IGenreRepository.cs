using BooksApp.Application.Interfaces.Repositories.Base;
using BooksApp.Application.Interfaces.Repositories.ExtensionsRepositories;
using BooksApp.Domain.Entities;

namespace BooksApp.Application.Interfaces.Repositories
{
    public interface IGenreRepository : IBaseRepository<GenreEntity>, IGuidRepositoryExtension<GenreEntity>
    {
    }
}
