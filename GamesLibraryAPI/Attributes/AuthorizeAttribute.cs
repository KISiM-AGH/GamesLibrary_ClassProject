using GamesLibraryAPI.Entities;
using GamesLibraryShared;
using GamesLibraryShared.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace GamesLibraryAPI.Attributes;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class AuthorizeAttribute : Attribute, IAuthorizationFilter
{
    private readonly AvailableRoles[] _roles;

    public AuthorizeAttribute(params AvailableRoles[] roles)
    {
        _roles = roles;
    }
    
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var allowAnonymous = context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any();
        if (allowAnonymous)
            return;
        
        var user = (User)context.HttpContext.Items["User"];

        if (user is null || (_roles.Any() && !_roles.Contains(user.Role.RoleName)))
        {
            context.Result = new UnauthorizedObjectResult(new BaseResponse()
            {
                Error = true,
                Message = "Unauthorized"
            });
        }
    }
}