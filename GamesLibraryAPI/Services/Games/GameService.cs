using GamesLibraryAPI.Entities;
using GamesLibraryAPI.Exceptions;
using GamesLibraryAPI.Services.Account;
using GamesLibraryShared.Games;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace GamesLibraryAPI.Services.Games;

public class GameService : IGameService
{
    private readonly AppDbContext _dbContext;
    private readonly IUserContextService _userContextService;

    public GameService(AppDbContext dbContext, IUserContextService userContextService)
    {
        _dbContext = dbContext;
        _userContextService = userContextService;
    }
    
    public IEnumerable<GameResponse> GetGames()
    {
        var games = _dbContext.Games
            .Include(g => g.Company)
            .Include(g => g.Genres)
            .Include(g => g.Platforms);

        var gamesResponse = CreateGameResponses(games);

        return gamesResponse;
    }

    public IEnumerable<GameResponse> GetGames(string? platform)
    {
        var userId = _userContextService.GetUserId;
        
        var userGames = _dbContext.UserGamesPlatforms.Where(u => u.UserId == userId).ToList();

        var games = _dbContext.Games
            .Include(g => g.Company)
            .Include(g => g.Genres)
            .Include(g => g.Platforms).ToList();

        var userSelectedGames = new List<Game>();

        foreach (var game in games)
        {
            foreach (var userGame in userGames.Where(userGame => userGame.GameId == game.GameId))
            {
                if (platform != null)
                    if (((AvailablePlatforms)(userGame.PlatformId - 1)).ToString() != platform) continue;
                
                var duplicateGame = (Game)game.Clone();
                duplicateGame.UserPlatformType = GetPlatformEnum(userGame.PlatformId);
                userSelectedGames.Add(duplicateGame);
            }
        }

        var gameResponse = CreateGameResponses(userSelectedGames.AsQueryable());

        return gameResponse;
    }

    public void AddGameToUser(GameUserRequest dto)
    {
        var userId = _userContextService.GetUserId;

        if (userId != null)
        {
            var game = _dbContext.Games.FirstOrDefault(x => x.GameId == dto.Id);

            if (game != null)
            {
                if (game.Title != dto.Title)
                    throw new AddGameClientException("The given id does not match the title of the game");

                var newGame = new UserGamesPlatforms()
                {
                    GameId = game.GameId,
                    PlatformId = GetPlatformId(dto.Platform),
                    UserId = (int)userId
                };

                _dbContext.UserGamesPlatforms.Add(newGame);
                _dbContext.SaveChanges();

            }
            else
                throw new BadRequestException("The given id does not match any game");
        }
        else
        {
            throw new Exception();
        }
        
    }

    public void AddGameToDataBase(GameAdminRequest)
    {
        
    }

    private static IEnumerable<GameResponse> CreateGameResponses(IQueryable<Game> games)
    {
        if (!games.Any())
        {
            throw new NoGamesException("There is no games to show!");
        }

        var gamesResponse = (from game in games
            let genresNames = game.Genres.Select(genre => genre.GenreName).ToList()
            let platformNames = game.Platforms.Select(platform => platform.PlatformType.ToString()).ToList()
            select new GameResponse()
            {
                Id = game.GameId,
                Title = game.Title,
                Genres = genresNames,
                Platforms = platformNames,
                Premiere = game.Premiere,
                Price = game.Price,
                CompanyName = game.Company.CompanyName,
                PhotoUrl = game.PhotoUrl,
                UserGamePlatform = game.UserPlatformType.ToString()
            }).ToList();
        return gamesResponse;
    }

    private AvailablePlatforms GetPlatformEnum(int platformId)
    {
        return platformId switch
        {
            1 => AvailablePlatforms.Pc,
            2 => AvailablePlatforms.Xbox,
            3 => AvailablePlatforms.PlayStation,
            4 => AvailablePlatforms.Nintendo,
            _ => AvailablePlatforms.Pc
        };
    }

    private int GetPlatformId(AvailablePlatforms platform)
    {
        return platform switch
        {
            AvailablePlatforms.Pc => 1,
            AvailablePlatforms.Xbox => 2,
            AvailablePlatforms.PlayStation => 3,
            AvailablePlatforms.Nintendo => 4,
            _ => throw new BadRequestException("Provided request have incorrect platform")
        };
    }
}