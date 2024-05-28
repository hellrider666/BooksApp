using BooksApp.Application.Interfaces.Requests;

namespace BooksApp.Application.Features.BookFeatures.Queries.GetBooks
{
    public class GetBooksRequest : IAppRequest<GetBooksResponse>
    {
        public string? Name { get; set; }
        public Guid? AuthorGuid { get; set; }

        public bool SortByName { get; set; } = false;
        public bool SortByPublishingYear { get; set; } = false;
        public bool SortByPublishingYearDESC { get; set; } = false;
        public bool SortByAuthor { get; set; } = false;
    }
}
