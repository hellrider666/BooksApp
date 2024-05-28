using BooksApp.Application.Interfaces.Requests;

namespace BooksApp.Application.Features.AuthorFeatures.Commands.CreateAuthor
{
    public class CreateAuthorRequest : IAppRequest<CreateAuthorResponse>
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string? Surname { get; set; }
    }
}
