using BookPublisher.Domain.Interfaces.Services;
using BookPublisher.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace BookPublisher.API.Controllers
{
    [Route("/books")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [ProducesResponseType(typeof(BookModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public async Task<IActionResult> ListAsync()
        {
            return Ok(await _bookService.ListAsync());
        }

        [ProducesResponseType(typeof(BookModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync([FromRoute] int id)
        {
            return Ok(await _bookService.GetAsync(id));
        }

        [ProducesResponseType(typeof(BookModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] BookModel bookModel)
        {
            return Ok(await _bookService.InsertAsync(bookModel));
        }

        [ProducesResponseType(typeof(BookModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPut]
        public async Task<IActionResult> PutAsync([FromBody] BookModel bookModel)
        {
            return Ok(await _bookService.UpdateAsync(bookModel));
        }

        [ProducesResponseType(typeof(BookModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            return Ok(await _bookService.DeleteAsync(id));
        }
    }
}
