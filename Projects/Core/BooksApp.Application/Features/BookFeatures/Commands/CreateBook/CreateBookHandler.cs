using BooksApp.Application.Abstract;
using BooksApp.Application.Interfaces.Repositories;
using BooksApp.Domain.Entities;
using MediatR;

namespace BooksApp.Application.Features.BookFeatures.Commands.CreateBook
{
    public class CreateBookHandler : BaseHandler, IRequestHandler<CreateBookRequest, CreateBookResponse>
    {
        public CreateBookHandler(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public async Task<CreateBookResponse> Handle(CreateBookRequest request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.DoWorkAsync<IBookRepository, BookEntity, CreateBookResponse>(async repository =>
            {
                var book = new BookEntity
                {
                    Guid = Guid.NewGuid(),
                    Name = request.Name,
                    PublishingYear = request.PublishingYear.Date
                };

                repository.Create(book);

                await _unitOfWork.SaveCnahgesAsync(cancellationToken);

                return new CreateBookResponse { Guid = book.Guid };
            });
        }
    }
}
