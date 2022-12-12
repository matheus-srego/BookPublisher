using BookPublisher.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookPublisher.API.Controllers
{
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        /*
        [HttpPost]
        [AllowAnonymous]
        [Route("/auth")]
        public async Task<IActionResult> Login([FromBody] LoginDTO dto)
        {
            try
            {
                var userExists = _userService.GetOneByCriteria(x => (x.Email == dto.Email) && (x.Password == dto.Password));

                if (userExists == null)
                    return BadRequest(new { Message = "Email e/ou senha está(ão) inválido(s)." });

                if (userExists.Password != dto.Password)
                    return BadRequest(new { Message = "Email e/ou senha está(ão) inválido(s)." });

                var token = AuthService.GenerateToken(dto);
                return Ok(new
                {
                    Token = token,
                    User = dto
                });
            }
            catch(Exception)
            {
                return BadRequest(new { Message = "Ocorreu um erro interno na aplicação, por favor tente novamente." });
            }
        }
        */
    }
}
