using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjectManagement.Application.Users.Commands.CreateUser;
using ProjectManagement.Application.Users.Queries;

namespace ProjectManagement.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<UserController> _logger;

        public UserController(IMediator mediator,ILogger<UserController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [AllowAnonymous]
        [HttpPost("/Register")]
        public async Task<IActionResult> Register([FromBody]CreateUserCommand command)
        {
            try
            {
                var user = await _mediator.Send(command);

                if (!user)
                    return BadRequest("Some informations are missing or wrong");

                return Ok("User Created Succesfully");
            }
            catch (Exception exception)
            {

                    return BadRequest($"User Register Error : {exception.Message}");

            }

        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Authenticate([FromBody]AuthenticateUserQuery query)
        {
        

            try
            {
                var user = await _mediator.Send(query);
                if (user == null)
                    return BadRequest("Username or password incorrect!");

                return Ok(new { Email = user.Value.email, Token = user.Value.token });

            }
            catch (Exception exception)
            {

                return BadRequest($"User Login Error : {exception.Message}");

            }

        }
    }
}