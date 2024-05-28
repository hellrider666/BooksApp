using BooksApp.Application.Interfaces.Requests;

namespace BooksApp.Application.Features.BookFeatures.Commands.CreateBook
{
    public class CreateBookRequest : IAppRequest<CreateBookResponse>
    {
        public string Name { get; set; }
        public DateTime PublishingYear { get; set; }
    }
}
