using BooksApp.Application.Interfaces.Requests;

namespace BooksApp.Application.Features.GenreFeatures.Commands.DeleteGenre
{
    public class DeleteGenreRequest : IAppRequest<DeleteGenreResponse>
    {
        public Guid Guid { get; set; }
    }
}
