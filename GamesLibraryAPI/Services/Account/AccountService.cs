using GamesLibraryAPI.Entities;
using GamesLibraryShared.User;
using Microsoft.AspNetCore.Identity;

namespace GamesLibraryAPI.Services.Account;

public class AccountService : IAccountService
{
    private readonly AppDbContext _dbContext;
    private readonly IPasswordHasher<User> _passwordHasher;

    public AccountService(AppDbContext dbContext, IPasswordHasher<User> passwordHasher)
    {
        _dbContext = dbContext;
        _passwordHasher = passwordHasher;
    }

    public void RegisterUser(UserRegisterRequest registerRequest)
    {
        var newUser = new User()
        {
            Name = registerRequest.Name,
            Surname = registerRequest.Surname,
            UserName = registerRequest.Username,
            Email = registerRequest.Email,
            DateOfBirth = registerRequest.DateOfBirth,
            RoleId = 2
        };

        newUser.HashedPassword = _passwordHasher.HashPassword(newUser, registerRequest.Password);

        _dbContext.Users.Add(newUser);
        _dbContext.SaveChanges();
    }
}