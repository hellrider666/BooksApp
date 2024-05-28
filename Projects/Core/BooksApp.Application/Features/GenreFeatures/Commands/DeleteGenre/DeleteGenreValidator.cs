using BooksApp.Application.Interfaces.Repositories;
using BooksApp.Domain.Entities;
using FluentValidation;

namespace BooksApp.Application.Features.GenreFeatures.Commands.DeleteGenre
{
    public class DeleteGenreValidator : AbstractValidator<DeleteGenreRequest>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteGenreValidator(IUnitOfWork unitOfWork)
        {
            ClassLevelCascadeMode = CascadeMode.Stop;

            _unitOfWork = unitOfWork;

            RuleFor(x => x.Guid)
                .NotNull()
                    .WithMessage("Guid cannot be empty")
                .MustAsync(async (guid, cancellation) =>
                {
                    var exist = await _unitOfWork.DoWorkAsync<IGenreRepository, GenreEntity, GenreEntity>(async repository =>
                        await repository.GetByGuidAsync(guid, cancellation));

                    return exist != null;
                }).WithMessage("Genre doesn't exist");
        }
    }
}
