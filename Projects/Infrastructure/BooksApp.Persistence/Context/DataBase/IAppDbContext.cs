using BooksApp.Domain.Entities;
using BooksApp.Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;

namespace BooksApp.Persistence.Context.DataBase
{
    public interface IAppDbContext
    {
        DbSet<AuthorEntity> Authors { get; }
        DbSet<BookEntity> Books { get; }
        DbSet<GenreEntity> Genre { get; }
        DbSet<BookAuthorsEntity> BookAuthors { get; }
        DbSet<BookGenresEntity> BookGenres { get; }
        void MigrateDatabase();
        DbSet<T> GetDbSet<T>() where T : BaseEntity;
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        int SaveChanges();
        Task DisposeContextAsync();
    }
}
