using BooksApp.Application.Interfaces.Requests;

namespace BooksApp.Application.Features.BookFeatures.Commands.UpdateBook
{
    public class UpdateBookRequest : IAppRequest<UpdateBookResponse>
    {
        public Guid Guid { get; set; }
        public string? Name { get; set; }
        public DateTime? PublishingYear { get; set; }
    }
}
