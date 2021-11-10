using System.IdentityModel.Tokens.Jwt;
using System.Text;
using GamesLibraryAPI.Services.Account;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace GamesLibraryAPI.Middleware;

public class JwtMiddleware : IMiddleware
{
    private readonly IOptions<JwtSettings> _jwtSettings;
    private readonly IAccountService _accountService;

    public JwtMiddleware(IOptions<JwtSettings> jwtSettings, IAccountService accountService)
    {
        _jwtSettings = jwtSettings;
        _accountService = accountService;
    }
    
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

        if (token is not null)
        {
            AttachUserToContext(context, token);
        }

        await next(context);
    }

    private void AttachUserToContext(HttpContext context, string token)
    {
        try
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.Value.Secret);

            tokenHandler.ValidateToken(token, new TokenValidationParameters()
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
                ClockSkew = TimeSpan.Zero
            }, out var validatedToken);

            var jwtToken = (JwtSecurityToken)validatedToken;
            var userId = int.Parse(jwtToken.Claims.First(x => x.Type == "id").Value);

            context.Items["User"] = _accountService.GetById(userId);
        }
        catch
        {
            // ignored
        }
    }
}