namespace ProductManager.Api.Presentation.Middlewares
{
    public class SecurityLogMiddleware(RequestDelegate next, ILogger<SecurityLogMiddleware> logger)
    {        
        public async Task InvokeAsync(HttpContext context)
        {
            await next(context);

            if (context.Response.StatusCode == StatusCodes.Status401Unauthorized)
            {
                var user = context.User.Identity?.Name ?? "anonymous";
                logger.LogWarning("Unauthorized {Path}. User: {User}", context.Request.Path, user);
            }

            if (context.Response.StatusCode == StatusCodes.Status403Forbidden)
            {
                var user = context.User.Identity?.Name ?? "anonymous";
                logger.LogWarning("Forbidden {Path}. User: {User}", context.Request.Path, user);
            }
        }
    }
}
