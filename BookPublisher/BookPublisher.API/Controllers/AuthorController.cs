using BookPublisher.Domain.Interfaces.Services;
using BookPublisher.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace BookPublisher.API.Controllers
{
    [Route("/authors")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [ProducesResponseType(typeof(IEnumerable<AuthorModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync([FromRoute] int id)
        {
            return Ok(await _authorService.GetAsync(id));
        }

        [ProducesResponseType(typeof(IEnumerable<AuthorModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public async Task<IActionResult> ListAsync()
        {
            return Ok(await _authorService.ListAsync());
        }

        [ProducesResponseType(typeof(AuthorModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] AuthorModel authorModel)
        {
            return Ok(await _authorService.InsertAsync(authorModel));
        }

        [ProducesResponseType(typeof(AuthorModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPut]
        public async Task<IActionResult> PutAsync([FromBody] AuthorModel authorModel)
        {
            return Ok(await _authorService.UpdateAsync(authorModel));
        }

        [ProducesResponseType(typeof(AuthorModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            return Ok(await _authorService.DeleteAsync(id));
        }
    }
}
