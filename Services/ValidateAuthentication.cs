using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

public class ValidateAuthentication : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        if (context.User.Identity.IsAuthenticated)
            await next(context);
        else
            await context.ChallengeAsync();
    }
}