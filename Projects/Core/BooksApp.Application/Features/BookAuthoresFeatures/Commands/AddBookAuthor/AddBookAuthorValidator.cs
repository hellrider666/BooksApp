using BooksApp.Application.Interfaces.Repositories;
using BooksApp.Domain.Entities;
using FluentValidation;

namespace BooksApp.Application.Features.BookAuthoresFeatures.Commands.AddBookAuthor
{
    public class AddBookAuthorValidator : AbstractValidator<AddBookAuthorRequest>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AddBookAuthorValidator(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;

            ClassLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.BookGuid)
                .NotNull()
                    .WithMessage("Book guid cannot be empty")
                .MustAsync(async (guid, cancellation) =>
                {
                    var exist = await _unitOfWork.DoWorkAsync<IBookRepository, BookEntity, BookEntity>
                        (async repository => await repository.GetByGuidAsync(guid, cancellation));

                    return exist != null;
                }).WithMessage("The book does not exist");

            RuleFor(x => x.AuthorGuid)
                .NotNull()
                    .WithMessage("Author guid cannot be empty")
                .MustAsync(async (guid, cancellation) =>
                {
                    var exist = await _unitOfWork.DoWorkAsync<IAuthorRepository, AuthorEntity, AuthorEntity>
                        (async repository => await repository.GetByGuidAsync(guid, cancellation));

                    return exist != null;

                }).WithMessage("The Author does not exist");

            RuleFor(x => x)
                .MustAsync(async (request, cancellation) =>
                {
                    var books = await _unitOfWork.DoWorkAsync<IBookAuthorsRepository, BookAuthorsEntity, List<BookEntity>>
                        (async repository => await repository.GetBooksByAuthorAsync(request.AuthorGuid, cancellation));

                    return books.FirstOrDefault(x => x.Guid == request.BookGuid) == null;

                }).WithMessage("The author is already assigned to this book");
        }
    }
}
