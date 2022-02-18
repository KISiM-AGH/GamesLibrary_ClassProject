using System.Security.Claims;

namespace GamesLibraryAPI.Services.Account;

public interface IUserContextService
{
    ClaimsPrincipal? User { get; }
    int? GetUserId { get; }
}