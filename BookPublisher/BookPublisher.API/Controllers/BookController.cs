using BookPublisher.Domain.Interfaces.Services;
using BookPublisher.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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

        // GET: api/<BookController>
        [ProducesResponseType(typeof(BookModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public async Task<IActionResult> ListAsyn()
        {
            return Ok(await _bookService.ListAsync());
        }

        // GET api/<BookController>/5
        [ProducesResponseType(typeof(BookModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<BookController>
        [ProducesResponseType(typeof(BookModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] BookModel bookModel)
        {
            return Ok(await _bookService.InsertAsync(bookModel));
        }

        // PUT api/<BookController>/5
        [ProducesResponseType(typeof(BookModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] BookModel bookModel)
        {
            return Ok(await _bookService.UpdateAsync(bookModel));
        }

        // DELETE api/<BookController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
