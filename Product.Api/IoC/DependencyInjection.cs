using Microsoft.EntityFrameworkCore;
using ProductManager.Api.Application;
using ProductManager.Api.Domain.Interfaces;
using ProductManager.Api.Infra.Persistence;
using ProductManager.Api.Infra.Repositories;

namespace ProductManager.Api.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependencyServices(this IServiceCollection services)
        {
            services.AddScoped<ProductService>();

            return services;
        }

        public static IServiceCollection AddDependencyRepositories(this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseInMemoryDatabase("ProductsDb"));

            services.AddScoped<IProductRepository, ProductMemoryRepository>();

            return services;
        }
    }
}
