using BooksApp.Application.Interfaces.Repositories;
using BooksApp.Domain.Entities;
using FluentValidation;

namespace BooksApp.Application.Features.BookGenresFeatures.Command.DeleteBookGenre
{
    public class DeleteBookGenreValidator : AbstractValidator<DeleteBookGenreRequest>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteBookGenreValidator(IUnitOfWork unitOfWork)
        {
            ClassLevelCascadeMode = CascadeMode.Stop;

            _unitOfWork = unitOfWork;

            RuleFor(x => x.BookGuid)
                .NotNull()
                    .WithMessage("Book guid cannot be null")
                .MustAsync(async (guid, cancellation) =>
                {
                    var exist = await _unitOfWork.DoWorkAsync<IBookRepository, BookEntity, BookEntity>
                        (async repository => await repository.GetByGuidAsync(guid, cancellation));

                    return exist != null;
                }).WithMessage("The book doesn't exist");

            RuleFor(x => x.GenreGuid)
                .NotNull()
                    .WithMessage("Genre guid cannot be null")
                .MustAsync(async (guid, cancellation) =>
                {
                    var exist = await _unitOfWork.DoWorkAsync<IGenreRepository, GenreEntity, GenreEntity>
                        (async repository => await repository.GetByGuidAsync(guid, cancellation));

                    return exist != null;
                }).WithMessage("The genre doesn't exist");

            RuleFor(x => x)
                .MustAsync(async (request, cancellation) =>
                {
                    var exist = await _unitOfWork.DoWorkAsync<IBookGenresRepository, BookGenresEntity, BookGenresEntity>
                        (async repository => await repository.GetByBookAndGenreAsync(request.BookGuid, request.GenreGuid, cancellation));

                    return exist != null;
                }).WithMessage("The genre is not assigned to the book");
        }
    }
}
