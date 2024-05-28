using BooksApp.Application.Interfaces.Repositories;
using BooksApp.Domain.Entities;
using FluentValidation;

namespace BooksApp.Application.Features.AuthorFeatures.Commands.DeleteAuthor
{
    public class DeleteAuthorValidator : AbstractValidator<DeleteAuthorRequest>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteAuthorValidator(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;

            ClassLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.AuthorGuid)
                .NotNull()
                    .WithMessage("Guid cannot be empty")
                .MustAsync(async (guid, cancellation) =>
                {
                    var exist = await _unitOfWork.DoWorkAsync<IAuthorRepository, AuthorEntity, AuthorEntity>
                        (async repository => await repository.GetByGuidAsync(guid, cancellation));

                    return exist != null;

                }).WithMessage("The author does not exist");
        }
    }
}
