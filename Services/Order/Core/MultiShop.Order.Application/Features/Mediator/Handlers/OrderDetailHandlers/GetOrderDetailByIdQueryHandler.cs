using MediatR;
using MultiShop.Order.Application.Features.Mediator.Queries.OrderDetailQueries;
using MultiShop.Order.Application.Features.Mediator.Results.OrderDetailResults;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.Mediator.Handlers.OrderDetailHandlers
{
    public class GetOrderDetailByIdQueryHandler : IRequestHandler<GetOrderDetailByIdQuery, GetOrderDetailByIdQueryResult>
    {
        private readonly IRepository<OrderDetail> _repository;

        public GetOrderDetailByIdQueryHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task<GetOrderDetailByIdQueryResult> Handle(GetOrderDetailByIdQuery command, CancellationToken cancellationToken)
        {
            var result = await _repository.GetByIdAsync(command.Id);
            return new GetOrderDetailByIdQueryResult
            {
                OrderDetailId = result.OrderDetailId,
                ProductId = result.ProductId,
                ProductAmount = result.ProductAmount,
                ProductName = result.ProductName,
                ProductPrice = result.ProductPrice,
                ProductTotalPrice = result.ProductTotalPrice
            };
        }
    }
}
