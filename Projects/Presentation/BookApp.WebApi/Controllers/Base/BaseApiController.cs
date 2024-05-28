using BookApp.WebApi.Classes.Validation;
using BooksApp.Application.Interfaces.Managers;
using BooksApp.Application.Interfaces.Requests;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BookApp.WebApi.Controllers.Base
{
    [Route("api/[controller]/")]
    [ApiController]
    [ProducesErrorResponseType(typeof(ValidationResponse))]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.ServiceUnavailable)]
    public abstract class BaseApiController : ControllerBase
    {
        private readonly IRequestManager _requestManager;

        public BaseApiController(IRequestManager requestManager)
        {
            _requestManager = requestManager;
        }

        protected async Task<IActionResult> Execute<TResponse>(IAppRequest<TResponse> request)
        {
            var response = await _requestManager.SendAsync(request);

            return Ok(response);
        }
    }
}
