using BooksApp.Application.Interfaces.Repositories;
using BooksApp.Domain.Entities;
using FluentValidation;

namespace BooksApp.Application.Features.BookAuthoresFeatures.Commands.DeleteBookAuthor
{
    public class DeleteBookAuthorValidator : AbstractValidator<DeleteBookAuthorRequest>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteBookAuthorValidator(IUnitOfWork unitOfWork)
        {
            ClassLevelCascadeMode = CascadeMode.Stop;

            _unitOfWork = unitOfWork;

            RuleFor(x => x.BookGuid)
                .NotNull()
                    .WithMessage("Book guid cannot be empty")
                .MustAsync(async (guid, cancellation) =>
                {
                    var exist = await _unitOfWork.DoWorkAsync<IBookRepository, BookEntity, BookEntity>
                        (async x => await x.GetByGuidAsync(guid, cancellation));

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
                     var books = await _unitOfWork.DoWorkAsync<IBookAuthorsRepository, BookAuthorsEntity, BookAuthorsEntity>
                        (async repository => await repository.GetByBookAndAuthorAsync(request.BookGuid, request.AuthorGuid, cancellation));

                     return books != null;

                 }).WithMessage("This book is not assigned to the author");
        }
    }
}
