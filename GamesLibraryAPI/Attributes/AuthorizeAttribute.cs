using GamesLibraryAPI.Entities;
using GamesLibraryShared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace GamesLibraryAPI.Attributes;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class AuthorizeAttribute : Attribute, IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var allowAnonymous = context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any();
        if (allowAnonymous)
            return;
        
        var user = context.HttpContext.Items["User"];

        if (user is null)
        {
            context.Result = new UnauthorizedObjectResult(new BaseResponse()
            {
                Error = true,
                Message = "Unauthorized"
            });
        }
    }
}