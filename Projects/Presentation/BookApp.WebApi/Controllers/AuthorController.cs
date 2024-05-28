using BookApp.WebApi.Controllers.Base;
using BooksApp.Application.Features.AuthorFeatures.Commands.CreateAuthor;
using BooksApp.Application.Features.AuthorFeatures.Commands.DeleteAuthor;
using BooksApp.Application.Interfaces.Managers;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BookApp.WebApi.Controllers
{
    public class AuthorController : BaseApiController
    {
        public AuthorController(IRequestManager requestManager) : base(requestManager) { }

        [HttpPost("CreateAuthor"), ProducesResponseType(typeof(CreateAuthorResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateAuthor([FromBody] CreateAuthorRequest request)
        {
            return await Execute(request);
        }

        [HttpDelete("DeleteAuthor"), ProducesResponseType(typeof(DeleteAuthorResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteAuthor([FromBody] DeleteAuthorRequest request)
        {
            return await Execute(request);
        }
    }
}
