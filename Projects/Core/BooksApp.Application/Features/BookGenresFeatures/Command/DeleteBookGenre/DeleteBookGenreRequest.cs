using BooksApp.Application.Interfaces.Requests;

namespace BooksApp.Application.Features.BookGenresFeatures.Command.DeleteBookGenre
{
    public class DeleteBookGenreRequest : IAppRequest<DeleteBookGenreResponse>
    {
        public Guid BookGuid { get; set; }
        public Guid GenreGuid { get; set; }
    }
}
