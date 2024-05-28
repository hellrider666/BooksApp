using MediatR;

namespace BooksApp.Application.Interfaces.Requests
{
    public interface IAppRequest<T> : IRequest<T>
    {
    }
}
