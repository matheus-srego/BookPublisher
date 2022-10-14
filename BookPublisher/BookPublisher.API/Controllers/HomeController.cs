using BookPublisher.Domain.Interfaces.Repositories;
using BookPublisher.Persistence.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace BookPublisher.API.Controllers
{
    [ApiController]
    [Route("Test")]
    public class HomeController : ControllerBase
    {
        private static readonly string phrase = "Testando Docker!";
        public IAuthorRepository AuthorRepository;

        public HomeController(IAuthorRepository authorRepository)
        {
            AuthorRepository = authorRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var canConnect = AuthorRepository.getContext().Database.CanConnect();
            return Ok(new { ConnectionState = canConnect });
        }
    }
}
