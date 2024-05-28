using BooksApp.Application.Interfaces.Repositories;
using FluentValidation;

namespace BooksApp.Application.Features.BookFeatures.Commands.CreateBook
{
    public class CreateBookValidator : AbstractValidator<CreateBookRequest>
    {
        public CreateBookValidator()
        {
            ClassLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.Name)
                .NotNull()
                    .WithMessage("Name cannot be null")
                .NotEmpty()
                    .WithMessage("Name cannot be null")
                .MaximumLength(256)
                    .WithMessage("The Name length cannot be more than 256 characters");

            RuleFor(x => x.PublishingYear)
                .NotNull()
                    .WithMessage("Publishing year cannot be null");
        }
    }
}
