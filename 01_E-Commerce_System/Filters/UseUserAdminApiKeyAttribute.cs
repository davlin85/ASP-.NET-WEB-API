using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace _01_E_Commerce_System.Filters
{
    public class UseUserAdminApiKeyAttribute : Attribute, IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var configuration = context.HttpContext.RequestServices.GetRequiredService<IConfiguration>();
            var apiKey = configuration.GetValue<string>("UserApiKey");

            if (!context.HttpContext.Request.Query.TryGetValue("code", out var code))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            if (!apiKey.Equals(code))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            await next();
        }
    }
}
