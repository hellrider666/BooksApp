using BooksApp.Application.Abstract;
using BooksApp.Application.Interfaces.Repositories;
using BooksApp.Domain.Entities;
using MediatR;

namespace BooksApp.Application.Features.AuthorFeatures.Commands.CreateAuthor
{
    public class CreateAuthorHandler : BaseHandler, IRequestHandler<CreateAuthorRequest, CreateAuthorResponse>
    {
        public CreateAuthorHandler(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public async Task<CreateAuthorResponse> Handle(CreateAuthorRequest request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.DoWorkAsync<IAuthorRepository, AuthorEntity, CreateAuthorResponse>(async repository =>
            {
                var author = new AuthorEntity
                {
                    Guid = Guid.NewGuid(),
                    Name = request.Name,
                    Lastname = request.LastName,
                    Surname = !string.IsNullOrEmpty(request.Surname) ? request.Surname : null
                };

                repository.Create(author);

                await _unitOfWork.SaveCnahgesAsync(cancellationToken);

                return new CreateAuthorResponse { Guid = author.Guid };
            });
        }
    }
}
