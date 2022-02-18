using System.Security.Claims;

namespace GamesLibraryAPI.Services.Account;

public class UserContextService : IUserContextService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public UserContextService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public ClaimsPrincipal? User => _httpContextAccessor.HttpContext?.User;

    public int? GetUserId
    {
        get
        {
            var value = User?.FindFirst(c => c.Type == "id")?.Value;
            if (value != null)
                return User is null ? null : int.Parse(value);
            return null;
        }
    }
}