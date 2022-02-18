using GamesLibraryShared.Games;

namespace GamesLibraryAPI.Services.Games;

public interface IGameService
{
    IEnumerable<GameResponse> GetGames();
    IEnumerable<GameResponse> GetGames(string? platform);
    void AddGameToUser(GameUserRequest dto);
}