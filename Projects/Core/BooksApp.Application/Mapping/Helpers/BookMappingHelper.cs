using BooksApp.Application.Mapping.DTOs;
using BooksApp.Domain.Entities;

namespace BooksApp.Application.Mapping.Helpers
{
    public static class BookMappingHelper 
    {
        public static List<BookDTO>? ToBookDTO(this List<BookEntity> source)
        {
            if (!source.Any())
                return null;

            return source.Select(x => new BookDTO
            {
                Name = x.Name,
                Guid = x.Guid,
                PublishingYear = x.PublishingYear,
                Authors = x.Authors.ToAuthorDTO(),
                Genres = x.Genres.ToGenreDTO()
            }).ToList();
        }
    }
}
