using BooksApp.Application.Interfaces.Requests;

namespace BooksApp.Application.Features.BookAuthoresFeatures.Commands.DeleteBookAuthor
{
    public class DeleteBookAuthorRequest : IAppRequest<DeleteBookAuthorResponse>
    {
        public Guid AuthorGuid { get; set; }
        public Guid BookGuid { get; set; }
    }
}
