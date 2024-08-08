using Microsoft.Extensions.Options;
using MultiShop.Catalog.Services.CategoryServices;
using MultiShop.Catalog.Services.ProductDetailServices;
using MultiShop.Catalog.Services.ProductImageImageServices;
using MultiShop.Catalog.Services.ProductImageServices;
using MultiShop.Catalog.Services.ProductServices;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Extensions
{
    public static class ServiceRegistrationCollection
    {
        public static void AddCatalogService(this IServiceCollection services)
        {
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductDetailService, ProductDetailService>();
            services.AddScoped<IProductImageService, ProductImageService>();
            services.AddScoped<IDatabaseSettings>(sp =>
            {
                return sp.GetRequiredService<IOptions<DatabaseSettings>>().Value;
            });
        }
    }
}
