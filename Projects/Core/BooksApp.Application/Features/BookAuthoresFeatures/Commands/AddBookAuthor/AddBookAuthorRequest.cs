using BooksApp.Application.Interfaces.Requests;

namespace BooksApp.Application.Features.BookAuthoresFeatures.Commands.AddBookAuthor
{
    public class AddBookAuthorRequest : IAppRequest<AddBookAuthorResponse>
    {
        public Guid BookGuid { get; set; }
        public Guid AuthorGuid { get; set; }
    }
}
