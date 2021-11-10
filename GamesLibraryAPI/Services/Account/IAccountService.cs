using GamesLibraryAPI.Entities;
using GamesLibraryShared.User;

namespace GamesLibraryAPI.Services.Account;

public interface IAccountService
{
    void RegisterUser(UserRegisterRequest registerRequest);
    Task<User?> GetById(int id);
    Task<string> Authenticate(UserLoginRequest loginRequest);
}