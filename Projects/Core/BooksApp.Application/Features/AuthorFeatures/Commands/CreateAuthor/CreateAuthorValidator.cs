using FluentValidation;

namespace BooksApp.Application.Features.AuthorFeatures.Commands.CreateAuthor
{
    public class CreateAuthorValidator : AbstractValidator<CreateAuthorRequest>
    {
        public CreateAuthorValidator() 
        {
            ClassLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.Name)
                .NotNull()
                    .WithMessage("Name cannot be empty")
                .NotEmpty()
                    .WithMessage("Name cannot be empty")
                .MaximumLength(128)
                    .WithMessage("The name length cannot be more than 128 characters");

            RuleFor(x => x.LastName)
                .NotNull()
                    .WithMessage("LastName cannot be empty")
                .NotEmpty()
                    .WithMessage("LastName cannot be empty")
                .MaximumLength(128)
                    .WithMessage("The LastName length cannot be more than 128 characters");

            When(x => !string.IsNullOrEmpty(x.Surname), () =>
            {
                RuleFor(x => x.Name)
                    .MaximumLength(128)
                        .WithMessage("The Surname length cannot be more than 128 characters");
            });            
        }
    }
}
