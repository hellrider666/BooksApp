using BooksApp.Domain.Entities;
using BooksApp.Domain.Entities.Base;
using BooksApp.Persistence.Context.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace BooksApp.Persistence.Context.DataBase
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public DbSet<AuthorEntity> Authors { get; }

        public DbSet<BookEntity> Books { get; }

        public DbSet<GenreEntity> Genre { get; }

        public DbSet<BookAuthorsEntity> BookAuthors { get; }

        public DbSet<BookGenresEntity> BookGenres { get; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BookEntityTypeConfiguration).Assembly);

            modelBuilder.UseSerialColumns();
        }

        public DbSet<T> GetDbSet<T>() where T : BaseEntity
        {
            return base.Set<T>();
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }

        public async Task DisposeContextAsync()
        {
            await base.DisposeAsync();
        }

        public void MigrateDatabase()
        {
            base.Database.Migrate();
        }
    }
}
