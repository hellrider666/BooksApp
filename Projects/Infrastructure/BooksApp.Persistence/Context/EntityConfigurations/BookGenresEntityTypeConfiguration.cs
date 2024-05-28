using BooksApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BooksApp.Persistence.Context.EntityConfigurations
{
    public class BookGenresEntityTypeConfiguration : IEntityTypeConfiguration<BookGenresEntity>
    {
        public void Configure(EntityTypeBuilder<BookGenresEntity> builder)
        {
            builder
                .ToTable("BookGenres");

            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn()
                .IsRequired();

            builder
                .HasOne(x => x.Genre)
                .WithMany(x => x.Books)
                .HasConstraintName("Genre_Book")
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder
                .HasOne(x => x.Book)
                .WithMany(x => x.Genres)
                .HasConstraintName("Book_Genre")
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
        }
    }
}
