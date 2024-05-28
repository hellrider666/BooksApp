using BooksApp.Application.Mapping.DTOs;
using BooksApp.Domain.Entities;

namespace BooksApp.Application.Mapping.Helpers
{
    public static class AuthorMappingHelper
    {
        public static List<AuthorDTO>? ToAuthorDTO(this List<BookAuthorsEntity> source)
        {
            if (!source.Any())
                return null;

            return source.Select(x => new AuthorDTO
            {
                Guid = x.Author.Guid,
                Name = x.Author.Name,
                Lastname = x.Author.Lastname,
                Surname = !string.IsNullOrWhiteSpace(x.Author.Surname) ? x.Author.Surname : null               
            }).ToList();
        }
    }
}
