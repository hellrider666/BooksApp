using BooksApp.Application.Interfaces.Repositories;
using BooksApp.Domain.Entities;
using FluentValidation;

namespace BooksApp.Application.Features.BookFeatures.Commands.DeleteBook
{
    public class DeleteBookValidator : AbstractValidator<DeleteBookRequest>
    {
        private readonly IUnitOfWork _unitOfWork;
        
        public DeleteBookValidator(IUnitOfWork unitOfWork)
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
        }
    }
}
