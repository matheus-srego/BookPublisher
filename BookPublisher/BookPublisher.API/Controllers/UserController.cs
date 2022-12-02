using BookPublisher.Domain.DTOs.User;
using BookPublisher.Domain.Interfaces.Factories;
using BookPublisher.Domain.Interfaces.Services;
using BookPublisher.Domain.Models;
using BookPublisher.Service.Validations;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace BookPublisher.API.Controllers
{
    [Route("api/users")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IUserFactory _userFactory;

        public UserController(IUserService userService, IUserFactory userFactory)
        {
            _userService = userService;
            _userFactory = userFactory;
        }

        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync([FromRoute] int id)
        {
            return Ok(await _userService.GetAsync(id));
        }

        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public async Task<IActionResult> ListAsync()
        {
            return Ok(await _userService.ListAsync());
        }

        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] NewUserDTO newUser)
        {
            return Ok(await _userService.InsertAsync<UserValidator>(_userFactory.Create(newUser)));
        }

        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPut]
        public async Task<IActionResult> PutAsync([FromBody] User userUpdate)
        {
            return Ok(await _userService.UpdateAsync<UserValidator>(userUpdate));
        }

        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            return Ok(await _userService.DeleteAsync(id));
        }
    }
}
