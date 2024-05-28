using BooksApp.Application.Abstract;
using BooksApp.Application.Interfaces.Repositories;
using BooksApp.Domain.Entities;
using MediatR;

namespace BooksApp.Application.Features.BookFeatures.Commands.UpdateBook
{
    public class UpdateBookHandler : BaseHandler, IRequestHandler<UpdateBookRequest, UpdateBookResponse>
    {
        public UpdateBookHandler(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public async Task<UpdateBookResponse> Handle(UpdateBookRequest request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.DoWorkAsync<IBookRepository, BookEntity, UpdateBookResponse>(async repository =>
            {
                var book = await repository.GetByGuidAsync(request.Guid, cancellationToken);

                book.Name = request.Name;

                if (request.PublishingYear.HasValue)
                    book.PublishingYear = request.PublishingYear.Value;

                repository.Update(book);

                await _unitOfWork.SaveCnahgesAsync(cancellationToken);

                return new UpdateBookResponse();
            });
        }
    }
}
