using FluentValidation;

namespace BooksApp.Application.Features.GenreFeatures.Commands.CreateGenre
{
    public class CreateGenreValidator : AbstractValidator<CreateGenreRequest>
    {
        public CreateGenreValidator() 
        {
            ClassLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.Name)
                .NotNull()
                    .WithMessage("Name cannot be empty")
                .NotEmpty()
                    .WithMessage("Name cannot be empty")
                .MaximumLength(30)
                    .WithMessage("The Name length cannot be more than 256 characters");
        }
    }
}
