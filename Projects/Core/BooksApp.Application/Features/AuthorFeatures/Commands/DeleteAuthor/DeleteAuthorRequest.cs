using BooksApp.Application.Interfaces.Requests;

namespace BooksApp.Application.Features.AuthorFeatures.Commands.DeleteAuthor
{
    public class DeleteAuthorRequest : IAppRequest<DeleteAuthorResponse>
    {
        public Guid AuthorGuid { get; set; }
    }
}
