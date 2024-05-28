using BooksApp.Application.Interfaces.Managers;
using BooksApp.Application.Interfaces.Requests;
using MediatR;

namespace BooksApp.Application.Managers
{
    public class RequestManager : IRequestManager
    {
        private readonly IMediator _mediator;
        public RequestManager(IMediator mediator)
        {
            _mediator = mediator;
        }
        public Task<TResponse> SendAsync<TResponse>(IAppRequest<TResponse> request)
        {
            return _mediator.Send(request);
        }
    }
}
