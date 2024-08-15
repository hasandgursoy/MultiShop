using MediatR;
using MultiShop.Order.Application.Features.Mediator.Commands.AddressCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.Mediator.Handlers.AddressHandlers
{
    public class UpdateAdressCommandHandler : IRequestHandler<UpdateAddressCommand>
    {
        private readonly IRepository<Address> _repository;

        public UpdateAdressCommandHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateAddressCommand command, CancellationToken cancellationToken)
        {
            var address = await _repository.GetByIdAsync(command.AddressId);
            address.Detail = command.Detail;
            address.DistrictId = command.DistrictId;
            address.UserId = command.UserId;
            address.City = command.City;
            await _repository.UpdateAsync(address);
        }
    }
}
