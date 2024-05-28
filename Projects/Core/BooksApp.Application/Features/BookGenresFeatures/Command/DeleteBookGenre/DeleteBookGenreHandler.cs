using BooksApp.Application.Abstract;
using BooksApp.Application.Interfaces.Repositories;
using BooksApp.Domain.Entities;
using MediatR;

namespace BooksApp.Application.Features.BookGenresFeatures.Command.DeleteBookGenre
{
    public class DeleteBookGenreHandler : BaseHandler, IRequestHandler<DeleteBookGenreRequest, DeleteBookGenreResponse>
    {
        public DeleteBookGenreHandler(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public async Task<DeleteBookGenreResponse> Handle(DeleteBookGenreRequest request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.DoWorkAsync<IBookGenresRepository, BookGenresEntity, DeleteBookGenreResponse>(async repository =>
            {
                var bookGenre = await repository.GetByBookAndGenreAsync(request.BookGuid, request.GenreGuid, cancellationToken);

                repository.Delete(bookGenre);

                await _unitOfWork.SaveCnahgesAsync(cancellationToken);

                return new DeleteBookGenreResponse();
            });
        }
    }
}
