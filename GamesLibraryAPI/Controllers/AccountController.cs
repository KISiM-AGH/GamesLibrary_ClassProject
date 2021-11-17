using GamesLibraryAPI.Services.Account;
using GamesLibraryShared;
using GamesLibraryShared.User;
using Microsoft.AspNetCore.Mvc;

namespace GamesLibraryAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class AccountController : Controller
{
    private readonly IAccountService _accountService;

    public AccountController(IAccountService accountService)
    {
        _accountService = accountService;
    }
    
    [HttpPost]
    public ActionResult<BaseResponse> RegisterUser([FromBody]UserRegisterRequest registerUser)
    {
        _accountService.Register(registerUser);
        return Ok(new BaseResponse()
        {
            Error = false,
            Message = "New account has been created successfully"
        });
    }

    [HttpGet]
    public async Task<ActionResult<AuthenticateResponse>> Authenticate([FromBody] UserLoginRequest loginRequest)
    {
        var token = await _accountService.Authenticate(loginRequest);
        return Ok(new AuthenticateResponse()
        {
            Error = false,
            Message = "User signed in successfully",
            JwtToken = token
        });
    }
}