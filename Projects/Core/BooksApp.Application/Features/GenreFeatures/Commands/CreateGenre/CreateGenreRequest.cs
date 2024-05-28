using BooksApp.Application.Interfaces.Requests;

namespace BooksApp.Application.Features.GenreFeatures.Commands.CreateGenre
{
    public class CreateGenreRequest : IAppRequest<CreateGenreResponse>
    {
        public string Name { get; set; }
    }
}
