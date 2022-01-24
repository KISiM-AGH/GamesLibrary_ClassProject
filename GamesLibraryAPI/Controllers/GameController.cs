using GamesLibraryAPI.Attributes;
using GamesLibraryAPI.Services.Games;
using GamesLibraryShared;
using GamesLibraryShared.Games;
using GamesLibraryShared.User;
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

    [HttpPost("user")]
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

    [HttpPost]
    [Authorize(AvailableRoles.Admin)]
    public ActionResult<BaseResponse> AddGameToDb([FromBody] GameAdminRequest dto)
    {
        _gameService.AddGameToDataBase(dto);

        return Ok(new BaseResponse()
        {
            Error = false,
            Message = "Game added successfully!"
        });
    }

    [HttpGet("features/pegi")]
    public ActionResult<IEnumerable<PegiResponse>> GetAllPegiesValues()
    {
        return Ok(_gameService.GetPegiValues());
    }
    
    [HttpGet("features/genre")]
    public ActionResult<IEnumerable<GenreResponse>> GetAllAvailableGenres()
    {
        return Ok(_gameService.GetAvailableGenres());
    }
    
    [HttpGet("features/platform")]
    public ActionResult<IEnumerable<AvailablePlatformsResponse>> GetAllAvailablePlatforms()
    {
        return Ok(_gameService.GetAvailablePlatforms());
    }
    
    [HttpGet("features/company")]
    public ActionResult<IEnumerable<AvailableCompaniesResponse>> GetAllAvailableCompanies()
    {
        return Ok(_gameService.GetAvailableCompanies());
    }
}