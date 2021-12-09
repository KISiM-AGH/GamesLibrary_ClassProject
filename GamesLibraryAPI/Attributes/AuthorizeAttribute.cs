using System.Security.Claims;
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
        
        var user = context.HttpContext?.User;

        var role = user?.FindFirst(c => c.Type == ClaimTypes.Role)?.Value;

        if (user is null || role is null || (_roles.Any() && !_roles.Contains((AvailableRoles)Enum.Parse(typeof(AvailableRoles), role))))
        {
            context.Result = new UnauthorizedObjectResult(new BaseResponse()
            {
                Error = true,
                Message = "Unauthorized"
            });
        }
    }
}