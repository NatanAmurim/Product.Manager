using ProductManager.Api.Presentation.Extensions;
using System.Threading.RateLimiting;

namespace ProductManager.Api.Presentation.Extensions
{
    public static class SecurityServicesExtensions
    {
        public static IServiceCollection AddRateLimiter(this IServiceCollection services)
        {
            // Habilita o rate limiter
            services.AddRateLimiter(options =>
            {                
                options.AddPolicy("DefaultPolicy", context =>
                    RateLimitPartition.GetFixedWindowLimiter(
                        partitionKey: context.Connection.RemoteIpAddress?.ToString() ?? "anonymous",
                        factory: _ => new FixedWindowRateLimiterOptions
                        {
                            PermitLimit = 5,               // Máximo de 5 requisições
                            Window = TimeSpan.FromSeconds(10), // Em 10 segundos
                            QueueProcessingOrder = QueueProcessingOrder.OldestFirst,
                            QueueLimit = 0
                        }));
               
                options.AddPolicy("LoginPolicy", context =>
                    RateLimitPartition.GetFixedWindowLimiter(
                        partitionKey: context.Connection.RemoteIpAddress?.ToString() ?? "anonymous",
                        factory: _ => new FixedWindowRateLimiterOptions
                        {
                            PermitLimit = 3,               // Apenas 3 tentativas
                            Window = TimeSpan.FromMinutes(1), // Em 1 minuto
                            QueueLimit = 0
                        }));
            });

            return services;
        }
    }
}
