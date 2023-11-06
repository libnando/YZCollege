using Microsoft.AspNetCore.Http;
using System.Text;
using System.Text.Json;

namespace YZCollege.Infrastructure.Middlewares
{
    public class AuthMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthMiddleware(RequestDelegate next)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
        }

        public async Task Invoke(HttpContext context)
        {
            var authKey = $"{context.Request.Headers["MyAuthKey"]}";

            //TODO: improve and apply the magic here
            var isValid = !string.IsNullOrEmpty(authKey);

            if (!isValid)
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;

                await context.Response.WriteAsync(JsonSerializer.Serialize(new { Error = "Unauthorized." }), encoding: Encoding.UTF8);

                return;
            }

            await _next(context);
        }
    }
}
