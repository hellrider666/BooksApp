using BooksApp.Application.Abstract;
using BooksApp.Application.Interfaces.Repositories;
using BooksApp.Domain.Entities;
using MediatR;

namespace BooksApp.Application.Features.AuthorFeatures.Commands.DeleteAuthor
{
    public class DeleteAuthorHandler : BaseHandler, IRequestHandler<DeleteAuthorRequest, DeleteAuthorResponse>
    {
        public DeleteAuthorHandler(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public async Task<DeleteAuthorResponse> Handle(DeleteAuthorRequest request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.DoWorkAsync<IAuthorRepository, AuthorEntity, DeleteAuthorResponse>(async repository =>
            {
                var author = await repository.GetByGuidAsync(request.AuthorGuid, cancellationToken);

                repository.Delete(author);

                await _unitOfWork.SaveCnahgesAsync(cancellationToken);

                return new DeleteAuthorResponse();
            });
        }
    }
}
