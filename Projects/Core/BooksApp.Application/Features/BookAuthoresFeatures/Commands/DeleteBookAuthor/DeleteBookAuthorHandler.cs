using BooksApp.Application.Abstract;
using BooksApp.Application.Interfaces.Repositories;
using BooksApp.Domain.Entities;
using MediatR;

namespace BooksApp.Application.Features.BookAuthoresFeatures.Commands.DeleteBookAuthor
{
    public class DeleteBookAuthorHandler : BaseHandler, IRequestHandler<DeleteBookAuthorRequest, DeleteBookAuthorResponse>
    {
        public DeleteBookAuthorHandler(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public async Task<DeleteBookAuthorResponse> Handle(DeleteBookAuthorRequest request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.DoWorkAsync<IBookAuthorsRepository, BookAuthorsEntity, DeleteBookAuthorResponse>(async repository => 
            {
                var bookAuthor = await repository.GetByBookAndAuthorAsync(request.BookGuid, request.AuthorGuid, cancellationToken);

                repository.Delete(bookAuthor);

                await _unitOfWork.SaveCnahgesAsync(cancellationToken);

                return new DeleteBookAuthorResponse();
            });
        }
    }
}
