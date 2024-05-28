using BooksApp.Application.Interfaces.Repositories;
using BooksApp.Domain.Entities;
using FluentValidation;

namespace BooksApp.Application.Features.BookFeatures.Commands.UpdateBook
{
    public class UpdateBookValidator : AbstractValidator<UpdateBookRequest>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateBookValidator(IUnitOfWork unitOfWork)
        {
            ClassLevelCascadeMode = CascadeMode.Stop;

            _unitOfWork = unitOfWork;

            RuleFor(x => x.Guid)
                .NotNull()
                    .WithMessage("Guid cannot be empty")
                .MustAsync(async (guid, cancellation) =>
                {
                    var exist = await _unitOfWork.DoWorkAsync<IBookRepository, BookEntity, BookEntity>(async repository => await repository.GetByGuidAsync(guid, cancellation));

                    return exist != null;

                }).WithMessage("The book doesn't exist");

            When(x => !string.IsNullOrEmpty(x.Name), () =>
            {
                RuleFor(x => x.Name)
                .NotNull()
                    .WithMessage("Name cannot be null")
                .NotEmpty()
                    .WithMessage("Name cannot be null")
                .MaximumLength(256)
                    .WithMessage("The Name length cannot be more than 256 characters");
            });
        }
    }
}
