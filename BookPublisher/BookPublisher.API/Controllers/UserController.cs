using BookPublisher.Domain.DTOs.User;
using BookPublisher.Domain.Interfaces.Factories;
using BookPublisher.Domain.Interfaces.Services;
using BookPublisher.Domain.Models;
using BookPublisher.Service.Validators;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using BookPublisher.Domain.Constants;

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
        [HttpGet]
        public async Task<IActionResult> ListAsync()
        {
            return Ok(await _userService.ListAsync());
        }

        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync([FromRoute] Guid id)
        {
            return Ok(await _userService.GetAsync(id));
        }

        [ProducesResponseType(typeof(UserResponseDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] UserRequestDTO user)
        {
            var userConverted = _userFactory.Create(user);
            await _userService.InsertAsync<UserValidator>(userConverted);
            return Ok(MESSAGES.SUCCESSFUL_REGISTERED_USER);
        }

        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync([FromRoute] Guid id, [FromBody] UserRequestDTO user)
        {
            return Ok(_userFactory.ConvertModelToDTO(await _userService.UpdateAsync<UserValidator>(_userFactory.Update(id, user))));
        }

        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
        {
            return Ok(new 
            {
                User = _userFactory.ConvertModelToDTO(await _userService.DeleteAsync(id)),
                Message = MESSAGES.SUCCESSFUL_DELETED_USER
            });
        }
    }
}
