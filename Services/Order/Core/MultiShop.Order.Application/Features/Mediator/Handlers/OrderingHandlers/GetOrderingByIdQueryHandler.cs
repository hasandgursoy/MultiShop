using MediatR;
using MultiShop.Order.Application.Features.Mediator.Queries.OrderingQueries;
using MultiShop.Order.Application.Features.Mediator.Results.OrderingResults;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.Mediator.Handlers.OrderingHandlers
{
    public class GetOrderingByIdQueryHandler : IRequestHandler<GetOrderingByIdQuery, GetOrderingByIdQueryResult>
    {
        private readonly IRepository<Ordering> _repository;

        public GetOrderingByIdQueryHandler(IRepository<Ordering> repository)
        {
            _repository = repository;
        }

        public async Task<GetOrderingByIdQueryResult> Handle(GetOrderingByIdQuery command, CancellationToken cancellationToken)
        {
            var result = await _repository.GetByIdAsync(command.Id);
            return new GetOrderingByIdQueryResult
            {
                OrderingId = result.OrderingId,
                UserId = result.UserId,
                OrderDate = result.OrderDate,
                TotalPrice = result.TotalPrice
            };
        }
    }
}
