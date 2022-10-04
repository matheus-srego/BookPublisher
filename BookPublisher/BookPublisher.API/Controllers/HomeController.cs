using Microsoft.AspNetCore.Mvc;

namespace BookPublisher.API.Controllers
{
    [ApiController]
    [Route("Test")]
    public class HomeController : ControllerBase
    {
        private static readonly string phrase = "Testando Docker!";

        [HttpGet(Name = "Docker")]
        public IActionResult Get()
        {
            return Ok(phrase);
        }
    }
}
