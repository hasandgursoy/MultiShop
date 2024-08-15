using MediatR;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Order.Application.Features.Mediator.Commands.OrderDetailCommands;
using MultiShop.Order.Application.Features.Mediator.Queries.OrderDetailQueries;

namespace MultiShop.Order.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderDetailController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> OrderDetailListAsync()
        {
            var result = await _mediator.Send(new GetOrderDetailQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderDetailByIdAsync(int id)
        {
            var result = await _mediator.Send(new GetOrderDetailByIdQuery(id));
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrderDetail(CreateOrderDetailCommand command)
        {
            await _mediator.Send(command);
            return Ok("OrderDetail created !");
        }

        [HttpDelete]

        public async Task<IActionResult> RemoveOrderDetailAsync(int id)
        {
            await _mediator.Send(new RemoveOrderDetailCommand(id));
            return Ok("OrderDetail deleted !");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrderDetailAsync(UpdateOrderDetailCommand command)
        {
            await _mediator.Send(command);
            return Ok("OrderDetail updated !");
        }
    }
}
