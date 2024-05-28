using BooksApp.Application.Abstract;
using BooksApp.Application.Interfaces.Repositories;
using BooksApp.Domain.Entities;
using MediatR;

namespace BooksApp.Application.Features.BookGenresFeatures.Command.AddBookGenre
{
    public class AddBookGenreHandler : BaseHandler, IRequestHandler<AddBookGenreRequest, AddBookGenreResponse>
    {
        public AddBookGenreHandler(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public async Task<AddBookGenreResponse> Handle(AddBookGenreRequest request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.DoWorkAsync<IBookGenresRepository, BookGenresEntity, AddBookGenreResponse>(async repository =>
            {
                var book = await _unitOfWork.DoWorkAsync<IBookRepository, BookEntity, BookEntity>
                    (async repository => await repository.GetByGuidAsync(request.BookGuid, cancellationToken));

                var genre = await _unitOfWork.DoWorkAsync<IGenreRepository, GenreEntity, GenreEntity>
                    (async repository => await repository.GetByGuidAsync(request.GenreGuid, cancellationToken));

                var bookGenre = new BookGenresEntity
                {
                    Book = book,
                    Genre = genre,
                };

                repository.Create(bookGenre);

                await _unitOfWork.SaveCnahgesAsync(cancellationToken);

                return new AddBookGenreResponse { BookGuid = book.Guid, GenreGuid = genre.Guid };
            });
        }
    }
}
