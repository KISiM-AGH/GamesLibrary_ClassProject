using GamesLibraryAPI.Attributes;
using GamesLibraryAPI.Services.Games;
using GamesLibraryShared;
using GamesLibraryShared.Games;
using Microsoft.AspNetCore.Mvc;

namespace GamesLibraryAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class GameController : Controller
{
    private readonly IGameService _gameService;

    public GameController(IGameService gameService)
    {
        _gameService = gameService;
    }

    [HttpGet]
    [Authorize()]
    public ActionResult<IEnumerable<GameResponse>> GetAllGames()
    {
        var games = _gameService.GetGames();

        return Ok(games);
    }

    [HttpGet("user")]
    [Authorize()]
    public ActionResult<IEnumerable<GameResponse>> GetAllUserGames([FromRoute]int userId, 
        [FromQuery] string platform)
    {
        var games = platform == "all" ? _gameService.GetGames(null).ToList()
            : _gameService.GetGames(platform).ToList();

        return Ok(games);
    }

    [HttpPost]
    [Authorize()]
    public ActionResult<BaseResponse> AddGamesToUser([FromBody]GameUserRequest dto)
    {
        _gameService.AddGameToUser(dto);
        return Ok(new BaseResponse()
        {
            Error = false,
            Message = "Game added successfully!"
        });
    }
}