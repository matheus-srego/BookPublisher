using BookPublisher.Domain.DTOs;
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
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync([FromRoute] int id)
        {
            return Ok(await _authorService.GetAuthorWithBooksAsync(id));
        }

        [ProducesResponseType(typeof(IEnumerable<AuthorModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public async Task<IActionResult> ListAsync()
        {
            return Ok(await _authorService.ListAuthorsWithBookAsync());
        }

        [ProducesResponseType(typeof(NewAuthorDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] NewAuthorDTO dto)
        {
            return Ok(await _authorService.InsertAsync(AuthorModel.Create(dto)));
        }

        [ProducesResponseType(typeof(UpdateAuthorDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPut]
        public async Task<IActionResult> PutAsync([FromBody] UpdateAuthorDTO dto)
        {
            var author = await _authorService.GetAsync(dto.Id);

            if(author == null)
            {
                throw new ArgumentException("Autor não encontrado!");
            }

            var authorUpdated = author.Update(dto);

            return Ok(await _authorService.UpdateAsync(authorUpdated));
        }

        [ProducesResponseType(typeof(AuthorModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            return Ok(await _authorService.DeleteAsync(id));
        }
    }
}
