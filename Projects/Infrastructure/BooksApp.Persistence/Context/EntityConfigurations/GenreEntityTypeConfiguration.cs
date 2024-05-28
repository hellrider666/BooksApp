using BooksApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BooksApp.Persistence.Context.EntityConfigurations
{
    public class GenreEntityTypeConfiguration : IEntityTypeConfiguration<GenreEntity>
    {
        public void Configure(EntityTypeBuilder<GenreEntity> builder)
        {
            builder
                .ToTable("Genres");

            builder
                .HasIndex(x => x.Guid)
                .HasDatabaseName("Genre_Guid_Index")
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
                .HasMaxLength(30)
                .IsRequired();

            builder
                .HasMany(x => x.Books)
                .WithOne(x => x.Genre)
                .HasConstraintName("Genre_Book")
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
        }
    }
}
