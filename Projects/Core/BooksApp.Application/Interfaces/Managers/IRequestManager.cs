using BooksApp.Application.Interfaces.Requests;

namespace BooksApp.Application.Interfaces.Managers
{
    public interface IRequestManager
    {
        Task<TResponse> SendAsync<TResponse>(IAppRequest<TResponse> request);
    }
}
