using MediatR;
using MultiShop.Order.Application.Features.Mediator.Queries.AddressQueries;
using MultiShop.Order.Application.Features.Mediator.Results.AddressResults;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.Mediator.Handlers.AddressHandlers
{
    public class GetAddressByIdQueryHandler : IRequestHandler<GetAddressByIdQuery, GetAddressByIdQueryResult>
    {
        private readonly IRepository<Address> _repository;

        public GetAddressByIdQueryHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }

        public async Task<GetAddressByIdQueryResult> Handle(GetAddressByIdQuery command, CancellationToken cancellationToken)
        {
            var result = await _repository.GetByIdAsync(command.Id);
            return new GetAddressByIdQueryResult
            {
                AddressId = result.AddressId,
                City = result.City,
                Detail = result.Detail,
                DistrictId = result.DistrictId,
                UserId = result.UserId
            };
        }
    }
}
