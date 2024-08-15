using MediatR;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Order.Application.Features.Mediator.Commands.AddressCommands;
using MultiShop.Order.Application.Features.Mediator.Queries.AddressQueries;

namespace MultiShop.Order.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AddressController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> AddressListAsync()
        {
            var result = await _mediator.Send(new GetAddressQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAddressByIdAsync(int id)
        {
            var result = await _mediator.Send(new GetAddressByIdQuery(id));
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAddress(CreateAddressCommand command)
        {
            await _mediator.Send(command);
            return Ok("Address created !");
        }

        [HttpDelete]

        public async Task<IActionResult> RemoveAddressAsync(int id)
        {
            await _mediator.Send(new RemoveAddressCommand(id));
            return Ok("Address deleted !");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAddressAsync(UpdateAddressCommand command)
        {
            await _mediator.Send(command);
            return Ok("Address updated !");
        }

    }
}
