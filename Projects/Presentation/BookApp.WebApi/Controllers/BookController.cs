using BookApp.WebApi.Controllers.Base;
using BooksApp.Application.Features.BookFeatures.Commands.CreateBook;
using BooksApp.Application.Features.BookFeatures.Commands.DeleteBook;
using BooksApp.Application.Features.BookFeatures.Commands.UpdateBook;
using BooksApp.Application.Features.BookFeatures.Queries.GetBooks;
using BooksApp.Application.Interfaces.Managers;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BookApp.WebApi.Controllers
{
    public class BookController : BaseApiController
    {
        public BookController(IRequestManager requestManager) : base(requestManager) { }

        [HttpPost("CreateBook"), ProducesResponseType(typeof(CreateBookResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateBook([FromBody] CreateBookRequest request)
        {
            return await Execute(request);
        }

        [HttpDelete("DeleteBook"), ProducesResponseType(typeof(DeleteBookResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteBook([FromBody] DeleteBookRequest request)
        {
            return await Execute(request);
        }

        [HttpPut("UpdateBook"), ProducesResponseType(typeof(UpdateBookResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateBook([FromBody] UpdateBookRequest request)
        {
            return await Execute(request);
        }

        [HttpGet("GetBooks"), ProducesResponseType(typeof(GetBooksResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetBooks([FromQuery] GetBooksRequest request)
        {
            return await Execute(request);
        }
    }
}
