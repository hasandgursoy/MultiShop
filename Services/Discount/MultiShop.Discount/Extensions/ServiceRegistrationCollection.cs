using Microsoft.Extensions.Options;
using MultiShop.Discount.Context;
using MultiShop.Discount.Services;

namespace MultiShop.Discount.Extensions
{
    public static class ServiceRegistrationCollection
    {
        public static void AddCatalogService(this IServiceCollection services)
        {
            services.AddSingleton<DapperContext>();
            services.AddScoped<IDiscountService, DiscountService>();
        }
    }
}
