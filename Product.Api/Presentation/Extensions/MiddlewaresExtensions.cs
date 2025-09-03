using ProductManager.Api.Presentation.Middlewares;

namespace ProductManager.Api.Presentation.Extensions
{
    public static class MiddlewaresExtensions
    {
        public static IApplicationBuilder UseMiddlewares(this IApplicationBuilder app)
        {
            app.UseMiddleware<SecurityLogMiddleware>();

            return app;
        }
    }
}
