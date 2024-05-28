using BooksApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BooksApp.Persistence.Context.EntityConfigurations
{
    public class BookAuthorsEntityTypeConfiguration : IEntityTypeConfiguration<BookAuthorsEntity>
    {
        public void Configure(EntityTypeBuilder<BookAuthorsEntity> builder)
        {
            builder
                .ToTable("BookAuthors");

            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn()
                .IsRequired();

            builder
                .HasOne(x => x.Author)
                .WithMany(x => x.Books)
                .HasConstraintName("Author_Books")
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            builder
                .HasOne(x => x.Book)
                .WithMany(x => x.Authors)
                .HasConstraintName("Book_Authors")
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
        }
    }
}
