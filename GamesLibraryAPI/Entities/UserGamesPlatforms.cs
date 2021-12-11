using GamesLibraryShared.Games;

namespace GamesLibraryAPI.Entities;

public class UserGamesPlatforms
{
    public int UserId { get; set; }
    public int GameId { get; set; }
    public int PlatformId { get; set; } = default!;
}