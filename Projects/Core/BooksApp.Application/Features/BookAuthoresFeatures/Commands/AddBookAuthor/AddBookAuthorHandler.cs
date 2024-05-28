using BooksApp.Application.Abstract;
using BooksApp.Application.Interfaces.Repositories;
using BooksApp.Domain.Entities;
using MediatR;

namespace BooksApp.Application.Features.BookAuthoresFeatures.Commands.AddBookAuthor
{
    public class AddBookAuthorHandler : BaseHandler, IRequestHandler<AddBookAuthorRequest, AddBookAuthorResponse>
    {
        public AddBookAuthorHandler(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public async Task<AddBookAuthorResponse> Handle(AddBookAuthorRequest request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.DoWorkAsync<IBookAuthorsRepository, BookAuthorsEntity, AddBookAuthorResponse>(async repository =>
            {
                var book = await _unitOfWork.DoWorkAsync<IBookRepository, BookEntity, BookEntity>(async repository => await repository.GetByGuidAsync(request.BookGuid, cancellationToken));

                var author = await _unitOfWork.DoWorkAsync<IAuthorRepository, AuthorEntity, AuthorEntity>(async repository => await repository.GetByGuidAsync(request.AuthorGuid, cancellationToken));

                var bookAuthorEntity = new BookAuthorsEntity
                {
                    Book = book,
                    Author = author,
                };

                repository.Create(bookAuthorEntity);

                await _unitOfWork.SaveCnahgesAsync(cancellationToken);

                return new AddBookAuthorResponse { AuthorGuid = author.Guid, BookGuid = book.Guid };
            });
        }
    }
}
