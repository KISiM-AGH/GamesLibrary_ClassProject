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
    private readonly JwtSettings _jwtSettings;

    public AccountService(AppDbContext dbContext, IPasswordHasher<User> passwordHasher, 
        JwtSettings jwtSettings)
    {
        _dbContext = dbContext;
        _passwordHasher = passwordHasher;
        _jwtSettings = jwtSettings;
    }

    public void Register(UserRegisterRequest registerRequest)
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

    public string Authenticate(UserLoginRequest loginRequest)
    {
        var user = _dbContext.Users
            .Include(r => r.Role)
            .FirstOrDefault(u => u.UserName == loginRequest.Username);

        if (user is null)
            throw new BadRequestException("Invalid username or password");

        var result = _passwordHasher.VerifyHashedPassword(user, user.HashedPassword, loginRequest.Password);
        
        if (result == PasswordVerificationResult.Failed)
            throw new BadRequestException("Invalid username or password");

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);

        var tokenDescriptor = new SecurityTokenDescriptor()
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim("id", user.UserId.ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.UserName),
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Surname, user.Surname),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.DateOfBirth, user.DateOfBirth.ToString(CultureInfo.CurrentCulture)),
                new Claim(ClaimTypes.Role, user.Role.RoleName.ToString())
                
            }),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials =
                new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }

    public UserResponse GetById(int id)
    {
        var user = GetUser(id);

        var userResponse = new UserResponse()
        {
            UserId = user.UserId,
            Name = user.Name,
            Surname = user.Surname,
            Email = user.Email,
            DateOfBirth = user.DateOfBirth,
            UserName = user.UserName,
            
            Role = user.Role.RoleName.ToString()
        };

        return userResponse;
    }

    public IEnumerable<UserResponse> GetAllUsers()
    {
        var users = _dbContext.Users.ToList();
        var response = new List<UserResponse>();

        foreach (var user in users)
        {
            var role = _dbContext.Roles.FirstOrDefault(r => r.RoleId == user.RoleId);

            if (role == null) throw new IncorrectUserException("Invalid account!");
            
            var temp = new UserResponse()
            {
                UserId = user.UserId,
                Name = user.Name,
                Surname = user.Surname,
                Email = user.Email,
                DateOfBirth = user.DateOfBirth,
                UserName = user.UserName,
                Role = role.RoleName.ToString()
            };
            
            response.Add(temp);
        }

        return response;
    }

    private User GetUser(int id)
    {
        var user = _dbContext.Users
            .FirstOrDefault(x => x.UserId == id);
        
        if (user is null) throw new UserNotFoundException("User not found");
        return user;
    }


}