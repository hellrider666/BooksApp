using BooksApp.Application.Mapping.DTOs;

namespace BooksApp.Application.Features.BookFeatures.Queries.GetBooks
{
    public class GetBooksResponse
    {
        public List<BookDTO> Books { get; set; }
    }
}
