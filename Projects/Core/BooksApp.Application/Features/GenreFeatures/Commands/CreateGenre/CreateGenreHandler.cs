using BooksApp.Application.Abstract;
using BooksApp.Application.Interfaces.Repositories;
using BooksApp.Domain.Entities;
using MediatR;

namespace BooksApp.Application.Features.GenreFeatures.Commands.CreateGenre
{
    public class CreateGenreHandler : BaseHandler, IRequestHandler<CreateGenreRequest, CreateGenreResponse>
    {
        public CreateGenreHandler(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public async Task<CreateGenreResponse> Handle(CreateGenreRequest request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.DoWorkAsync<IGenreRepository, GenreEntity, CreateGenreResponse>(async repository =>
            {
                var genre = new GenreEntity
                {
                    Guid = Guid.NewGuid(),
                    Name = request.Name,
                };

                repository.Create(genre);

                await _unitOfWork.SaveCnahgesAsync(cancellationToken);

                return new CreateGenreResponse { Guid = genre.Guid };
            });
        }
    }
}
