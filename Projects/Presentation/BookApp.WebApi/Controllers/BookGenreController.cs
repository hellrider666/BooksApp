using BookApp.WebApi.Controllers.Base;
using BooksApp.Application.Features.BookGenresFeatures.Command.AddBookGenre;
using BooksApp.Application.Features.BookGenresFeatures.Command.DeleteBookGenre;
using BooksApp.Application.Interfaces.Managers;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BookApp.WebApi.Controllers
{
    public class BookGenreController : BaseApiController
    {
        public BookGenreController(IRequestManager requestManager) : base(requestManager) { }

        [HttpPost("AddBookGenre"), ProducesResponseType(typeof(AddBookGenreResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> AddBookGenre([FromBody] AddBookGenreRequest request)
        {
            return await Execute(request);
        }

        [HttpDelete("DeleteBookGenre"), ProducesResponseType(typeof(DeleteBookGenreResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteBookGenre([FromBody] DeleteBookGenreRequest request)
        {
            return await Execute(request);
        }
    }
}
