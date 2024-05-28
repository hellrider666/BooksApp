using BooksApp.Application.Interfaces.Requests;

namespace BooksApp.Application.Features.BookGenresFeatures.Command.AddBookGenre
{
    public class AddBookGenreRequest : IAppRequest<AddBookGenreResponse>
    {
        public Guid BookGuid { get; set; }
        public Guid GenreGuid { get; set; }
    }
}
