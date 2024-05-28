using BooksApp.Application.Abstract;
using BooksApp.Application.Interfaces.Repositories;
using BooksApp.Domain.Entities;
using MediatR;

namespace BooksApp.Application.Features.GenreFeatures.Commands.DeleteGenre
{
    public class DeleteGenreHandler : BaseHandler, IRequestHandler<DeleteGenreRequest, DeleteGenreResponse>
    {
        public DeleteGenreHandler(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public async Task<DeleteGenreResponse> Handle(DeleteGenreRequest request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.DoWorkAsync<IGenreRepository, GenreEntity, DeleteGenreResponse>(async repository =>
            {
                var genre = await repository.GetByGuidAsync(request.Guid, cancellationToken);

                repository.Delete(genre);

                await _unitOfWork.SaveCnahgesAsync(cancellationToken);

                return new DeleteGenreResponse();
            });
        }
    }
}
