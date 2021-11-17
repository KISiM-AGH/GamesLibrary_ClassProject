namespace GamesLibraryAPI.Entities;

public class Platform
{
    public int PlatformId { get; set; }
    public AvailablePlatforms PlatformType { get; set; }
    
    public virtual ICollection<Game> Games { get; set; } = default!;
}