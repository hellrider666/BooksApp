using BookApp.WebApi.Controllers.Base;
using BooksApp.Application.Features.GenreFeatures.Commands.CreateGenre;
using BooksApp.Application.Features.GenreFeatures.Commands.DeleteGenre;
using BooksApp.Application.Interfaces.Managers;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BookApp.WebApi.Controllers
{
    public class GenreController : BaseApiController
    {
        public GenreController(IRequestManager requestManager) : base(requestManager) { }

        [HttpPost("CreateGenre"), ProducesResponseType(typeof(CreateGenreResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateGenre([FromBody] CreateGenreRequest request)
        {
            return await Execute(request);
        }

        [HttpDelete("DeleteGenre"), ProducesResponseType(typeof(DeleteGenreResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteGenre([FromBody] DeleteGenreRequest request)
        {
            return await Execute(request);
        }
    }
}
