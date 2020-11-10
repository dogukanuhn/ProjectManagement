using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpPost("/Register")]
        public async Task<IActionResult> Register([FromBody]CreateUserCommand command)
        {
            var user = await _mediator.Send(command);

            if (!user)
                return BadRequest("error");

            return Ok("Success");

        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Authenticate([FromBody]AuthenticateUserQuery query)
        {
            var user = await _mediator.Send(query);

            if (user == null)
                return BadRequest("Username or password incorrect!");

            return Ok(new { Email = user.Value.email, Token = user.Value.token });

        }
    }
}