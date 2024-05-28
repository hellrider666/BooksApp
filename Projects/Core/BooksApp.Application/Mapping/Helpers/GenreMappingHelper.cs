using BooksApp.Application.Mapping.DTOs;
using BooksApp.Domain.Entities;

namespace BooksApp.Application.Mapping.Helpers
{
    public static class GenreMappingHelper
    {
        public static List<GenreDTO>? ToGenreDTO(this List<BookGenresEntity> source)
        {
            if (!source.Any())
                return null;

            return source.Select(x => new GenreDTO
            {
                Name = x.Genre.Name,
                Guid = x.Genre.Guid
            }).ToList();
        }
    }
}
