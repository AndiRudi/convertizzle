using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;

public class ApiKeyActionFilter
    : IAsyncActionFilter
{

    Task IAsyncActionFilter.OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        throw new NotImplementedException();
        // if (context.HttpContext.Request.Headers.TryGetValue("X-ApiKey", out Microsoft.Extensions.Primitives.StringValues apiKeyHeaderValues))
        // {
        //     var apiKeyHeaderValue = apiKeyHeaderValues.First();

        //     // ... your authentication logic here ...
        //     var username = (apiKeyHeaderValue == "12345" ? "Maarten" : "OtherUser");

        //     var usernameClaim = new Claim(ClaimTypes.Name, username);
        //     var identity = new ClaimsIdentity(new[] {usernameClaim}, "ApiKey");
        //     var principal = new ClaimsPrincipal(identity);

        //     context.HttpContext.User = principal;
        // }

        // return base.SendAsync(request, cancellationToken);
    }
}