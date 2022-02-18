using GamesLibraryAPI.Entities;
using GamesLibraryShared.User;

namespace GamesLibraryAPI.Services.Account;

public interface IAccountService
{
    void Register(UserRegisterRequest registerRequest);
    UserResponse GetById(int id);
    string Authenticate(UserLoginRequest loginRequest);
    IEnumerable<UserResponse> GetAllUsers();
}