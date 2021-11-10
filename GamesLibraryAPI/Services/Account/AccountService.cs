using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using GamesLibraryAPI.Entities;
using GamesLibraryAPI.Exceptions;
using GamesLibraryShared.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace GamesLibraryAPI.Services.Account;

public class AccountService : IAccountService
{
    private readonly AppDbContext _dbContext;
    private readonly IPasswordHasher<User> _passwordHasher;
    private readonly IOptions<JwtSettings> _jwtSettings;

    public AccountService(AppDbContext dbContext, IPasswordHasher<User> passwordHasher, 
        IOptions<JwtSettings> jwtSettings)
    {
        _dbContext = dbContext;
        _passwordHasher = passwordHasher;
        _jwtSettings = jwtSettings;
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

    public async Task<string> Authenticate(UserLoginRequest loginRequest)
    {
        var user = await _dbContext.Users
            .Include(r => r.Role)
            .FirstOrDefaultAsync(u => u.UserName == loginRequest.Username);

        if (user is null)
            throw new BadRequestException("Invalid username or password");

        var result = _passwordHasher.VerifyHashedPassword(user, user.HashedPassword, loginRequest.Password);
        
        if (result == PasswordVerificationResult.Failed)
            throw new BadRequestException("Invalid username or password");

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_jwtSettings.Value.Secret);

        var tokenDescriptor = new SecurityTokenDescriptor()
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim("id", user.UserId.ToString()),
                new Claim("username", user.UserName),
                new Claim("name", user.Name),
                new Claim("surname", user.Surname),
                new Claim("email", user.Email),
                new Claim("birth", user.DateOfBirth.ToString(CultureInfo.CurrentCulture))
            }),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials =
                new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }

    public async Task<User?> GetById(int id)
    {
        return await _dbContext.Users.FirstOrDefaultAsync(x => x.UserId == id);
    }
}