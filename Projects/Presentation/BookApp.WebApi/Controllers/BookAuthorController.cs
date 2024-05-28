using BookApp.WebApi.Controllers.Base;
using BooksApp.Application.Features.BookAuthoresFeatures.Commands.AddBookAuthor;
using BooksApp.Application.Features.BookAuthoresFeatures.Commands.DeleteBookAuthor;
using BooksApp.Application.Interfaces.Managers;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BookApp.WebApi.Controllers
{
    public class BookAuthorController : BaseApiController
    {
        public BookAuthorController(IRequestManager requestManager) : base(requestManager) { }

        [HttpPost("AddBookAuthor"), ProducesResponseType(typeof(AddBookAuthorResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> AddBookAuthor([FromBody] AddBookAuthorRequest request)
        {
            return await Execute(request);
        }

        [HttpDelete("DeleteBookAuthor"), ProducesResponseType(typeof(DeleteBookAuthorResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteBookAuthor([FromBody] DeleteBookAuthorRequest request)
        {
            return await Execute(request);
        }
    }
}
