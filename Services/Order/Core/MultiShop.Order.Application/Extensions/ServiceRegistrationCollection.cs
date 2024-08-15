using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MultiShop.Order.Application.Features.Mediator.Handlers.AddressHandlers;
using MultiShop.Order.Application.Features.Mediator.Handlers.OrderDetailHandlers;
using MultiShop.Order.Application.Features.Mediator.Results.AddressResults;

namespace MultiShop.Order.WebApi.Extensions
{
    public static class ServiceRegistrationCollection
    {
        public static void AddCatalogService(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddScoped<GetAddressByIdQueryHandler>();
            services.AddScoped<GetAddressByIdQueryResult>();
            services.AddScoped<CreateAddressCommandHandler>();
            services.AddScoped<UpdateAdressCommandHandler>();
            services.AddScoped<RemoveAddressCommandHandler>();

            services.AddScoped<GetOrderDetailByIdQueryHandler>();
            services.AddScoped<GetOrderDetailQueryHandler>();
            services.AddScoped<UpdateOrderDetailCommandHandler>();
            services.AddScoped<CreateOrderDetailCommandHandler>();
            services.AddScoped<RemoveOrderDetailCommandHandler>();

            services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(ServiceRegistrationCollection).Assembly));
        }
    }
}
