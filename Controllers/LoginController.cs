using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using myApi.Domain.Dtos;
using myApi.Domain.Interface;
using myApi.Service;

namespace myApi.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<LoginController> _logger;
        public LoginController(IUserService userService, ILogger<LoginController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Authenticate([FromBody]UserDto userDto)
        {
            try
            {
                _logger.LogInformation("Executando api/login");

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
            catch (ArgumentException)
            {
                _logger.LogError("Error");
                return StatusCode((int)HttpStatusCode.InternalServerError, "Internal Server Error");
            }
        }
    }
}
