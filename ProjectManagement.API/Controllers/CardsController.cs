using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Application.Cards.Commands.CreateCard;

namespace ProjectManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CardsController(IMediator mediator)
        {
            _mediator = mediator;
        }


        protected IActionResult Index()
        {
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<string>> Create([FromBody] CreateCardCommand command)
        {
            string productId = await _mediator.Send(command);

            return Ok(productId);
        }
    }
}