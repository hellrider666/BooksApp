using BooksApp.Application.Abstract;
using BooksApp.Application.Interfaces.Repositories;
using BooksApp.Application.Mapping.DTOs;
using BooksApp.Application.Mapping.Helpers;
using BooksApp.Domain.Entities;
using MediatR;

namespace BooksApp.Application.Features.BookFeatures.Queries.GetBooks
{
    public class GetBooksHandler : BaseHandler, IRequestHandler<GetBooksRequest, GetBooksResponse>
    {
        public GetBooksHandler(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public async Task<GetBooksResponse> Handle(GetBooksRequest request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.DoWorkAsync<IBookRepository, BookEntity, GetBooksResponse>(async repository =>
            {
                var books = await repository.GetByFilterAsync(request.Name, request.AuthorGuid, cancellationToken,
                    request.SortByName, request.SortByPublishingYear, request.SortByPublishingYearDESC, request.SortByAuthor);

                return new GetBooksResponse { Books = books.ToBookDTO() };
            });
        }
    }
}
