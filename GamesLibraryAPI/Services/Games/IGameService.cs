using GamesLibraryShared.Games;

namespace GamesLibraryAPI.Services.Games;

public interface IGameService
{
    IEnumerable<GameResponse> GetGames();
    IEnumerable<GameResponse> GetGames(int userId, string? platform);
}