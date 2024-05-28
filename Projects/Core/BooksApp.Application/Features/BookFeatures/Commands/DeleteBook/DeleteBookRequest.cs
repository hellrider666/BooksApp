using BooksApp.Application.Interfaces.Requests;

namespace BooksApp.Application.Features.BookFeatures.Commands.DeleteBook
{
    public class DeleteBookRequest : IAppRequest<DeleteBookResponse>
    {
        public Guid Guid { get; set; }
    }
}
