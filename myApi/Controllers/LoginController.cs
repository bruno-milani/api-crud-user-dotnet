using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using myApi.Domain.Dtos;
using myApi.Service;

namespace myApi.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUserService _userService;
        public LoginController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Authenticate([FromBody]UserDto userDto)
        {
            try
            {
                var user = _userService.Authenticate(userDto.Email);

                if (user == null)
                    return BadRequest(new { message = "Email está incorreto!" });

                var token = TokenService.GenerateToken(user);

                return Ok(new
                {
                    Id = user.Id,
                    Name = user.Name,
                    Email = user.Email,
                    DateOfBird = user.DateOfBird,
                    Sex = user.Sex,
                    Token = token
                });
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
