using GamesLibraryAPI.Entities;
using GamesLibraryAPI.Exceptions;
using GamesLibraryShared.Games;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace GamesLibraryAPI.Services.Games;

public class GameService : IGameService
{
    private readonly AppDbContext _dbContext;

    public GameService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
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

    public IEnumerable<GameResponse> GetGames(int userId, string? platform)
    {
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
                duplicateGame.UserPlatformType = GetPlatform(userGame.PlatformId);
                userSelectedGames.Add(duplicateGame);
            }
        }

        var gameResponse = CreateGameResponses(userSelectedGames.AsQueryable());

        return gameResponse;
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

    private AvailablePlatforms GetPlatform(int platformId)
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
}