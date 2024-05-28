using BooksApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BooksApp.Persistence.Context.EntityConfigurations
{
    public class BookEntityTypeConfiguration : IEntityTypeConfiguration<BookEntity>
    {
        public void Configure(EntityTypeBuilder<BookEntity> builder)
        {
            builder
                .ToTable("Books");

            builder
                .HasIndex(x => x.Guid)
                .HasDatabaseName("Book_Guid_Index")
                .IsUnique();

            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn()
                .IsRequired();

            builder
                .Property(x => x.Name)
                .HasMaxLength(256)
                .IsRequired();

            builder
                .Property(x => x.PublishingYear)
                .HasColumnType("DATE")
                .IsRequired();

            builder
                .HasMany(x => x.Authors)
                .WithOne(x => x.Book)
                .HasConstraintName("Book_Author")
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            builder
                .HasMany(x => x.Genres)
                .WithOne(x => x.Book)
                .HasConstraintName("Book_Genre")
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
        }
    }
}
