using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Application.Cards.Commands.CreateCard;
using ProjectManagement.Application.Cards.Queries.GetAllCards;

namespace ProjectManagement.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CardsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CardsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var list = await _mediator.Send(new GetCardListQuery());
            return Ok(list);
        }
            
        [HttpPost]
        public async Task<ActionResult<string>> Create([FromBody] CreateCardCommand command)
        {

            string productId = await _mediator.Send(command);
            return Ok(productId);

        }
    }
}