using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<CardsController> _logger;

        public CardsController(IMediator mediator,ILogger<CardsController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                var list = await _mediator.Send(new GetCardListQuery());
                _logger.LogInformation($"Card Get Succesfully");

                return Ok(list);
            }
            catch (Exception exception)
            {
                _logger.LogError($"Get Cards Error:{exception.Message}");
                return BadRequest(exception.Message);
            }


            
        }
            
        [HttpPost]
        public async Task<ActionResult<string>> Create([FromBody] CreateCardCommand command)
        {

            try
            {
                string productId = await _mediator.Send(command);
                _logger.LogInformation($"Card Created Succesfully");
                return Ok(productId);

            }
            catch (Exception exception)
            {
                _logger.LogError($"Create Card Error:{exception.Message}");
                return BadRequest(exception.Message);
            }

        }
    }
}