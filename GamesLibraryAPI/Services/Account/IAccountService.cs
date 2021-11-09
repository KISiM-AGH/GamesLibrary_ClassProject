using GamesLibraryShared.User;

namespace GamesLibraryAPI.Services.Account;

public interface IAccountService
{
    void RegisterUser(UserRegisterRequest registerRequest);
}