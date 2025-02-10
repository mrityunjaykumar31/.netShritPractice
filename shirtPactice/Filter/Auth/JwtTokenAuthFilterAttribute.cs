using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using shirtPactice.Modal;

namespace shirtPactice.Filter.Auth
{
    public class JwtTokenAuthFilterAttribute : Attribute, IAsyncAuthorizationFilter
    {
        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            if (!context.HttpContext.Request.Headers.TryGetValue("Authorization", out var token)) {
                context.Result = new UnauthorizedResult();
                return;
            }
           if(!Authentication.ValidateJwtToken(token))
            {
                context.Result = new UnauthorizedResult();
            }
        }

    }
}
