namespace GamesLibraryAPI.Entities;

public class Pegi
{
    public int PegiId { get; set; }
    public string PegiValue { get; set; } = default!;
    public virtual ICollection<Game> Games { get; set; } = default!;
}