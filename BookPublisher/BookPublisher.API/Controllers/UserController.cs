using BookPublisher.Domain.Interfaces.Services;
using BookPublisher.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace BookPublisher.API.Controllers
{
    [Route("/user")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] UserModel model)
        {
            return Ok(await _userService.InsertAsync(model));
        }
    }
}
