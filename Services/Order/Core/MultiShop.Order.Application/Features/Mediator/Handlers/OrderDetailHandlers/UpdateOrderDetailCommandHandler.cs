using MediatR;
using MultiShop.Order.Application.Features.Mediator.Commands.OrderDetailCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.Mediator.Handlers.OrderDetailHandlers
{
    public class UpdateOrderDetailCommandHandler : IRequestHandler<UpdateOrderDetailCommand>
    {
        private readonly IRepository<OrderDetail> _repository;

        public UpdateOrderDetailCommandHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateOrderDetailCommand command, CancellationToken cancellationToken)
        {
            var result = await _repository.GetByIdAsync(command.OrderDetailId);
            result.OrderingId = command.OrderingId;
            result.ProductId = command.ProductId;
            result.ProductName = command.ProductName;
            result.ProductAmount = command.ProductAmount;
            result.ProductPrice = command.ProductPrice;
            result.ProductTotalPrice = command.ProductTotalPrice;
            await _repository.UpdateAsync(result);
        }
    }
}
