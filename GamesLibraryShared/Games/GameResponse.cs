namespace GamesLibraryShared.Games;

public class GameResponse : BaseResponse
{
    public int Id { get; set; }
    public string Title { get; set; } = default!;
    public string CompanyName { get; set; } = default!;
    public DateTime Premiere { get; set; } = default!;
    public List<string> Platforms { get; set; } = default!;
    public decimal Price { get; set; }
    public List<string> Genres { get; set; } = default!;
    public string PhotoUrl { get; set; } = default!;
    public string UserGamePlatform { get; set; } = default!;
}