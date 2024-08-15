using MediatR;
using MultiShop.Order.Application.Features.Mediator.Commands.OrderingCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.Mediator.Handlers.OrderingHandlers
{
    public class UpdateOrderingCommandHandler : IRequestHandler<UpdateOrderingCommand>
    {
        private readonly IRepository<Ordering> _repository;

        public UpdateOrderingCommandHandler(IRepository<Ordering> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateOrderingCommand command, CancellationToken cancellationToken)
        {
            var result = await _repository.GetByIdAsync(command.OrderId);
            result.OrderDate = command.OrderDate;
            result.UserId = command.UserId;
            result.TotalPrice = command.TotalPrice;
            await _repository.UpdateAsync(result);
        }
    }
}
