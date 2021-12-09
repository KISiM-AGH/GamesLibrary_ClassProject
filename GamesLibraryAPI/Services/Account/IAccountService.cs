using GamesLibraryAPI.Entities;
using GamesLibraryShared.User;

namespace GamesLibraryAPI.Services.Account;

public interface IAccountService
{
    void Register(UserRegisterRequest registerRequest);
    Task<UserResponse> GetById(int id);
    Task<string> Authenticate(UserLoginRequest loginRequest);
    Task<IEnumerable<UserResponse>> GetAllUsers();
}