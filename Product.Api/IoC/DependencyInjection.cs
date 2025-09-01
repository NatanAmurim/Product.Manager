using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ProductManager.Api.Application;
using ProductManager.Api.Domain.Interfaces;
using ProductManager.Api.Infra.Authentication;
using ProductManager.Api.Infra.Persistence;
using ProductManager.Api.Infra.Repositories;
using ProductManager.Api.IoC.Binds;
using System.Text;

namespace ProductManager.Api.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependencyServices(this IServiceCollection services)
        {
            services.AddScoped<ProductService>();
            services.AddScoped<JwtTokenGenerator>();

            return services;
        }

        public static IServiceCollection AddDependencyRepositories(this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseInMemoryDatabase("ProductsDb"));

            services.AddScoped<IProductRepository, ProductMemoryRepository>();

            return services;
        }

        public static IServiceCollection AddJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtSettings = new JwtSettings();
            configuration.GetSection("JwtSettings").Bind(jwtSettings);

            services.AddSingleton(jwtSettings);            

            var key = Encoding.UTF8.GetBytes(jwtSettings.Secret);

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings.Issuer,
                    ValidAudience = jwtSettings.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                };
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
                options.AddPolicy("UserOnly", policy => policy.RequireRole("User"));
            });

            return services;
        }
    }
}
