using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Options;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using myApi.Service;
using myApi.Domain.Dtos;
using myApi.Domain.Entities;
using System.Threading.Tasks;
using myApi.Data.Context;
using System.Net;
using myApi.Domain.Interface;
using Microsoft.Extensions.Logging;

namespace myApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UsersController> _logger;
        private IMapper _mapper;
        public UsersController(IUserService userService, IMapper mapper, ILogger<UsersController> logger)
        {
            _userService = userService;
            _mapper = mapper;
            _logger = logger;
        }

        [Authorize("Bearer")]
        [HttpPost("register")]
        public IActionResult Register([FromBody]User user)
        {
            try
            {
                _logger.LogInformation("Executando api/users/register");

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var resultUser = _userService.Create(user);
                return Ok(resultUser);
            }
            catch (ArgumentException)
            {
                _logger.LogError("Error");
                return StatusCode((int)HttpStatusCode.InternalServerError, "Internal Server Error");
            }
        }

        [Authorize("Bearer")]
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                _logger.LogInformation("Executando api/users - GetAll");

                var users = _userService.GetAll();

                return Ok(users);
            }
            catch (ArgumentException)
            {
                _logger.LogError("Error");
                return StatusCode((int)HttpStatusCode.InternalServerError, "Internal Server Error");
            }
        }

        [Authorize("Bearer")]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                _logger.LogInformation($"Executando api/users/ -> GET id:{id}");

                var user = _userService.GetById(id);

                return Ok(user);
            }
            catch (ArgumentException)
            {
                _logger.LogError("Error");
                return StatusCode((int)HttpStatusCode.InternalServerError, "Internal Server Error");
            }
        }

        [Authorize("Bearer")]
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]User userDto)
        {
            try
            {
                _logger.LogInformation($"Executando api/users/ -> Put id:{id}");
                var user = _mapper.Map<User>(userDto);
                user.Id = id;

                _userService.Update(user);
                return Ok("Usuário Atualizado com Sucesso!!!");
            }
            catch (ArgumentException)
            {
                _logger.LogError("Error");
                return StatusCode((int)HttpStatusCode.InternalServerError, "Internal Server Error");
            }
        }

        [Authorize("Bearer")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _logger.LogInformation($"Executando api/users/ -> Delete id:{id}");

                _userService.Delete(id);
                return Ok("Usuário Excluido com Sucesso!!!");
            }
            catch (ArgumentException)
            {
                _logger.LogError("Error");
                return StatusCode((int)HttpStatusCode.InternalServerError, "Internal Server Error");
            }
        }
    }
}
