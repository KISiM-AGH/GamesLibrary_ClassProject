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
        _accountService.RegisterUser(registerUser);
        return Ok(new BaseResponse()
        {
            Error = false,
            Message = "New account has been created successfully"
        });
    }
}