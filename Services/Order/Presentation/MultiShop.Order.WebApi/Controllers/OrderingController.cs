using MediatR;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Order.Application.Features.Mediator.Commands.OrderingCommands;
using MultiShop.Order.Application.Features.Mediator.Queries.OrderingQueries;

namespace MultiShop.Order.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderingController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> OrderingListAsync()
        {
            var result = await _mediator.Send(new GetOrderingQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderingByIdAsync(int id)
        {
            var result = await _mediator.Send(new GetOrderingByIdQuery(id));
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrdering(CreateOrderingCommand command)
        {
            await _mediator.Send(command);
            return Ok("Ordering created !");
        }

        [HttpDelete]

        public async Task<IActionResult> RemoveOrderingAsync(int id)
        {
            await _mediator.Send(new RemoveOrderingCommand(id));
            return Ok("Ordering deleted !");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrderingAsync(UpdateOrderingCommand command)
        {
            await _mediator.Send(command);
            return Ok("Ordering updated !");
        }
    }
}
