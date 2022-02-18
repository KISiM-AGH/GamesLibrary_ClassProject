namespace GamesLibraryShared.Games;

public class GameAdminRequest
{
    public string Title { get; set; } = default!;
    public string Description {  get; set; } = default!;
    public decimal Price { get; set; } = default!;
    public DateTime Premiere { get; set; } = default!;

    public int PegiId { get; set; }
    public List<int> Genres { get; set; } = default!;
    public string PegiValue { get; set; } = default!;
    public List<AvailablePlatforms> PlatformsList { get; set; } = default!;
    public int CompanyId { get; set; }
    public string PhotoUrl { get; set; } = default!;
}