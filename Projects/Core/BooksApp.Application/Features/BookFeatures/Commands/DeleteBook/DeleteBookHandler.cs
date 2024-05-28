using BooksApp.Application.Abstract;
using BooksApp.Application.Interfaces.Repositories;
using BooksApp.Domain.Entities;
using MediatR;

namespace BooksApp.Application.Features.BookFeatures.Commands.DeleteBook
{
    public class DeleteBookHandler : BaseHandler, IRequestHandler<DeleteBookRequest, DeleteBookResponse>
    {
        public DeleteBookHandler(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public async Task<DeleteBookResponse> Handle(DeleteBookRequest request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.DoWorkAsync<IBookRepository, BookEntity, DeleteBookResponse>(async repository =>
            {
                var book = await repository.GetByGuidAsync(request.Guid, cancellationToken);

                repository.Delete(book);

                await _unitOfWork.SaveCnahgesAsync(cancellationToken);

                return new DeleteBookResponse();
            });
        }
    }
}
