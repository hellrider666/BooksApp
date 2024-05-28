using BooksApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;

namespace BooksApp.Persistence.Context.EntityConfigurations
{
    public class AuthorEntityTypeConfiguration : IEntityTypeConfiguration<AuthorEntity>
    {
        public void Configure(EntityTypeBuilder<AuthorEntity> builder)
        {
            builder
                .ToTable("Authors");

            builder
                .HasIndex(x => x.Guid)
                .HasDatabaseName("Author_Guid_Index")
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
                .HasMaxLength(128)
                .IsRequired();

            builder
                .Property(x => x.Lastname)
                .HasMaxLength(128)
                .IsRequired();

            builder
                .Property(x => x.Surname)
                .HasMaxLength(128)
                .IsRequired(false);

            builder
                .HasMany(x => x.Books)
                .WithOne(x => x.Author)
                .HasConstraintName("Author_Book")
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
        }
    }
}
